using System;
using VendingMachineKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class SelectProductTests
    {
        private VendingMachine machine;

        [TestInitialize]
        public void Initialize()
        {
            machine = new VendingMachine();
        }

        [TestMethod]
        public void PurchaseColaNoFunds()
        {
            machine.SelectProduct(VendingMachine.Products.Cola);
            Assert.AreEqual("PRICE $1.00", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void PurchaseColaInsufficientFunds()
        {
            machine.InsertCoin("d");
            machine.SelectProduct(VendingMachine.Products.Cola);
            Assert.AreEqual("PRICE $1.00", machine.Display);
            Assert.AreEqual("$0.10", machine.Display);
        }

        [TestMethod]
        public void PurchaseCola()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            Assert.AreEqual("THANK YOU", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void PurchaseChips()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void PurchaseCandy()
        {
            Assert.Fail();
        }
    }
}
