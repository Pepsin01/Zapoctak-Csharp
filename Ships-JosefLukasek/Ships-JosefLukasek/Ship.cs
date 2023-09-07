namespace Ships_JosefLukasek
{
    /// <summary>
    /// Enumeration to specify the direction of the ship.
    /// </summary>
    public enum ShipDir {
        Down,
        Up,
        Left,
        Right
    }

    /// <summary>
    /// Represents a game plan grid.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Current direction of the ship.
        /// </summary>
        public ShipDir dir { get; private set; }

        /// <summary>
        /// Length of the ship.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Array to store the squares occupied by the ship.
        /// </summary>
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
}
