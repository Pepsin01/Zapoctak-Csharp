using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ships_JosefLukasek
{
    // Enumeration to represent the state of a square on the grid.
    enum SquareState { Free, Occupied, Hit }

    // Enumeration to represent the state of the game plan.
    enum PlanState { Locked, Placing, Standby, Hidden }

    // Represents a ship on the game plan grid.
    internal class Ship
    {
        // Enumeration to specify the direction of the ship.
        public enum ShipDir { Down, Up, Left, Right }

        // Current direction of the ship.
        public ShipDir dir { get; private set; }

        // Length of the ship.
        public int Length { get; }

        // Array to store the squares occupied by the ship.
        public Square[] occupiedSquares { get; private set; }

        /// <summary>
        /// Initializes a new ship with the specified length.
        /// </summary>
        /// <param name="length">The length of the ship.</param>
        public Ship(int length)
        {
            this.Length = length;
            dir = ShipDir.Down;
            occupiedSquares = new Square[(Length * 3) + 2];
        }


        /// <summary>
        /// Rotates the ship 90 degrees clockwise.
        /// </summary>
        /// <returns>The new direction of the ship.</returns>
        public ShipDir Rotate()
        {
            switch (dir)
            {
                case ShipDir.Down:
                    dir = ShipDir.Right;
                    return dir;
                case ShipDir.Up:
                    dir = ShipDir.Left;
                    return dir;
                case ShipDir.Left:
                    dir = ShipDir.Down;
                    return dir;
                case ShipDir.Right:
                    dir = ShipDir.Up;
                    return dir;
                default:
                    return dir;
            }
            
        }

        /// <summary>
        /// Removes the ship from the grid.
        /// </summary>
        public void Remove()
        {
            foreach (var s in occupiedSquares)
                if (s != null)
                {
                    s.State = SquareState.Free;
                    s.ship = null;
                }
            occupiedSquares = new Square[(Length * 3) + 2];
        }
    }

    // Represents a square on the game plan grid.
    internal class Square
    {
        SquareState state = SquareState.Free;
        public SquareState State {
            get { return state; }
            set
            {
                switch (value)
                {
                    case SquareState.Free:
                        occupationCounter--;
                        if (occupationCounter <= 0)
                        {
                            occupationCounter = 0;
                            state = SquareState.Free;
                        }
                        break;
                    case SquareState.Occupied:
                        occupationCounter++;
                        state = SquareState.Occupied;
                        break;
                    case SquareState.Hit:
                        state = SquareState.Hit;
                        break;
                    default:
                        break;
                }
            } }
        public Square Up { get; set; }
        public Square Down { get; set; }
        public Square Right { get; set; }
        public Square Left { get; set; }
        public Button button { get; }
        public Ship? ship { get; set; }
        int occupationCounter = 0;

        /// <summary>
        /// Initializes a new square with the specified state and associated button.
        /// </summary>
        /// <param name="state">The initial state of the square.</param>
        /// <param name="button">The button associated with the square.</param>
        public Square(SquareState state, Button button)
        {
            this.state = state;
            this.button = button;
        }
    }

    // Represents the game plan grid and logic.
    internal class GamePlan
    {
        // The form associated with the game plan.
        ShipsForm form;

        // The grid of squares.
        Square[,] grid;

        // Size of a square in pixels.
        const int squareSize = 40;

        // Default left position of the grid.
        int defaultLeft;

        // Default top position of the grid.
        int defaultTop;

        // Predefined counts of ships.
        int[] ships = new[] { 4, 3, 2, 1 };

        // Current state of the game plan.
        public PlanState state { get; private set; }

        // The ship currently being placed.
        Ship? currentShip;

        // The last button the mouse was hovering on.
        Button lastlyHoveredOn;

        // The callback action for shooting on a square.
        Action<bool, (int i, int j)> shootCallBack; 

        // Indicates whether the game plan is ready to be locked.
        public bool IsReady { get; private set; } = false;

        /// <summary>
        /// Initializes a new game plan with the specified form, default left and top positions, and shoot callback action.
        /// </summary>
        /// <param name="form">The form associated with the game plan.</param>
        /// <param name="defaultLeft">The default left position of the grid.</param>
        /// <param name="defaultTop">The default top position of the grid.</param>
        /// <param name="shootCallBack">The callback action for shooting on a square.</param>
        public GamePlan(ShipsForm form, int defaultLeft, int defaultTop, Action<bool, (int i, int j)> shootCallBack)
        {
            this.form = form;
            this.defaultLeft = defaultLeft;
            this.defaultTop = defaultTop;
            this.shootCallBack = shootCallBack;
            grid = CreatePlan();
            state = PlanState.Standby;
            RefreshPlacingGraphics();
        }

        /// <summary>
        /// Creates the game plan grid with squares and buttons.
        /// </summary>
        /// <returns>The grid of squares.</returns>
        Square[,] CreatePlan()
        {
            Square[,] grid = new Square[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button b = new Button();
                    (b.Width, b.Height) = (squareSize, squareSize);
                    b.Left = (i * squareSize) + defaultLeft;
                    b.Top = (j * squareSize) + defaultTop;
                    grid[i, j] = new Square(SquareState.Free, b);
                    
                    MakeNeighborsForSquare(i, j, grid);

                    b.TabStop = false;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 1;
                    b.Visible = true;
                    b.Click += OnPlanClick;
                    b.MouseHover += OnPlanHover;
                    form.Controls.Add(b);
                }
            }
            return grid;
        }

        /// <summary>
        /// Creates neighbors for the specified square in the grid.
        /// </summary>
        /// <param name="i">The row index of the square.</param>
        /// <param name="j">The column index of the square.</param>
        /// <param name="grid">The game plan grid.</param>
        void MakeNeighborsForSquare(int i, int j, Square[,] grid)
        {
            if (IsExistingSquare(i + 1, j) && grid[i + 1, j] != null)
            {
                grid[i, j].Right = grid[i + 1, j];
                grid[i + 1, j].Left = grid[i, j];
            }
            if (IsExistingSquare(i - 1, j) && grid[i - 1, j] != null)
            {
                grid[i, j].Left = grid[i - 1, j];
                grid[i - 1, j].Right = grid[i, j];
            }
            if (IsExistingSquare(i, j + 1) && grid[i, j + 1] != null)
            {
                grid[i, j].Down = grid[i, j + 1];
                grid[i, j + 1].Up = grid[i, j];
            }
            if (IsExistingSquare(i, j - 1) && grid[i, j - 1] != null)
            {
                grid[i, j].Up = grid[i, j - 1];
                grid[i, j - 1].Down = grid[i, j];
            }
        }

        /// <summary>
        /// Converts a button to grid coordinates.
        /// </summary>
        /// <param name="btn">The button to convert.</param>
        /// <returns>The grid coordinates as a tuple (i, j).</returns>
        public (int i, int j) BtnToCoordinates(Button btn)
        {
            int i = (btn.Left - defaultLeft) / squareSize;
            int j = (btn.Top - defaultTop) / squareSize;
            return (i, j);
        }

        /// <summary>
        /// Handles the click event on a square in the game plan grid.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        public void OnPlanClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (state)
            {
                case PlanState.Locked:
                    break;
                case PlanState.Placing:
                    PlaceCurrShip(BtnToCoordinates(btn), true);
                    RefreshPlacingGraphics(); 
                    break;
                case PlanState.Standby:
                    RemoveShip(BtnToCoordinates(btn));
                    RefreshPlacingGraphics();
                    break;
                case PlanState.Hidden:
                    if (!IsHit(BtnToCoordinates(btn)))
                    {
                        bool wasHit = ShootOnSquare(BtnToCoordinates(btn));
                        RefreshInGameGraphics();
                        state = PlanState.Locked;
                        shootCallBack(wasHit, BtnToCoordinates(btn));
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Handles the hover event over a square in the game plan grid.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        public void OnPlanHover(object? sender, EventArgs? e)
        {
            Button btn = (Button) (sender ?? lastlyHoveredOn);

            switch (state)
            {
                case PlanState.Locked:
                    break;
                case PlanState.Placing:
                    RefreshPlacingGraphics();
                    PlaceCurrShip(BtnToCoordinates(btn), false);
                    break;
                case PlanState.Standby:
                    RefreshPlacingGraphics();
                    break;
                case PlanState.Hidden:
                    break;
                default:
                    break;
            }
            lastlyHoveredOn = btn;
        }

        /// <summary>
        /// Marks the square as hit.
        /// </summary>
        /// <param name="pos"> The position of the square.</param>
        /// <returns> True if the square exists, false otherwise.</returns>
        public bool MarkSquareAsHit((int i, int j) pos)
        {
            if (IsExistingSquare(pos.i, pos.j))
            {
                grid[pos.i, pos.j].State = SquareState.Hit;
                RefreshInGameGraphics();
                return true;
            }
            return false;
        }

        public bool TryReadyLock()
        {
            foreach (int ship in ships)
            {
                if(ship != 0)
                {
                    return false;
                }
            }
            state = PlanState.Locked;
            IsReady = true;
            RefreshInGameGraphics();
            return true;
        }

        public void Lock()
        {
            state = PlanState.Locked;
            RefreshInGameGraphics();
        }

        public void Unlock()
        {
            state = PlanState.Hidden;
            RefreshInGameGraphics();
        }

        /// <summary>
        /// Places the current ship on the game plan grid.
        /// </summary>
        /// <param name="pos">The position where the ship is being placed.</param>
        /// <param name="buildMode">True if in build mode (placing the ship), false if in preview mode (hovering).</param>
        void PlaceCurrShip((int i, int j) pos, bool buildMode)
        {

            switch (currentShip.dir)
            {
                case Ship.ShipDir.Down:
                    if (IsPositionValid(pos.i, pos.j, 0, 1, currentShip.Length))
                    {
                        if (buildMode)
                        {
                            OccupieSquares(pos.i, pos.j, 0, 1, currentShip.Length);
                            state = PlanState.Standby;
                            currentShip = null;
                        }
                        else
                            ColorValidSquares(pos.i, pos.j, 0, 1, currentShip.Length);
                    }
                    else if (!buildMode)
                        ColorInvalidSquares(pos.i, pos.j, 0, 1, currentShip.Length);

                    break;
                case Ship.ShipDir.Up:
                    if (IsPositionValid(pos.i, pos.j, 0, -1, currentShip.Length))
                    {
                        if (buildMode)
                        {
                            OccupieSquares(pos.i, pos.j, 0, -1, currentShip.Length);
                            state = PlanState.Standby;
                            currentShip = null;
                        }
                        else
                            ColorValidSquares(pos.i, pos.j, 0, -1, currentShip.Length);

                    }
                    else if (!buildMode)
                        ColorInvalidSquares(pos.i, pos.j, 0, -1, currentShip.Length);

                    break;
                case Ship.ShipDir.Left:
                    if (IsPositionValid(pos.i, pos.j, 1, 0, currentShip.Length))
                    {
                        if (buildMode)
                        {
                            OccupieSquares(pos.i, pos.j, 1, 0, currentShip.Length);
                            state = PlanState.Standby;
                            currentShip = null;
                        }
                        else
                            ColorValidSquares(pos.i, pos.j, 1, 0, currentShip.Length);

                    }
                    else if (!buildMode)
                        ColorInvalidSquares(pos.i, pos.j, 1, 0, currentShip.Length);

                    break;
                case Ship.ShipDir.Right:
                    if (IsPositionValid(pos.i, pos.j, -1, 0, currentShip.Length))
                    {
                        if (buildMode)
                        {
                            OccupieSquares(pos.i, pos.j, -1, 0, currentShip.Length);
                            state = PlanState.Standby;
                            currentShip = null;
                        }
                        else
                            ColorValidSquares(pos.i, pos.j, -1, 0, currentShip.Length);

                    }
                    else if (!buildMode)
                        ColorInvalidSquares(pos.i, pos.j, -1, 0, currentShip.Length);

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Colors valid squares for ship placement.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <param name="modi">The modifier for the row index based on ship direction.</param>
        /// <param name="modj">The modifier for the column index based on ship direction.</param>
        /// <param name="length">The length of the ship.</param>
        void ColorValidSquares(int i, int j, int modi, int modj, int length)
        {
            for (int x = 0; x < length; x++)
            {
                grid[i + (modi * x), j + (modj * x)].button.BackColor = Color.LimeGreen;
            }
        }

        /// <summary>
        /// Colors invalid squares for ship placement.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <param name="modi">The modifier for the row index based on ship direction.</param>
        /// <param name="modj">The modifier for the column index based on ship direction.</param>
        /// <param name="length">The length of the ship.</param>
        void ColorInvalidSquares(int i, int j, int modi, int modj, int length)
        {
            for (int x = 0; x < length; x++)
            {
                if (IsExistingSquare(i + (modi * x), j + (modj * x)))
                {
                    grid[i + (modi * x), j + (modj * x)].button.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Occupies squares on the game plan grid with the current ship.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <param name="modi">The modifier for the row index based on ship direction.</param>
        /// <param name="modj">The modifier for the column index based on ship direction.</param>
        /// <param name="length">The length of the ship.</param>
        void OccupieSquares(int i, int j, int modi, int modj, int length)
        {
            for (int x = 0; x < length; x++)
            {
                grid[i + (modi * x), j + (modj * x)].State = SquareState.Occupied;
                grid[i + (modi * x), j + (modj * x)].ship = currentShip;
                currentShip.occupiedSquares[x] = grid[i + (modi * x), j + (modj * x)];
            }
            int y = length;
            for (int x = 0; x < length; x++)
            {
                if (currentShip.occupiedSquares[x].Up != null && currentShip.occupiedSquares[x].Up.ship == null)
                {
                    currentShip.occupiedSquares[x].Up.State = SquareState.Occupied;
                    currentShip.occupiedSquares[y] = currentShip.occupiedSquares[x].Up;
                    y++;
                }
                if (currentShip.occupiedSquares[x].Down != null && currentShip.occupiedSquares[x].Down.ship == null)
                {
                    currentShip.occupiedSquares[x].Down.State = SquareState.Occupied;
                    currentShip.occupiedSquares[y] = currentShip.occupiedSquares[x].Down;
                    y++;
                }
                if (currentShip.occupiedSquares[x].Right != null && currentShip.occupiedSquares[x].Right.ship == null)
                {
                    currentShip.occupiedSquares[x].Right.State = SquareState.Occupied;
                    currentShip.occupiedSquares[y] = currentShip.occupiedSquares[x].Right;
                    y++;
                }
                if (currentShip.occupiedSquares[x].Left != null && currentShip.occupiedSquares[x].Left.ship == null)
                {
                    currentShip.occupiedSquares[x].Left.State = SquareState.Occupied;
                    currentShip.occupiedSquares[y] = currentShip.occupiedSquares[x].Left;
                    y++;
                }
            }
        }

        /// <summary>
        /// Checks if a given position is valid for ship placement.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <param name="modi">The modifier for the row index based on ship direction.</param>
        /// <param name="modj">The modifier for the column index based on ship direction.</param>
        /// <param name="length">The length of the ship.</param>
        /// <returns>True if the position is valid for ship placement, otherwise false.</returns>
        bool IsPositionValid(int i, int j, int modi, int modj, int length)
        {
            for (int x = 0; x < length; x++)
            {
                if (!IsExistingSquare(i + (modi * x), j + (modj * x)) || grid[i + (modi * x), j + (modj * x)].State != SquareState.Free)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a square at the specified coordinates exists on the game plan grid.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <returns>True if the square exists, otherwise false.</returns>
        bool IsExistingSquare(int i, int j)
        {
            if (i > 9 || j > 9 || i < 0 || j < 0)
                return false;
            return true;
        }

        /// <summary>
        /// Removes a ship from the game plan grid at the specified position.
        /// </summary>
        /// <param name="pos">The position of the ship to be removed.</param>
        void RemoveShip((int i, int j) pos)
        {
            Ship? ship = grid[pos.i, pos.j].ship;
            if ( ship != null)
            {
                currentShip = ship;
                currentShip.Remove();
                state = PlanState.Placing;
            }
        }

        /// <summary>
        /// Picks a ship of the specified length to be placed on the game plan grid.
        /// </summary>
        /// <param name="length">The length of the ship to pick.</param>
        public void PickShip(int length)
        {
            if (ships[length - 1] > 0 && currentShip == null)
            {
                ships[length - 1] -= 1;
                currentShip = new Ship(length);
                state = PlanState.Placing;
            }
            else if (ships[length - 1] > 0 && currentShip != null)
            {
                ships[currentShip.Length - 1] += 1;
                ships[length - 1] -= 1;
                currentShip = currentShip = new Ship(length);
            }
        }

        /// <summary>
        /// Rotates the current ship 90 degrees clockwise.
        /// </summary>
        public void RotateCurrShip()
        {
            currentShip?.Rotate();
            OnPlanHover(null, null);
        }

        /// <summary>
        /// Refreshes the graphics of the game plan grid during ship placement.
        /// </summary>
        void RefreshPlacingGraphics()
        {
            foreach (var s in grid)
            {
                if (s.ship != null)
                {
                    s.button.BackColor = Color.FromArgb(87, 36, 1);
                    s.button.Image = Image.FromFile("graphics/mapShip.png");
                }
                else
                {
                    s.button.BackColor = Color.FromArgb(2, 12, 189);
                    s.button.Image = Image.FromFile("graphics/water.png");
                }
            }
        }

        /// <summary>
        /// Refreshes the in-game graphics of the game plan grid.
        /// </summary>
        void RefreshInGameGraphics()
        {
            if (PlanState.Hidden == state || PlanState.Locked == state)
            {
                foreach (var s in grid)
                {
                    if (s.ship != null && s.State == SquareState.Hit)
                    {
                        s.button.BackColor = Color.FromArgb(87, 36, 1);
                        s.button.Image = Image.FromFile("graphics/hitCross.png");
                    }
                    else if (s.State == SquareState.Hit)
                    {
                        s.button.BackColor = Color.FromArgb(2, 12, 189);
                        s.button.Image = Image.FromFile("graphics/water.png");
                    }
                    else
                    {
                        s.button.BackColor = Color.LightGray;
                        s.button.Image = null;
                    }
                }
            }
            else
            {
                foreach (var s in grid)
                {
                    if (s.ship != null)
                    {
                        s.button.BackColor = Color.FromArgb(87, 36, 1);
                        s.button.Image = Image.FromFile("graphics/mapShip.png");
                    }
                    else
                    {
                        s.button.BackColor = Color.FromArgb(2, 12, 189);
                        s.button.Image = Image.FromFile("graphics/water.png");
                    }
                }
            }

        }

        /// <summary>
        /// Converts the game plan grid to a string representation.
        /// </summary>
        /// <returns>A string representing the game plan grid.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (grid[i, j].ship != null)
                        result.Append('S');
                    else
                        result.Append('W');
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Loads a game plan grid from a string representation.
        /// </summary>
        /// <param name="plan"> The string representation of the game plan grid. </param>
        /// <returns> True if the string was valid, otherwise false. </returns>
        public bool LoadPlanFromString(string plan)
        {
            if (plan.Length != 100)
                return false;
            int i = 0;
            int j = 0;
            foreach (char c in plan)
            {
                if (c == 'S')
                    grid[i, j].ship = new Ship(1);
                else if (c != 'W')
                    return false;
                i++;
                if (i == 10)
                {
                    i = 0;
                    j++;
                }
            }

            state = PlanState.Locked;
            RefreshInGameGraphics();
            IsReady = true;

            return true;
        }

        /// <summary>
        /// Checks if a square at the specified position has been hit.
        /// </summary>
        /// <param name="pos">The position to check.</param>
        /// <returns>True if the square has been hit, otherwise false.</returns>
        bool IsHit((int i, int j) pos)
        {
            if (grid[pos.i, pos.j].State == SquareState.Hit)
                return true;
            return false;
        }

        /// <summary>
        /// Shoots at a square on the game plan grid.
        /// </summary>
        /// <param name="pos">The position to shoot at.</param>
        /// <returns>True if a ship is hit, otherwise false.</returns>
        bool ShootOnSquare((int i, int j) pos)
        {
            grid[pos.i, pos.j].State = SquareState.Hit;
            if (grid[pos.i, pos.j].ship != null)
                return true;
            return false;
        }

        /// <summary>
        /// Resizes the game plan grid based on the size of the form's client area.
        /// </summary>
        public void Resize(bool local)
        {
            int newLeft = (form.ClientRectangle.Width / 2) + (local ? (- (10* squareSize) - 5) : 5);
            int newTop = (form.ClientRectangle.Height / 2) - (5 * squareSize);
            int diffLeft = newLeft - defaultLeft;
            int diffTop = newTop - defaultTop;
            defaultLeft = newLeft;
            defaultTop = newTop;
            foreach(Square s in grid)
            {
                s.button.Left += diffLeft;
                s.button.Top += diffTop;
            }
        }
    }
}
