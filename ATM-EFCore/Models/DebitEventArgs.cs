using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_EFCore.Models
{
    public class DebitEventArgs : EventArgs
    {
        public int AccountNumber { get; set; }
        public int WithdrawalAmount { get; set; }
        public int AccountBalance { get; set; }
    }
}
