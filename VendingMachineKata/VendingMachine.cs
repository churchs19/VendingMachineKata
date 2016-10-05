using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        public enum Products
        {
            Cola,
            Chips,
            Candy
        }

        public VendingMachine()
        {
        }

        private double coinValue = 0;
        public string Display
        {
            get
            {
                return coinValue == 0 ? "INSERT COIN" : coinValue.ToString("C2");
            }
        }

        public bool InsertCoin(string coin)
        {
            switch(coin)
            {
                case "q":
                    coinValue += 0.25;
                    return true;
                case "d":
                    coinValue += 0.10;
                    return true;
                case "n":
                    coinValue += 0.05;
                    return true;
                default:
                    return false;
            }
        }

        public void SelectProduct(Products product)
        {

        }
    }
}
