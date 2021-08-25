using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_EFCore
{
    public static class Translation
    {
        public static void EnglishPromptPin()
        {
            Console.WriteLine("\nInsert PIN");
        }

        public static void PidginPromptPin()
        {
            Console.WriteLine("\nChook ya PIN");
        }

        public static void IgboPromptPin()
        {
            Console.WriteLine("\nTinye PIN gi");
        }

        public static void EnglishPromptOperation()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Withdrawal\n2. Check Balance\n3. Quit");
        }
        
        public static void PidginPromptOperation()
        {
            Console.WriteLine("\nWetin you wan do?");
            Console.WriteLine("1. Collect Money\n2. Check How Much You Get\n3. Commot");
        }
        
        public static void IgboPromptOperation()
        {
            Console.WriteLine("\nKe Ihe Ichoro Ime?");
            Console.WriteLine("1. Were Ego\n2. Le Ego Di N'aha Gi\n3. Puo");
        }

        public static void EnglishOperationErrorMessage()
        {
            Console.WriteLine("Invalid Selection!\n");
        }
        
        public static void PidginOperationErrorMessage()
        {
            Console.WriteLine("Wetin you press no follow o!\n");
        }
        
        public static void IgboOperationErrorMessage()
        {
            Console.WriteLine("Fichaa anya pinye ya ozo!\n");
        }
        
        public static string EnglishWithdrawalErrorMessage()
        {
            return "\nPlease enter multiples of N1,000 or N500";
        }
        
        public static string EnglishWithdrawalSuccessMessage()
        {
            return "withdrawal is successful!";
        }
        
        public static string PidginWithdrawalSuccessMessage()
        {
            return "cash go well!";
        }
        
        public static string IgboWithdrawalSuccessMessage()
        {
            return "putara ofuma!";
        }
        
        public static void EnglishWithdrawalPrompt()
        {
            Console.WriteLine("\nPlease select an option\n1. 5,000\n2. 10,000\n3. 20,000\n4. Enter Amount");
        }

        public static string PidginWithdrawalErrorMessage()
        {
           return "\nNa only 1k or 5h we dey pay o!";
        }

        public static void PidginWithdrawalPrompt()
        {
            Console.WriteLine("\nHow much you want?\n1. 5,000\n2. 10,000\n3. 20,000\n4. Chook Your Own Amount");
        
        }public static string IgboWithdrawalErrorMessage()
        {
            return "\nSoo N1,000 ma obu N500 k'anyi nwere!";
        }

        public static void IgboWithdrawalPrompt()
        {
            Console.WriteLine("\nEgo Ole Ka Ichoro\n1. 5,000\n2. 10,000\n3. 20,000\n4. Pinye Ego Ole Ichoro");
        }

        public static string EnglishInsuffientFunds()
        {
            return "Insufficient funds";
        }
        
        public static string IgboInsuffientFunds()
        {
            return "Inwero Ego!";
        }
        
        public static string PidginInsuffientFunds()
        {
            return "You No Get Money!";
        }

        public static string EnglishDispenseError()
        {
            return "Temporarily, Unable To Dispense Cash!";
        }
        
        public static string PidginDispenseError()
        {
            return "We No Get Cash To Waya You!";
        }

        public static string IgboDispenseError()
        {
            return "Ego Anyi Agwu Go";
        }
    }
}
