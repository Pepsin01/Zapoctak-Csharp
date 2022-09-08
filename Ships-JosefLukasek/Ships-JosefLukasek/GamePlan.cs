using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ships_JosefLukasek
{

    enum SquareState { Free, Occupied, Hit }
    enum PlanState { Locked, Placing, Standby, Hidden }

    internal class Ship
    {
        public enum ShipDir { Down, Up, Left, Right }
        public ShipDir dir { get; private set; }
        public int Length { get; }
        public Square[] occupiedSquares { get; private set; }

        public Ship(int length)
        {
            this.Length = length;
            dir = ShipDir.Down;
            occupiedSquares = new Square[(Length * 3) + 2];
        }

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
        public Square(SquareState state, Button button)
        {
            this.state = state;
            this.button = button;
        }
    }
    internal class GamePlan
    {
        Form1 form;
        Square[,] grid;
        int squareSize = 30;
        int defaultLeft;
        int defaultTop;
        int[] ships = new[]{ 4, 3, 2, 1 };
        public PlanState state { get; set; }
        Ship? currentShip;
        Button lastlyHoveredOn;

        public GamePlan(Form1 form)
        {
            this.form = form;
            defaultLeft = (form.ClientRectangle.Width / 2) - (10 * squareSize);
            defaultTop = (form.ClientRectangle.Height / 2) - (10 * squareSize);
            grid = CreatePlan();
            state = PlanState.Standby;
            RefreshColors();
        }

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

        public (int i, int j) BtnToCoordinates(Button btn)
        {
            int i = (btn.Left - defaultLeft) / squareSize;
            int j = (btn.Top - defaultTop) / squareSize;
            return (i, j);
        }

        public void OnPlanClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (state)
            {
                case PlanState.Locked:
                    break;
                case PlanState.Placing:
                    PlaceCurrShip(BtnToCoordinates(btn), true);
                    RefreshColors(); 
                    break;
                case PlanState.Standby:
                    RemoveShip(BtnToCoordinates(btn));
                    RefreshColors();
                    break;
                case PlanState.Hidden:
                    break;
                default:
                    break;
            }

        }

        public void OnPlanHover(object? sender, EventArgs? e)
        {
            RefreshColors();
            Button btn = (Button) (sender ?? lastlyHoveredOn);

            switch (state)
            {
                case PlanState.Locked:
                    break;
                case PlanState.Placing:
                    PlaceCurrShip(BtnToCoordinates(btn), false);
                    break;
                case PlanState.Standby:
                    break;
                case PlanState.Hidden:
                    break;
                default:
                    break;
            }
            lastlyHoveredOn = btn;
        }

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

        void ColorValidSquares(int i, int j, int modi, int modj, int length)
        {
            for (int x = 0; x < length; x++)
            {
                grid[i + (modi * x), j + (modj * x)].button.BackColor = Color.LimeGreen;
            }
        }

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

        bool IsPositionValid(int i, int j, int modi, int modj, int length)
        {
            for (int x = 0; x < length; x++)
            {
                if (!IsExistingSquare(i + (modi * x), j + (modj * x)) || grid[i + (modi * x), j + (modj * x)].State != SquareState.Free)
                    return false;
            }
            return true;
        }
        
        bool IsExistingSquare(int i, int j)
        {
            if (i > 9 || j > 9 || i < 0 || j < 0)
                return false;
            return true;
        }

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

        public void RotateCurrShip()
        {
            currentShip?.Rotate();
            OnPlanHover(null, null);
        }

        void RefreshColors()
        {
            foreach (var s in grid)
            {
                if (s.ship != null)
                    s.button.BackColor = Color.FromArgb(87, 36, 1);
                else
                    s.button.BackColor = Color.FromArgb(2, 12, 189);
            }
        }

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
                result.Append("\n");
            }
            return result.Remove(result.Length - 1, 1).ToString();
        }

        public void Resize()
        {
            int newLeft = (form.ClientRectangle.Width / 2) - (10 * squareSize);
            int newTop = (form.ClientRectangle.Height / 2) - (10 * squareSize);
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
