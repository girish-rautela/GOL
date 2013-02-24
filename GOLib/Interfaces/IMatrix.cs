using System.Collections.Generic;

namespace GOLib
{
    /// <summary>
    /// Represents a collection of Cells that can be enumerated. 
    /// Use this to create grids and other types of containers
    /// </summary>
    public interface IMatrix : IEnumerable<ICell>
    {
        /// <summary>
        /// Gets the Neighbour finding strategy.
        /// </summary>
        INeighbourStrategy NeighbourStrategy { get; }

        /// <summary>
        /// Return the list of neighbours for a given cell.
        /// </summary>
        /// <param name="cell">The target cell.</param>
        /// <returns>List of cells.</returns>
        IList<ICell> GetNeighbours(ICell cell);

        
        /// <summary>
        /// Indexer that gets the cell for a given coordinate.
        /// todo: since genric indexers are not supported, this shoud ideally be implemented either as a coordinate system or as a method
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="colNumber"></param>
        /// <returns></returns>
        ICell this [int rowNumber, int colNumber] {get;}

    }
}
