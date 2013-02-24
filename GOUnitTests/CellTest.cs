using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOLib;

namespace GOUnitTests
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void Cell_With_Optional_State_Defaults_to_Dead()
        {
            ICell cell = new Cell(1, 1);

            Assert.AreEqual(cell.CurrentState, false);
        }

        [TestMethod]
        public void Cell_With_Prepared_Evolved_State_Does_Not_Change_Current_State()
        {
            ICell cell = new Cell(1, 1);

            cell.PrepareEvolvedState(true);

            Assert.AreEqual(cell.CurrentState, false);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cell_Without_Prepared_State_Throws_Error_On_Apply_Evolved_State()
        {
            ICell cell = new Cell(1, 1);

            cell.ApplyEvolvedState();
        }

        [TestMethod]
        public void Cell_With_Apply_Evolved_State_Changes_Current_State()
        {
            ICell cell = new Cell(1, 1);
            Assert.AreEqual(cell.CurrentState, false);

            cell.PrepareEvolvedState(true);
            Assert.AreEqual(cell.CurrentState, false);

            cell.ApplyEvolvedState();
            Assert.AreEqual(cell.CurrentState, true);
        }
    }
}
