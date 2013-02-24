using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    public class BasicGridEvolutionStrategy : IEvolutionStrategy
    {
        /// <summary>
        /// Prepares the evolved state for a cell. Does not update the current state.
        /// </summary>
        /// <param name="cell">Target cell</param>
        public void EvolveCell(ICell cell)
        {
            int aliveCount = cell.Parent.GetNeighbours(cell).Where(p => p.CurrentState == true).Count();

            if ((cell.CurrentState == true && (aliveCount == 2 || aliveCount == 3)) || (cell.CurrentState == false && aliveCount == 3))
            {
                cell.PrepareEvolvedState(true);
            }
            else
            {
                cell.PrepareEvolvedState(false);
            }
        }
    }
}
