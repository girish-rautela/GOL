using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    public class BasicGridNeighbourStrategy : INeighbourStrategy
    {
        /// <summary>
        /// Finds Neighbouring cells for a 2D Grid
        /// </summary>
        /// <param name="TargetCell">Cell for which neighbours are to be searched</param>
        /// <returns>List of neighbouring cells</returns>
        public IList<ICell> FindNeighbours(ICell TargetCell)
        {
            BasicGrid grid = (BasicGrid)TargetCell.Parent;
            Cell cell = (Cell)TargetCell;

            //get the relevant set of nine cells.
            int startRow = (cell.RowNumber >0) ? cell.RowNumber -1 : cell.RowNumber;
            int endRow = (cell.RowNumber<grid.RowCount-1) ? cell.RowNumber+1: cell.RowNumber;
            int startCol = (cell.ColumnNumber >0) ? cell.ColumnNumber -1: cell.ColumnNumber;
            int endCol = (cell.ColumnNumber <grid.ColCount-1) ? cell.ColumnNumber+1 : cell.ColumnNumber;

            IList<ICell> cellList = new List<ICell>();

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (i != cell.RowNumber || j != cell.ColumnNumber)  //don't count the target cell itself
                        cellList.Add(grid[i, j]);
                }
            }

            return cellList;
        }
    }
}
