using System;
namespace GOLib
{
    /// <summary>
    /// Defines a contract for Cell implementation.
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Gets or Sets the parent container for this cell.
        /// </summary>
        IMatrix Parent { get; set; }

        /// <summary>
        /// Gets the current state of the cell
        /// </summary>
        bool CurrentState { get; }

        /// <summary>
        /// Prepares the new state of the cell. Current state is not changed until ApplyEvolvedState is called.
        /// </summary>
        /// <param name="newState">New state of the cell.</param>
        void PrepareEvolvedState(bool newState);
        /// <summary>
        /// Applies the prepared state.
        /// </summary>
        void ApplyEvolvedState();
    }
}
