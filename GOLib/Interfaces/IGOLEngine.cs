using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    /// <summary>
    /// The simulation engine logic contract.
    /// </summary>
    public interface IGOLEngine
    {
        /// <summary>
        /// The current generation counter for a simulation
        /// </summary>
        int GenerationCounter { get; }

        /// <summary>
        /// The matrix for which simulation will be run
        /// </summary>
        IMatrix Matrix { get; }

        /// <summary>
        /// The evolution strategy to be used for simulation.
        /// </summary>
        IEvolutionStrategy EvolutionStrategy { get; }

        /// <summary>
        /// Starts the simulation for a matrix.
        /// </summary>
        void StartSimulation();
    }
}
