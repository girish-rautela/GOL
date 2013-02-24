using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLib;

namespace GOLife
{
    class Program
    {

        IMatrix grid;
        IGOLEngine engine;
        IGoLFactory gridFactory;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.StartSimulation();
        }

        public void StartSimulation()
        {
            int rowCount, colCount;
            Console.WriteLine("!!Game of Life Simulation!!");

            //get grid dimensions from the user
            GetGridDimensions(out rowCount, out colCount);

            //create a basic 2D grid using the grid factory
            gridFactory = new GolFactory();
            engine = gridFactory.CreateBasic2DGrid(rowCount, colCount);

            grid = engine.Matrix;

            //get intial live cell inputs from the user
            GetSeedInput(grid);

            Console.WriteLine("Starting Simulation. Press Esc to quit");

            printState();

            //run simulation until user presses [ESC] key.
            runSimulationInLoop();
        }

        private void GetGridDimensions(out int rowCount, out int colCount)
        {
            int? val1, val2;

            Console.Write("Enter the grid dimensions in the form of <rows>,<columns> :");
            string inputStr = Console.ReadLine();

            if (!ValidateInput(inputStr, out val1, out val2)) { GetGridDimensions(out rowCount, out colCount); return; }

            rowCount = (int)val1;
            colCount = (int)val2;
         }

        /// <summary>
        /// Gets the list of cells with inital alive state
        /// </summary>
        /// <param name="matrix"></param>
        private void GetSeedInput(IMatrix matrix)
        {
            int? val1, val2;

            Console.Write("Specify cells with initial state as alive. Press Enter to finish. Enter in the form on <row>,<column>:");
            String inputStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputStr)) return;

            if (!ValidateInput(inputStr, out val1, out val2)) { GetSeedInput(matrix); return; }

            matrix[(int)val1, (int)val2].PrepareEvolvedState(true);
            matrix[(int)val1, (int)val2].ApplyEvolvedState();

            GetSeedInput(matrix);
        }

        /// <summary>
        /// Validates and parses the users input
        /// </summary>
        /// <param name="inputStr">Input string as entered by the user. Should ne in the form of xx,xx</param>
        /// <param name="Val1">First integer value</param>
        /// <param name="Val2">Second integer value</param>
        /// <returns></returns>
        private bool ValidateInput(string inputStr, out int? Val1, out int? Val2)
        {
            Val1 = Val2 = null;
            int v1, v2;

            if (string.IsNullOrWhiteSpace(inputStr)) return false;

            if (inputStr.IndexOf(",") <= 0) return false;

            Val1 = (int.TryParse(inputStr.Split(',')[0], out v1)) ? (int?)v1 : null;
            Val2 = (int.TryParse(inputStr.Split(',')[1], out v2)) ? (int?)v2 : null;

            if (Val1 == null || Val2 == null) return false;

            return true;
        }

        /// <summary>
        /// Runs the simulation in a loop until users presses [ESC] key
        /// </summary>
        private void runSimulationInLoop()
        {
            engine.StartSimulation();

            Console.WriteLine("New state");
            printState();

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                runSimulationInLoop();
            }
        }

        /// <summary>
        /// Prints the cell state for the all the cells in the grid
        /// </summary>
        private void printState()
        {
            for (int i = 0; i < ((BasicGrid)grid).RowCount; i++)
            {
                for (int j = 0; j < ((BasicGrid)grid).ColCount; j++)
                {
                    Console.Write((grid[i, j].CurrentState) ? "LIVE " : "DEAD ");
                }
                Console.WriteLine();
            }
        }
    }
}
