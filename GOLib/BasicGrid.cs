using System;
using System.Collections.Generic;

namespace GOLib
{
    /// <summary>
    /// Baisc 2D array based implementation of the Matrix
    /// </summary>
    public class BasicGrid : IMatrix, IEnumerable<ICell>
    {
        private ICell[,] _cells;

        /// <summary>
        /// Gets the neighbour finding strategy for the basic grid.
        /// </summary>
        public INeighbourStrategy NeighbourStrategy { get; private set; }

        /// <summary>
        /// Constructor to create and initialize 2D grid of cells
        /// </summary>
        /// <param name="rowCount">Number of Rows</param>
        /// <param name="colCount">Number of Columns</param>
        public BasicGrid(int rowCount, int colCount, INeighbourStrategy neighbourStrategy)
        {
            if (rowCount <= 0 || colCount<=0)
            {
                throw new ArgumentOutOfRangeException("Row and Column count have to be greater than zero");
            }

            RowCount = rowCount;
            ColCount = colCount;
            NeighbourStrategy = neighbourStrategy;

            try
            {
                _cells = new ICell[rowCount, colCount];
            }
            catch (OutOfMemoryException) { throw; }

            InitializeCells(rowCount, colCount);
        }

        /// <summary>
        /// Initialized the cells to all dead state
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        private void InitializeCells(int rowCount, int colCount)
        {
            //initialize all individual cells
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    _cells[i, j] = new Cell(i, j) { Parent = this };
                }
            }
        }

        /// <summary>
        /// Number of Rows in the grid.
        /// </summary>
        public int RowCount { get; private set; }

        /// <summary>
        /// Number of Columns in the grid.
        /// </summary>
        public int ColCount { get; private set; }

        /// <summary>
        /// Return the cell at the given row and column
        /// </summary>
        /// <param name="rowNum">Row Number.</param>
        /// <param name="colNum">Column Number.</param>
        /// <returns></returns>
        public ICell this [int rowNum, int colNum]
        {
            get{
                return _cells[rowNum, colNum];
            }
        }

        #region IMatrix memebers
        /// <summary>
        /// Gets the list of neighbouring cells
        /// </summary>
        /// <param name="cell">The cell for wihch neighbours will be searched.</param>
        /// <returns>List of ICells</returns>
        public IList<ICell> GetNeighbours(ICell cell)
        {

            return NeighbourStrategy.FindNeighbours(cell);
        }
        

        public IEnumerator<ICell> GetEnumerator()
        {
            int currentRow = 0, currentCol = -1;

            while (currentRow < RowCount-1 || currentCol < ColCount-1)
            {
                currentCol++;

                if (currentCol == ColCount)
                {
                    currentRow++;
                    currentCol = 0;
                }

                yield return (ICell)_cells[currentRow,currentCol];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
        
        #endregion
    }
}
