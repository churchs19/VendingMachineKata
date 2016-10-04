using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        public VendingMachine()
        {
            Display = "INSERT COIN";
        }

        public string Display { get; private set; }

        public bool InsertCoin(string coin)
        {
            return false;
        }
    }
}
