using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOLib;
using NMock;

namespace GOUnitTests
{
    [TestClass]
    public class BasicGridTest
    {
        private static MockFactory mockFactory;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            mockFactory = new MockFactory();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Initialization_With_Negative_RowCount_Throws_Exception()
        {
            IMatrix matrix = new BasicGrid(-1, 10, mockFactory.CreateMock<INeighbourStrategy>().MockObject);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Initialization_With_Negative_ColCount_Throws_Exception()
        {
            IMatrix matrix = new BasicGrid(1, -1, mockFactory.CreateMock<INeighbourStrategy>().MockObject);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Initialization_With_Zero_RowCount_Throws_Exception()
        {
            IMatrix matrix = new BasicGrid(0, 10, mockFactory.CreateMock<INeighbourStrategy>().MockObject);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Initialization_With_Zero_ColCount_Throws_Exception()
        {
            IMatrix matrix = new BasicGrid(1, 0, mockFactory.CreateMock<INeighbourStrategy>().MockObject);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void Initialization_With_Million_RowAndColCount_Throws_Exception()
        {
            IMatrix matrix = new BasicGrid(1000000, 1000000, mockFactory.CreateMock<INeighbourStrategy>().MockObject);
        }

        [TestMethod]
        public void Initialize_4x4_Grid_Return_16_Cells()
        {
            IMatrix matrix = new BasicGrid(4, 4, mockFactory.CreateMock<INeighbourStrategy>().MockObject);

            int cellCount = 0;

            foreach (ICell cell in matrix)
            {
                cellCount++;
            }

            Assert.AreEqual(16, cellCount);
        }
    }
}
