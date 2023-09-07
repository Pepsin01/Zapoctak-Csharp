using System.Windows.Forms;

namespace Ships_JosefLukasek
{
    /// <summary>
    /// Enumeration to represent the state of a square on the grid.
    /// </summary>
    public enum SquareState {
        Free,
        Occupied,
        Hit // The square has been hit by a shot.
    }
    /// <summary>
    /// Represents a square on the game plan grid.
    /// </summary>
    public class Square
    {
        SquareState state = SquareState.Free;

        /// <summary>
        /// The current state of the square.
        /// Setting the state to Occupied increases the occupation counter and setting it to Free decreases it.
        /// </summary>
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
        /// <summary>
        /// The button associated with the square.
        /// </summary>
        public Button button { get; }
        /// <summary>
        /// The ship occupying the square.
        /// </summary>
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
}
