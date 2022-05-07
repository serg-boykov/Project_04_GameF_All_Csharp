using System;

namespace BoardF
{
    public class Game
    {
        /// <summary>
        /// The size of the board.
        /// </summary>
        readonly int size;

        /// <summary>
        /// The board with the (size x size) cells.
        /// </summary>
        readonly Map map;

        /// <summary>
        /// The empty cell.
        /// </summary>
        Coordinate space;

        /// <summary>
        /// For calculating moves.
        /// </summary>
        public int Moves { get; private set; }


        /// <summary>
        /// Creating the game.
        /// </summary>
        /// <param name="size">The size of the board is one coordinate.</param>
        public Game(int size)
        {
            this.size = size;
            this.map = new Map(size);
        }

        /// <summary>
        /// Fill all the cells on the board.
        /// </summary>
        /// <param name="seed">The number of mixing. 
        /// If larger then cooler the mixing level. 
        /// If 0 then no mixing.</param>
        public void Start(int seed = 0)
        {
            int digit = 0;

            // Filling out cells.
            foreach (Coordinate xy in new Coordinate().YieldCoordinate(size))
            {
                map.Set(xy, ++digit);
            }

            // At the end we create the empty cell through the class constructor.
            space = new Coordinate(size);

            // Mix the cells.
            if (seed > 0)
            {
                Shuffle(seed);
            }

            // We will count the moves.
            Moves = 0;
        }

        /// <summary>
        /// Mix the cells.
        /// </summary>
        /// <param name="seed">The number of mixing.</param>
        private void Shuffle(int seed)
        {
            Random random = new Random(seed);

            for (int i = 0; i < seed; i++)
            {
                PressAt(random.Next(size), random.Next(size));
            }
        }

        /// <summary>
        /// Click on the cell with the coordinate XY to move it.
        /// </summary>
        /// <param name="xy">The coordinate XY.</param>
        /// <returns>The number of steps per click.</returns>
        private int PressAt(Coordinate xy)
        {
            if (space.Equals(xy))
            {
                return 0;
            }

            // Click diagonally.
            if (space.X != xy.X && space.Y != xy.Y)
            {
                return 0;
            }

            // The number of steps per click.
            int steps = Math.Abs(xy.X - space.X) + Math.Abs(xy.Y - space.Y);

            // We can move several horizontal cells at once.
            while (space.X != xy.X)
            {
                Shift(Math.Sign(xy.X - space.X), 0);
            }

            // We can move several cells vertically at once.
            while (space.Y != xy.Y)
            {
                Shift(0, Math.Sign(xy.Y - space.Y));
            }

            Moves += steps;

            return steps;
        }

        /// <summary>
        /// The cell shift.
        /// </summary>
        /// <param name="sx">Adding shift by coordinate X.</param>
        /// <param name="sy">Adding shift by coordinate Y.</param>
        private void Shift(int sx, int sy)
        {
            Coordinate next = space.Add(sx, sy);
            map.Copy(next, space); // map[space] := map[next] as an example
            space = next;
        }

        /// <summary>
        /// Click on the cell with the coordinate x and y to move it.
        /// </summary>
        /// <param name="x">The coordinate X.</param>
        /// <param name="y">The coordinate Y.</param>
        /// <returns>Click on the cell with the coordinate XY to move it.</returns>
        public int PressAt(int x, int y)
        {

            return PressAt(new Coordinate(x, y));
        }

        /// <summary>
        /// Getting the number of the cell by the coordinate XY.
        /// </summary>
        /// <param name="xy">The coordinate XY.</param>
        /// <returns>The number.</returns>
        private int GetDigitAt(Coordinate xy)
        {
            if (space.Equals(xy))
            {
                return 0;
            }

            return map.Get(xy);
        }

        /// <summary>
        /// Getting the number of the cell by the coordinates X and Y.
        /// </summary>
        /// <param name="x">The coordinate X.</param>
        /// <param name="y">The coordinate Y.</param>
        /// <returns>Getting the number by the coordinate XY.</returns>
        public int GetDigitAt(int x, int y)
        {

            return GetDigitAt(new Coordinate(x, y));
        }

        /// <summary>
        /// Is the game over?
        /// </summary>
        /// <returns>Yes | No.</returns>
        public bool Solved()
        {
            // If the empty cell is not at the end of the board.
            if (!space.Equals(new Coordinate(size)))
            {
                return false;
            }

            int digit = 0;

            // Loop through all the cells.
            foreach (Coordinate xy in new Coordinate().YieldCoordinate(size))
            {
                if (map.Get(xy) != ++digit)
                {
                    return space.Equals(xy);
                }
            }

            return true;
        }
    }
}
