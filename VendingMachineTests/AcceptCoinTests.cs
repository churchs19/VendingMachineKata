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

        [TestMethod]
        public void InsertDime()
        {
            bool accepted = machine.InsertCoin("d");
            Assert.IsTrue(accepted);
            Assert.AreEqual(machine.Display, "$0.10");
        }

        [TestMethod]
        public void InsertNickel()
        {
            bool accepted = machine.InsertCoin("n");
            Assert.IsTrue(accepted);
            Assert.AreEqual(machine.Display, "$0.05");
        }

        [TestMethod]
        public void InsertPenny()
        {
            bool accepted = machine.InsertCoin("p");
            Assert.IsFalse(accepted);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void InsertQuarterDimeNickelAndPenny()
        {
            bool accepted = machine.InsertCoin("q");
            Assert.IsTrue(accepted);
            accepted = machine.InsertCoin("d");
            Assert.IsTrue(accepted);
            accepted = machine.InsertCoin("n");
            Assert.IsTrue(accepted);
            accepted = machine.InsertCoin("p");
            Assert.IsFalse(accepted);
            Assert.AreEqual("$0.40", machine.Display);
        }

    }
}
