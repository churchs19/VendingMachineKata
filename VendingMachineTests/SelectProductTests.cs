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
            machine.SelectProduct(VendingMachine.Products.Cola);
            Assert.AreEqual("THANK YOU", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void PurchaseChipsNoFunds()
        {
            machine.SelectProduct(VendingMachine.Products.Chips);
            Assert.AreEqual("PRICE $0.50", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void PurchaseChipsInsufficientFunds()
        {
            machine.InsertCoin("q");
            machine.SelectProduct(VendingMachine.Products.Chips);
            Assert.AreEqual("PRICE $0.50", machine.Display);
            Assert.AreEqual("$0.25", machine.Display);
        }

        [TestMethod]
        public void PurchaseChips()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.SelectProduct(VendingMachine.Products.Chips);
            Assert.AreEqual("THANK YOU", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void PurchaseCandyNoFunds()
        {
            machine.SelectProduct(VendingMachine.Products.Candy);
            Assert.AreEqual("PRICE $0.65", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestMethod]
        public void PurchaseCandy()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("q");
            machine.InsertCoin("d");
            machine.InsertCoin("n");
            machine.SelectProduct(VendingMachine.Products.Candy);
            Assert.AreEqual("THANK YOU", machine.Display);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }
    }
}
