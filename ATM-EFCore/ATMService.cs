using ATM_EFCore.Events;
using ATM_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_DAL;
using ATM_DAL.Model;

namespace ATM_EFCore
{
    public class ATMService
    {
        public event EventHandler<DebitEventArgs> DebitAlert;
        public event EventHandler<CreditEventArgs> CreditAlert;

        private static ATMContext context = new ATMContext();
        private static int _vault = 500000;
        private static User _user;

        public void Register(User model)
        {
            context.Users.Add(model);
            context.SaveChanges();
            Console.WriteLine($"\n{model.Name}, has been registered successfully!");
            Console.ForegroundColor = ConsoleColor.Green;

            var creditArgs = new CreditEventArgs()
            {
                AccountNumber = model.AccountNumber,
                DepositAmount = model.AccountBalance,
                AccountBalance = model.AccountBalance
            };
            
            OnCredit(creditArgs);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ValidatePinEnglish(bool isLoggedIn)
        {
            while (!isLoggedIn)
            {
                Translation.EnglishPromptPin();
                string PIN = Application.RequestPIN();

                while (string.IsNullOrWhiteSpace(PIN))
                {
                    Translation.EnglishPromptPin();
                    PIN = Application.RequestPIN();
                }

                isLoggedIn = IsValidated(PIN, _user.Pin);
                if (!isLoggedIn)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nIncorrect PIN!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine($"\n\nWelcome {_user.Name}!");
        }

        public static void ValidatePinPidgin(bool isLoggedIn)
        {
            while (!isLoggedIn)
            {
                Translation.PidginPromptPin();
                string PIN = Application.RequestPIN();

                while (string.IsNullOrWhiteSpace(PIN))
                {
                    Translation.PidginPromptPin();
                    PIN = Application.RequestPIN();
                }

                isLoggedIn = IsValidated(PIN, _user.Pin);
                if (!isLoggedIn)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDis PIN no legit!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine($"\n\nWelcome {_user.Name}!");
        }
        
        public static void ValidatePinIgbo(bool isLoggedIn)
        {
            while (!isLoggedIn)
            {
                Translation.IgboPromptPin();
                string PIN = Application.RequestPIN();

                while (string.IsNullOrWhiteSpace(PIN))
                {
                    Translation.IgboPromptPin();
                    PIN = Application.RequestPIN();
                }

                isLoggedIn = IsValidated(PIN, _user.Pin);
                if (!isLoggedIn)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPIN a adaba ro!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine($"\n\nNnoo {_user.Name}!");
        }

        public static int CheckBalance()
        {
            return _user.AccountBalance;
        }

        public void WithdrawalHandler(int amount, string successMessage, string errorMessage, string insufficientFunds, string outOfCash)
        {
            int withdrawalAmount = amount;
            if (withdrawalAmount % 1000 == 0 || withdrawalAmount % 500 == 0)
            {
                if(withdrawalAmount <= _user.AccountBalance)
                {
                    if (withdrawalAmount <= _vault)
                    {
                        _user.AccountBalance -= withdrawalAmount;
                        _vault -= withdrawalAmount;
                        Console.WriteLine($"\nN{withdrawalAmount:n} {successMessage}");
                        var debitArgs = new DebitEventArgs()
                        {
                            AccountBalance = _user.AccountBalance,
                            WithdrawalAmount = withdrawalAmount,
                            AccountNumber = _user.AccountNumber
                        };

                        Console.ForegroundColor = ConsoleColor.Red;
                        OnDebit(debitArgs);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine($"{outOfCash}");
                    }
                }
                else
                {
                    Console.WriteLine($"{insufficientFunds}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{errorMessage}");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public static int EnglishWithdrawalOption()
        {
            Translation.EnglishWithdrawalPrompt();
            string option = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(option) || (option != "1" && option != "2" && option != "3" && option != "4"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Translation.EnglishOperationErrorMessage();
                Console.ForegroundColor = ConsoleColor.White;
                Translation.EnglishWithdrawalPrompt();
                option = Console.ReadLine().Trim();
            }

            return EnglishMatchWithdrawalOption(option);
        }
        
        public static int PidginWithdrawalOption()
        {
            Translation.PidginWithdrawalPrompt();
            string option = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(option) || (option != "1" && option != "2" && option != "3" && option != "4"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Translation.PidginOperationErrorMessage();
                Console.ForegroundColor = ConsoleColor.White;
                Translation.PidginWithdrawalPrompt();
                option = Console.ReadLine().Trim();
            }

            return PidginMatchWithdrawalOption(option);
        }
        
        public static int IgboWithdrawalOption()
        {
            Translation.IgboWithdrawalPrompt();
            string option = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(option) || (option != "1" && option != "2" && option != "3" && option != "4"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Translation.IgboOperationErrorMessage();
                Console.ForegroundColor = ConsoleColor.White;
                Translation.IgboWithdrawalPrompt();
                option = Console.ReadLine().Trim();
            }

            return IgboMatchWithdrawalOption(option);
        }


        public static int PidginMatchWithdrawalOption(string operation)
        {
            switch (operation)
            {
                case "1":
                    return 5000;
                case "2":
                    return 10000;
                case "3":
                    return 20000;
                default:
                    Console.WriteLine("Chook the amount you wan collect");
                    string amount = Console.ReadLine();
                    int withdrawalAmount;
                    while (string.IsNullOrEmpty(amount) || amount.Split().Length > 1 || !(int.TryParse(amount, out withdrawalAmount))){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Translation.PidginOperationErrorMessage();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nChook the amount you wan collect");
                        amount = Console.ReadLine();
                    }
                    return withdrawalAmount;
            }
        }
                
        public static int IgboMatchWithdrawalOption(string operation)
        {
            switch (operation)
            {
                case "1":
                    return 5000;
                case "2":
                    return 10000;
                case "3":
                    return 20000;
                default:
                    Console.WriteLine("Ego Ole Ka I Choro");
                    string amount = Console.ReadLine();
                    int withdrawalAmount;
                    while (string.IsNullOrEmpty(amount) || amount.Split().Length > 1 || !(int.TryParse(amount, out withdrawalAmount))){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Translation.IgboOperationErrorMessage();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nEgo Ole Ka I Choro");
                        amount = Console.ReadLine();
                    }
                    return withdrawalAmount;
            }
        }

        public static int EnglishMatchWithdrawalOption(string operation)
        {
            switch (operation)
            {
                case "1":
                    return 5000;
                case "2":
                    return 10000;
                case "3":
                    return 20000;
                default:
                    Console.WriteLine("\nPlease input the amount you want to withdraw");
                    string amount = Console.ReadLine();
                    int withdrawalAmount = 0;
                    while (string.IsNullOrEmpty(amount) || amount.Split().Length > 1 || !(int.TryParse(amount, out withdrawalAmount)) || withdrawalAmount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Translation.EnglishOperationErrorMessage();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nPlease input the amount you want to withdraw");
                        amount = Console.ReadLine();
                    }
                    return withdrawalAmount;
            }
        }

        public static AccountOperation SelectOperationEnglish()
        {
            Translation.EnglishPromptOperation();
            string operation = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(operation) || (operation != "1" && operation != "2" && operation != "3"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Translation.EnglishOperationErrorMessage();
                Console.ForegroundColor = ConsoleColor.White;
                Translation.EnglishPromptOperation();
                operation = Console.ReadLine().Trim();
            }

            return MatchOperation(operation);
        }
        
        public static AccountOperation SelectOperationPidgin()
        {
            Translation.PidginPromptOperation();
            string operation = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(operation) || (operation != "1" && operation != "2" && operation != "3"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Translation.PidginOperationErrorMessage();
                Console.ForegroundColor = ConsoleColor.White;
                Translation.PidginPromptOperation();
                operation = Console.ReadLine().Trim();
            }

            return MatchOperation(operation);
        }
        
        public static AccountOperation SelectOperationIgbo()
        {
            Translation.IgboPromptOperation();
            string operation = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(operation) || (operation != "1" && operation != "2" && operation != "3"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Translation.IgboOperationErrorMessage();
                Console.ForegroundColor = ConsoleColor.White;
                Translation.IgboPromptOperation();
                operation = Console.ReadLine().Trim();
            }

            return MatchOperation(operation);
        }

        public static AccountOperation MatchOperation(string operation)
        {
            switch (operation)
            {
                case "1":
                    return AccountOperation.Withdrawal;
                case "2":
                    return AccountOperation.CheckBalance;
                case "3":
                    return AccountOperation.End;
                default:
                    return AccountOperation.SelectOperation;
            }
        }

        public static Language SelectLanguage()
        {
            Console.WriteLine("\nChoose your preferred language:\n1. English\n2. Pidgin\n3. Igbo");
            string language = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(language) || (language != "1" && language != "2" && language != "3"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Language Selection\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose your preferred language using the number key:\n1. English\n2. Pidgin\n3. Igbo");
                language = Console.ReadLine().Trim();
            }

            return MatchLanguageSelection(language);
        }

        public static Language MatchLanguageSelection(string language)
        {
            switch (language)
            {
                case "1":
                    return Language.English;
                case "2":
                    return Language.Pidgin;
                case "3":
                    return Language.Igbo;
                default:
                    return Language.ChooseLanguage;
            }
        }

        private static bool IsValidated(string pin, string PIN)
        {
            return (pin == PIN);
        }
        
        protected virtual void OnDebit(DebitEventArgs model)
        {
            DebitAlert?.Invoke(this, model);
        }
        
        protected virtual void OnCredit(CreditEventArgs model)
        {
            CreditAlert?.Invoke(this, model);
        }
    }
}
