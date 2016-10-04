using System;
using VendingMachineKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class AcceptCoinTests
    {
        private VendingMachine machine;

        [TestInitialize]
        public void Initialize()
        {
            machine = new VendingMachine();
        }

        [TestMethod]
        public void InitialDisplayReadsINSERTCOIN()
        {
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void InsertQuarter()
        {
            bool accepted = machine.InsertCoin("q");
            Assert.IsTrue(accepted);
            Assert.AreEqual(machine.Display, "$0.25");
        }
    }
}
