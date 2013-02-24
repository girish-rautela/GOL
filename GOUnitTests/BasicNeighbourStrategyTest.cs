using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOLib;
using NMock;

namespace GOUnitTests
{
    [TestClass]
    public class BasicNeighbourStrategyTest
    {
        [TestMethod]
        public void Baisc_4x4_Grid_1st_Cell_Returns_3_Neighbours()
        {
            IMatrix grid = new BasicGrid(4, 4, new BasicGridNeighbourStrategy());

            Assert.AreEqual(3, grid.GetNeighbours(grid[0, 0]).Count);
        }

        [TestMethod]
        public void Baisc_4x4_Grid_Last_Cell_Returns_3_Neighbours()
        {
            IMatrix grid = new BasicGrid(4, 4, new BasicGridNeighbourStrategy());

            Assert.AreEqual(3, grid.GetNeighbours(grid[3, 3]).Count);
        }

        [TestMethod]
        public void Baisc_4x4_Grid_Mid_Cell_Returns_8_Neighbours()
        {
            IMatrix grid = new BasicGrid(4, 4, new BasicGridNeighbourStrategy());

            Assert.AreEqual(8, grid.GetNeighbours(grid[2, 2]).Count);
        }
    }
}
