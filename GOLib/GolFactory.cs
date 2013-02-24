using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    public class GolFactory : IGoLFactory
    {
        public IGOLEngine CreateBasic2DGrid(int rowCount, int colCount)
        {
            
            IMatrix matrix = new BasicGrid(rowCount, colCount, new BasicGridNeighbourStrategy());
            IGOLEngine engne = new BasicGridSimulator(matrix, new BasicGridEvolutionStrategy());

            return engne;
        }
    }
}
