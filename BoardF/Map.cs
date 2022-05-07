namespace BoardF
{
    /// <summary>
    /// The board struct.
    /// </summary>
    internal struct Map
    {
        /// <summary>
        /// The size of the board.
        /// </summary>
        readonly int size;

        /// <summary>
        /// The array of the board cells.
        /// </summary>
        readonly int[,] map;

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="size">The size of the board.</param>
        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        /// <summary>
        /// Set the new value to the coordinate XY.
        /// </summary>
        /// <param name="xy">The coordinate XY.</param>
        /// <param name="value">The new value.</param>
        public void Set(Coordinate xy, int value)
        {
            if (xy.OnBoard(size))
            {
                map[xy.X, xy.Y] = value;
            }
        }

        /// <summary>
        /// Getting the number of the cell by the coordinate XY.
        /// </summary>
        /// <param name="xy">The coordinate XY.</param>
        /// <returns>The number of the cell.</returns>
        public int Get(Coordinate xy)
        {
            return xy.OnBoard(size) ? map[xy.X, xy.Y] : 0;
        }

        /// <summary>
        /// Set the coordinate "to" as the coordinate "from".
        /// </summary>
        /// <param name="from">The coordinate "from".</param>
        /// <param name="to">The coordinate "to".</param>
        public void Copy(Coordinate from, Coordinate to)
        {
            Set(to, Get(from));
        }
    }
}
