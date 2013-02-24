using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    /// <summary>
    /// Simulation for 2D grid
    /// </summary>
    public class BasicGridSimulator : IGOLEngine
    {
        /// <summary>
        /// Gets the current generation run for the simulation
        /// </summary>
        public int GenerationCounter { get; private set; }

        /// <summary>
        /// Gets the matrix for the simulation
        /// </summary>
        public IMatrix Matrix { get; private set; }

        /// <summary>
        /// Gets the evolution strategy for the simulation
        /// </summary>
        public IEvolutionStrategy EvolutionStrategy { get; private set; }

        public BasicGridSimulator(IMatrix matrix, IEvolutionStrategy evolutionStrategy)
        {
            Matrix = matrix;
            EvolutionStrategy = evolutionStrategy;

            GenerationCounter = 0;
        }

        /// <summary>
        /// Execute a single step evolution cycle
        /// </summary>
        public void StartSimulation()
        {
            foreach(Cell cell in Matrix)
            {
                EvolutionStrategy.EvolveCell(cell);
            }

            foreach (Cell cell in Matrix)
            {
                cell.ApplyEvolvedState();
            }

            GenerationCounter++;
        }
    }
}
