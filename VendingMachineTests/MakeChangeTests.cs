using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;

namespace VendingMachineTests
{
    [TestClass]
    public class MakeChangeTests
    {
        private VendingMachine machine;

        [TestInitialize]
        public void Initialize()
        {
            machine = new VendingMachine();
        }

        [TestCategory("Make Change"), TestMethod]
        public void NoChange()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("d");
            machine.InsertCoin("n");
            machine.SelectProduct(VendingMachine.Products.Candy);
            Assert.AreEqual(0, machine.CoinReturn.Count);
        }

        [TestCategory("Make Change"), TestMethod]
        public void SingleDimeChange()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.SelectProduct(VendingMachine.Products.Candy);
            Assert.AreEqual(1, machine.CoinReturn.Count);
            Assert.AreEqual("d", machine.CoinReturn[0]);
        }

        [TestCategory("Make Change"), TestMethod]
        public void QuarterDimeChange()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.SelectProduct(VendingMachine.Products.Candy);
            Assert.AreEqual(2, machine.CoinReturn.Count);
            Assert.AreEqual("q", machine.CoinReturn[0]);
            Assert.AreEqual("d", machine.CoinReturn[1]);
        }
    }
}
