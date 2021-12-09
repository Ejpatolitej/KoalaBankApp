using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public partial class BankAccount
    {

        public static void InternationalTransfer(List<User> Accounts,User ActiveUser, CurrencyRates Rates)
        {
            
            bool MenuLoop1 = false;
            int index1 = 0;
            double transfer = 0;

            while (MenuLoop1 == false)
            {
                int x = 1;
                try
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("From which Account do you want to send from?");
                        foreach (var item in ActiveUser.BankAccountList)
                        {

                            Console.WriteLine(x + ". " + item.AccountName + " : " + Math.Round(item.Balance, 2));
                            x++;
                        }
                        index1 = int.Parse(Console.ReadLine());
                    } while (index1 > ActiveUser.BankAccountList.Count - 1 && index1 < 1);

                    Console.Clear();
                    Console.WriteLine("How much money would you like to transfer?");
                    Console.Write("Amount: ");
                    transfer = double.Parse(Console.ReadLine());

                    if (index1 <= ActiveUser.BankAccountList.Count && index1 >= 0)
                    {
                        if (ActiveUser.BankAccountList[index1 - 1].Balance < transfer)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.ReadKey();
                        }
                        else
                        {
                            ActiveUser.BankAccountList[index1 - 1].Balance -= transfer;
                            MenuLoop1 = true;
                        }
                    }
                    else if (index1 > ActiveUser.BankAccountList.Count && index1 < 1)
                    {
                        Console.WriteLine("Please choose an account in the list.");
                        Console.ReadKey();
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please use a number to choose from the list.");
                    Console.ReadKey();
                    continue;
                }
            }

            int index2 = 1;
            bool MenuLoop2 = false;
            
            while (MenuLoop2 == false)
            {
                int i = 1;
                try
                {
                    Console.Clear();
                    Console.WriteLine("Which Account do you want to transfer to?");
                    foreach (var item in ActiveUser.BankAccountList)
                    {
                        Console.WriteLine(i + ". " + item.AccountName + " {0:f2}",item.Balance);
                        i++;
                    }

                    index2 = int.Parse(Console.ReadLine());


                    if (index2 <= ActiveUser.BankAccountList.Count && index2 >= 0)
                    {
                        if (ActiveUser.BankAccountList[index1 - 1].Type == "SEK")
                        {
                            if (ActiveUser.BankAccountList[index2 - 1].Type == "SEK")
                            {
                                ActiveUser.BankAccountList[index2 - 1].Balance += transfer;
                                MenuLoop2 = true;
                            }
                            else if (ActiveUser.BankAccountList[index2 - 1].Type == "USD")
                            {
                                ActiveUser.BankAccountList[index2 - 1].Balance += transfer / Rates._Rate;
                                MenuLoop2 = true;
                            }
                        }
                        else if (ActiveUser.BankAccountList[index1 - 1].Type == "USD")
                        {
                            if (ActiveUser.BankAccountList[index2 - 1].Type == "SEK")
                            {
                                ActiveUser.BankAccountList[index2 - 1].Balance += transfer * Rates._Rate;
                                MenuLoop2 = true;
                            }
                            else if (ActiveUser.BankAccountList[index2 - 1].Type == "USD")
                            {
                                ActiveUser.BankAccountList[index2 - 1].Balance += transfer;
                                MenuLoop2 = true;
                            }
                        }
                    }
                    else if (index2 > ActiveUser.BankAccountList.Count - 1 && index2 < 1)
                    {
                        Console.WriteLine("Please choose an account in the list.");
                        Console.ReadKey();
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please use a number to choose from the list.");
                    Console.ReadKey();
                    continue;
                }
            }
            Console.Clear();
            Console.WriteLine("Transaction Complete.");
            Console.ReadKey();
        }
        public static void PrintAccounts(User ActiveUser, CurrencyRates Rates)
        {
            int x = 1;
            List<BankAccount> PrintSEK = ActiveUser.BankAccountList.FindAll(c => c.Type == "SEK");
            foreach (var i in PrintSEK)
            {
                double BalanceSEK = i.Balance;
                Console.WriteLine(x + ". {0}: {1:f2} SEK", i.AccountName, BalanceSEK);
                Console.WriteLine();
                x++;
            }

            List<BankAccount> PrintUSD = ActiveUser.BankAccountList.FindAll(c => c.Type == "USD");
            foreach (var i in PrintUSD)
            {
                double BalanceUSD = i.Balance;
                Console.WriteLine(x + ". {0}: ${1:f2}", i.AccountName, BalanceUSD);
                Console.WriteLine();
                x++;
            }

        }
        public void AccountManagement(User ActiveUser, List<User> Accounts, CurrencyRates Rates)
        {
            bool active = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1. Create new Bank Account(SEK)");
                    Console.WriteLine("2. Create new Bank Account(USD)");
                    Console.WriteLine("3. International Transfer");
                    Console.WriteLine("4. Go Back");
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Set name for new SEK Account: ");
                            string AccountName = Console.ReadLine();
                            BankAccount Account = new BankAccount(AccountName, 0, "SEK");
                            Account.AccountName = AccountName;
                            ActiveUser.BankAccountList.Add(Account);

                            Console.WriteLine("Account Succesfully Created.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("Set name for new USD Account: ");
                            string DAccountName = Console.ReadLine();
                            BankAccount DAccount = new BankAccount(DAccountName, 0, "USD");
                            DAccount.AccountName = DAccountName;
                            ActiveUser.BankAccountList.Add(DAccount);

                            Console.WriteLine("Account Succesfully Created.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case 3:
                            BankAccount.InternationalTransfer(Accounts,ActiveUser, Rates);
                            break;
                        case 4:
                            active = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Use a Number to choose from the menu.");
                }
            } while (active == true);
        }
    }
}
