using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLib
{
    /// <summary>
    /// Provides easy access to create and setup simulation engines
    /// </summary>
    public interface IGoLFactory
    {
        /// <summary>
        /// Creates a Basic 2D grid
        /// todo: can actually be setup as a generic contract with XML config based setup
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <returns></returns>
        IGOLEngine CreateBasic2DGrid(int rowCount, int colCount);
    }
}
