using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOLib;

namespace GOUnitTests
{
    [TestClass]
    public class Basic2DSimulationTest
    {
        /// <summary>
        /// Test a 2D grid with 3 live cells. Simulation should return 4 alive cells.
        /// todo: can be integrated with an Excel dataset to test multiple patterns.
        /// </summary>
        [TestMethod]
        public void Basic2D_3Live_Cell_Test()
        {
            IGoLFactory factory = new GolFactory();
            IGOLEngine engine = factory.CreateBasic2DGrid(4, 4);

            //setup initial live cells
            IMatrix grid = engine.Matrix;

            grid[0, 1].PrepareEvolvedState(true);
            grid[0, 1].ApplyEvolvedState();

            grid[1, 0].PrepareEvolvedState(true);
            grid[1, 0].ApplyEvolvedState();

            grid[1, 1].PrepareEvolvedState(true);
            grid[1, 1].ApplyEvolvedState();

            engine.StartSimulation();

            int aliveCtr = 0;
            foreach (ICell cell in grid)
            {
                if (cell.CurrentState == true) aliveCtr++;
            }

            Assert.AreEqual(4, aliveCtr);
        }
    }
}
