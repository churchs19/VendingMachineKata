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
            insertedCoins = new List<string>();
        }

        private List<string> insertedCoins;
        private double coinValue = 0;
        double selectedPrice = 0;
        bool purchased = false;
        public string Display
        {
            get
            {
                if (purchased)
                {
                    purchased = false;
                    return "THANK YOU";
                }
                if (selectedPrice > 0)
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
            switch (coin)
            {
                case "q":
                    coinValue += 0.25;
                    insertedCoins.Add("q");
                    return true;
                case "d":
                    coinValue += 0.10;
                    insertedCoins.Add("d");
                    return true;
                case "n":
                    coinValue += 0.05;
                    insertedCoins.Add("n");
                    return true;
                default:
                    CoinReturn.Add(coin);
                    return false;
            }
        }

        public void SelectProduct(Products product)
        {
            switch (product)
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
            if (coinValue >= selectedPrice)
            {
                var changeAmount = Math.Round(coinValue - selectedPrice, 2);
                coinValue = 0;
                selectedPrice = 0;
                purchased = true;
                MakeChange(changeAmount);
            }
        }

        public void ReturnCoins()
        {
            CoinReturn.AddRange(insertedCoins);
            insertedCoins.Clear();
            coinValue = 0;
        }

        private void MakeChange(double amount)
        {
            if (amount >= 0.25)
            {
                CoinReturn.Add("q");
                amount -= 0.25;
            }
            else if (amount >= 0.10)
            {
                CoinReturn.Add("d");
                amount -= 0.10;
            }
            else if (amount >= 0.05)
            {
                CoinReturn.Add("n");
                amount -= 0.05;
            }

            amount = Math.Round(amount, 2);
            if (amount > 0)
            {
                MakeChange(amount);
            }
        }
    }
}
