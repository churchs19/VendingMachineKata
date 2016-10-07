using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;

namespace VendingMachineTests
{
    [TestClass]
    public class ReturnCoinsTests
    {
        private VendingMachine machine;

        [TestInitialize]
        public void Initialize()
        {
            machine = new VendingMachine();
        }

        [TestCategory("Return Coins"), TestMethod]
        public void NoCoinsEntered()
        {
            machine.ReturnCoins();
            Assert.AreEqual(0, machine.CoinReturn.Count);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

        [TestCategory("Return Coins"), TestMethod]
        public void ReturnOneCoin()
        {
            machine.InsertCoin("q");
            machine.ReturnCoins();
            Assert.AreEqual(1, machine.CoinReturn.Count);
            Assert.AreEqual("q", machine.CoinReturn[0]);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }


        [TestCategory("Return Coins"), TestMethod]
        public void ReturnMultipleCoins()
        {
            machine.InsertCoin("q");
            machine.InsertCoin("d");
            machine.InsertCoin("n");
            machine.ReturnCoins();
            Assert.AreEqual(3, machine.CoinReturn.Count);
            Assert.AreEqual("q", machine.CoinReturn[0]);
            Assert.AreEqual("d", machine.CoinReturn[1]);
            Assert.AreEqual("n", machine.CoinReturn[2]);
            Assert.AreEqual("INSERT COIN", machine.Display);
        }

    }
}
