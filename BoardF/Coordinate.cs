using System.Collections.Generic;

namespace BoardF
{
    internal struct Coordinate
    {
        /// <summary>
        /// The coordinate X of the board cell.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The coordinate Y of the board cell.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="x">The coordinate X of the board cell.</param>
        /// <param name="y">The coordinate Y of the board cell.</param>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// The class constuctor.
        /// Create the last cell on the board.
        /// </summary>
        /// <param name="size">The size of the game board.</param>
        public Coordinate(int size)
        {
            X = size - 1;
            Y = size - 1;
        }

        /// <summary>
        /// Is there the cell with the X, Y coordinates on the game board?
        /// </summary>
        /// <param name="size">The size of the game board.</param>
        /// <returns>Yes | No.</returns>
        public bool OnBoard(int size)
        {
            bool isOnBoard = (X < 0 || X > size - 1) || (Y < 0 || Y > size - 1);

            return !isOnBoard;
        }

        /// <summary>
        /// Iterating over all cells on the board.
        /// At the output, we immediately get the cell with x, y.
        /// </summary>
        /// <param name="size">The size of the game board.</param>
        /// <returns>The cell with x, y.</returns>
        public IEnumerable<Coordinate> YieldCoordinate(int size)
        {
            for (Y = 0; Y < size; Y++)
            {
                for (X = 0; X < size; X++)
                {
                    yield return this;
                }
            }
        }

        /// <summary>
        /// Getting the new coordinate of the cell from the old coordinate.
        /// </summary>
        /// <param name="sx">The old coordinate X.</param>
        /// <param name="sy">The old coordinate Y.</param>
        /// <returns>The new coordinate.</returns>
        public Coordinate Add(int sx, int sy)
        {
            return new Coordinate(X + sx, Y + sy);
        }
    }
}
