using ATM_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_EFCore.Events
{
    public static class EventHandler
    {
        public static void RecordDebitAlert(object sender, DebitEventArgs model)
        {
            Console.WriteLine("\nDebit Alert!");
            Console.WriteLine($"Amount: N{model.WithdrawalAmount:n}");
            Console.WriteLine($"Account: {model.AccountNumber}");
            Console.WriteLine($"Time: {DateTime.Now}");
        }

        public static void RecordCreditAlert(object sender, CreditEventArgs model)
        {
            Console.WriteLine("\nCredit Alert!");
            Console.WriteLine($"Account: {model.AccountNumber}");
            Console.WriteLine($"Amount: {model.DepositAmount:n}");
            Console.WriteLine($"A/C Balance: {model.AccountBalance:n}");
            Console.WriteLine($"Time: {DateTime.Now}");
        }
    }
}
