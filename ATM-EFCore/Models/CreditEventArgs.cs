using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_EFCore.Models
{
    public class CreditEventArgs : EventArgs
    {
        public int AccountNumber { get; set; }
        public int DepositAmount { get; set; }
        public int AccountBalance { get; set; }
    }
}
