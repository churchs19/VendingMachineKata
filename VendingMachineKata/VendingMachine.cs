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
            CoinReturn = new List<string>();
        }

        private double coinValue = 0;
        double selectedPrice = 0;
        bool purchased = false;
        public string Display
        {
            get
            {
                if(purchased)
                {
                    purchased = false;
                    return "THANK YOU";
                }
                if(selectedPrice > 0)
                {
                    var display = String.Format("PRICE {0:C2}", selectedPrice);
                    selectedPrice = 0;
                    return display;
                }
                return coinValue == 0 ? "INSERT COIN" : coinValue.ToString("C2");
            }
        }

        public List<string> CoinReturn { get; private set; }

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
            switch(product)
            {
                case Products.Cola:
                    selectedPrice = 1;
                    break;
                case Products.Chips:
                    selectedPrice = 0.50;
                    break;
                case Products.Candy:
                    selectedPrice = 0.65;
                    break;
            }
            if(coinValue >= selectedPrice)
            {
                coinValue = 0;
                selectedPrice = 0;
                purchased = true;
            }
        }
    }
}
