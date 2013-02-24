using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    /// <summary>
    /// Representation of a single cell within a matrix
    /// </summary>
    public class Cell : ICell
    {
        public IMatrix Parent {get; set; }

        private bool? EvolvedState { get; set; }
        
        public int RowNumber { get; private set; }
        public int ColumnNumber { get; private set; }
        public bool CurrentState { get; private set; }
        

        public Cell(int rowNum, int colNum, bool initialState = false)
        {
            RowNumber = rowNum;
            ColumnNumber = colNum;
            CurrentState = initialState;
        }

        /// <summary>
        /// Prepare the new evolved state of the cell. The new state is not applied until ApplyEvolvedState is called.
        /// </summary>
        /// <param name="newState">New state of the cell.</param>
        public void PrepareEvolvedState(bool newState)
        {
            EvolvedState = newState;
        }

        /// <summary>
        /// Sets the evolved state of the cell. 
        /// </summary>
        public void ApplyEvolvedState()
        {
            if (EvolvedState == null)
                throw new InvalidOperationException("Evolved State not defined.");
            
            CurrentState = (bool) EvolvedState;
        }
    }
}
