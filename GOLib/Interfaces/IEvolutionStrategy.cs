using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    /// <summary>
    /// Defines the evolution logic for a cell.
    /// </summary>
    public interface IEvolutionStrategy
    {
        /// <summary>
        /// Evolves the cell to its new state.
        /// </summary>
        /// <param name="cell">Cell to be evolved.</param>
        void EvolveCell(ICell cell);
    }
}
