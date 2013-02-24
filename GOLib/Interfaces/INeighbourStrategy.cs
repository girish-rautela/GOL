using System.Collections.Generic;

namespace GOLib
{
    /// <summary>
    /// Define the logic for identifying neighbours for a cell in the matrix
    /// </summary>
    public interface INeighbourStrategy
    {
        /// <summary>
        /// Return the list of neighbouring cells for a target cell.
        /// </summary>
        /// <param name="cell">Target cell</param>
        /// <returns>List of neighbouring cells.</returns>
        IList<ICell> FindNeighbours(ICell cell);
    }
}
