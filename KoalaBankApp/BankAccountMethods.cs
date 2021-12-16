using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public partial class BankAccount
    {
        public void AccountManagement(User activeUser, List<User> accounts, CurrencyRates rates)
        {
            bool active = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1. Create new Bank Account(SEK)");
                    Console.WriteLine("2. Create new Bank Account(USD)");
                    Console.WriteLine("3. Create new Savings Account(SEK)");
                    Console.WriteLine("4. International Transfer");
                    Console.WriteLine("5. Go Back");
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Set name for new SEK Account: ");
                            string accountName = Console.ReadLine();
                            BankAccount account = new BankAccount(accountName, 0, "SEK");
                            account.AccountName = accountName;
                            activeUser.BankAccountList.Add(account);

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
                            activeUser.BankAccountList.Add(DAccount);

                            Console.WriteLine("Account succesfully created.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Set name for new Savings Account: ");
                            string savingsAccName = Console.ReadLine();
                            SavingsAccount savingsAccount = new SavingsAccount();
                            double interest = savingsAccount.RandomInterest();
                            Console.WriteLine("Interest for the account is {0:f2}%", interest);
                            Console.WriteLine("Would you like to create the account? Yes / No");
                            string userChoice = Console.ReadLine().ToUpper();
                            if (userChoice == "YES")
                            {
                                SavingsAccount savingsAcc = new SavingsAccount(savingsAccName, 0, "SEK", interest);
                                savingsAcc.AccountName = savingsAccName;
                                activeUser.SavingsAccountList.Add(savingsAcc);

                                Console.WriteLine("Account Succesfully Created.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Account not created.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            BankAccount.InternationalTransfer(accounts, activeUser, rates);
                            break;
                        case 5:
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
        public static void InternationalTransfer(List<User> accounts, User activeUser, CurrencyRates rates)
        {
            bool menuLoop1 = false;
            int index1 = 0;
            double transfer = 0;

            while (menuLoop1 == false)
            {
                int x = 1;
                try
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Which account would you like to transfer from?");
                        foreach (var item in activeUser.BankAccountList)
                        {
                            Console.WriteLine(x + ". " + item.AccountName + " : " + Math.Round(item.Balance, 2));
                            x++;
                        }
                        index1 = int.Parse(Console.ReadLine());
                    } while (index1 > activeUser.BankAccountList.Count - 1 && index1 < 1);
                    Console.Clear();
                    Console.WriteLine("What amount would you like to transfer?");
                    Console.Write("Amount: ");
                    transfer = double.Parse(Console.ReadLine());

                    if (index1 <= activeUser.BankAccountList.Count && index1 >= 0)
                    {
                        if (activeUser.BankAccountList[index1 - 1].Balance < transfer)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.ReadKey();
                        }
                        else
                        {
                            activeUser.BankAccountList[index1 - 1].Balance -= transfer;
                            menuLoop1 = true;
                        }
                    }
                    else if (index1 > activeUser.BankAccountList.Count && index1 < 1)
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
            bool menuLoop2 = false;

            while (menuLoop2 == false)
            {
                int i = 1;
                try
                {
                    Console.Clear();
                    Console.WriteLine("Which account would you like to transfer to?");
                    foreach (var item in activeUser.BankAccountList)
                    {
                        Console.WriteLine(i + ". " + item.AccountName + " {0:f2}", item.Balance);
                        i++;
                    }

                    index2 = int.Parse(Console.ReadLine());
                    if (index2 <= activeUser.BankAccountList.Count && index2 >= 0)
                    {
                        if (activeUser.BankAccountList[index1 - 1].Type == "SEK")
                        {
                            if (activeUser.BankAccountList[index2 - 1].Type == "SEK")
                            {
                                activeUser.BankAccountList[index2 - 1].Balance += transfer;
                                menuLoop2 = true;
                            }
                            else if (activeUser.BankAccountList[index2 - 1].Type == "USD")
                            {
                                activeUser.BankAccountList[index2 - 1].Balance += transfer / rates._Rate;
                                menuLoop2 = true;
                            }
                        }
                        else if (activeUser.BankAccountList[index1 - 1].Type == "USD")
                        {
                            if (activeUser.BankAccountList[index2 - 1].Type == "SEK")
                            {
                                activeUser.BankAccountList[index2 - 1].Balance += transfer * rates._Rate;
                                menuLoop2 = true;
                            }
                            else if (activeUser.BankAccountList[index2 - 1].Type == "USD")
                            {
                                activeUser.BankAccountList[index2 - 1].Balance += transfer;
                                menuLoop2 = true;
                            }
                        }
                    }
                    else if (index2 > activeUser.BankAccountList.Count - 1 && index2 < 1)
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
            Console.WriteLine("Transaction Complete. Press any key to continue");
            Console.ReadKey();
        }
        public static void PrintAccounts(User activeUser, CurrencyRates rates)
        {
            Console.WriteLine("--- Private accounts ---");
            Console.WriteLine();
            int x = 1;
            List<BankAccount> printSEK = activeUser.BankAccountList.FindAll(c => c.Type == "SEK");
            foreach (var i in printSEK)
            {
                double balanceSEK = i.Balance;
                Console.WriteLine(x + ". {0}: {1:f2} SEK", i.AccountName, balanceSEK);
                Console.WriteLine();
                x++;
            }
            List<BankAccount> printUSD = activeUser.BankAccountList.FindAll(c => c.Type == "USD");
            foreach (var i in printUSD)
            {
                double balanceUSD = i.Balance;
                Console.WriteLine(x + ". {0}: ${1:f2}", i.AccountName, balanceUSD);
                Console.WriteLine();
                x++;
            }
            if (activeUser.SavingsAccountList.Count > 0)
            {
                Console.WriteLine("--- Savings accounts ---");
                Console.WriteLine();
            }
            int y = 1;
            List<SavingsAccount> savingsAccounts = activeUser.SavingsAccountList;
            foreach (var item in savingsAccounts)
            {
                Console.WriteLine(y + ". {0}: {1}", item.AccountName, item.Balance);
                Console.WriteLine("     Interest: {0:f2}%", item.Interest);
                Console.WriteLine();
                y++;
            }
        }
    }
}