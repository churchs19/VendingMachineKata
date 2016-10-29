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

        [TestCategory("Accept Coin"), TestMethod]
        public void InitialDisplayReadsINSERTCOIN()
        {
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestCategory("Accept Coin"), TestMethod]
        public void InsertQuarter()
        {
            bool accepted = machine.InsertCoin("q");
            Assert.IsTrue(accepted);
            Assert.AreEqual(machine.Display, "$0.25");
        }

        [TestCategory("Accept Coin"), TestMethod]
        public void InsertDime()
        {
            bool accepted = machine.InsertCoin("d");
            Assert.IsTrue(accepted);
            Assert.AreEqual(machine.Display, "$0.10");
        }

        [TestCategory("Accept Coin"), TestMethod]
        public void InsertNickel()
        {
            bool accepted = machine.InsertCoin("n");
            Assert.IsTrue(accepted);
            Assert.AreEqual(machine.Display, "$0.05");
        }

        [TestCategory("Accept Coin"), TestMethod]
        public void InsertPenny()
        {
            bool accepted = machine.InsertCoin("p");
            Assert.IsFalse(accepted);
            Assert.AreEqual(1, machine.CoinReturn.Count);
            Assert.AreEqual("p", machine.CoinReturn[0]);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestCategory("Accept Coin"), TestMethod]
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
