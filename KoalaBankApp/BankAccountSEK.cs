using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public partial class BankAccount
    {
        public string _AccountName;
        public double _Balance;
        public string _Type;

        public BankAccount(string accountName = "Private-Account", double balance = 25000,string type = "Default")
        {
            this._AccountName = accountName;
            this._Balance = balance;
            this._Type = type;
        }
        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public void AccountManagement(User ActiveUser, List<User> Accounts, CurrencyRates ObjRates)
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
                    Console.WriteLine("4. Go Back");
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Set name for new SEK Account: ");
                            string AccountName = Console.ReadLine();
                            BankAccount Account = new BankAccount(AccountName,0,"SEK");
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
                            BankAccount DAccount = new BankAccount(DAccountName,0,"USD");
                            DAccount.AccountName = DAccountName;
                            ActiveUser.BankAccountList.Add(DAccount);

                            Console.WriteLine("Account Succesfully Created.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Set name for new Savings Account: ");
                            string savingsAccName = Console.ReadLine();
                            SavingsAccount savingsAccount = new SavingsAccount();
                            double interest = savingsAccount.randomInterest();
                            Console.WriteLine("Interest for the account is {0:f2}%", interest);
                            Console.WriteLine("Would you like to create the account?");
                            string userChoice = Console.ReadLine().ToUpper();
                            if (userChoice == "YES")
                            {
                                SavingsAccount savingsAcc = new SavingsAccount(savingsAccName, 0, "SEK", interest);
                                savingsAcc.AccountName = savingsAccName;
                                ActiveUser.SavingsAccountList.Add(savingsAcc);

                                Console.WriteLine("Account Succesfully Created.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Account not created. Press any key to go back to menu.");
                                Console.ReadKey();
                            }
                            break;
                            #region Commented Code
                            //case 3:
                            //    bool subMenu = false;
                            //    do
                            //    {
                            //        try
                            //        {
                            //            Console.Clear();
                            //            Console.WriteLine("1. Convert SEK Account to USD");
                            //            Console.WriteLine("2. Convert USD Account to SEK");
                            //            Console.WriteLine("3. Go back");
                            //            int submenu = int.Parse(Console.ReadLine());
                            //            switch (submenu)
                            //            {
                            //                case 1:
                            //                    int x = 1;
                            //                    Console.WriteLine("---------Convert SEK to USD---------");
                            //                    Console.WriteLine("Which account do you want to convert?");

                            //                    foreach (var item in ActiveUser.BankAccountList)
                            //                    {
                            //                        Console.WriteLine(x + ". " + item.AccountName + " : " + Math.Round(item.Balance, 2));
                            //                        x++;
                            //                    }

                            //                    bool MenuLoop1 = false;
                            //                    int index1 = 0;


                            //                    while (MenuLoop1 == false)
                            //                    {
                            //                        try
                            //                        {
                            //                            index1 = int.Parse(Console.ReadLine());
                            //                            Console.Write("Set name for the converted Account:");
                            //                            string NewAccountNameUSD = Console.ReadLine();
                            //                            if (index1 <= ActiveUser.BankAccountList.Count && index1 >= 0)
                            //                            {
                            //                                double Amount1 = ActiveUser.BankAccountList[index1 - 1].Balance;
                            //                                ActiveUser.BankAccountList.RemoveAt(index1 - 1);
                            //                                DollarBankAccount ConvertedAcc1 = new DollarBankAccount(NewAccountNameUSD, CurrencyRates.SEKtoUSD(Amount1, ObjRates));
                            //                                ActiveUser.DollarAccountList.Add(ConvertedAcc1);
                            //                                MenuLoop1 = true;
                            //                            }
                            //                        }
                            //                        catch (FormatException)
                            //                        {
                            //                            Console.WriteLine("Please use a number to choose from the list.");
                            //                            Console.ReadKey();
                            //                            break;
                            //                        }
                            //                    }
                            //                    break;
                            //                case 2:
                            //                    int i = 1;
                            //                    Console.WriteLine("---------Convert USD to SEK---------");
                            //                    Console.WriteLine("Which account do you want to convert?");
                            //                    foreach (var item in ActiveUser.DollarAccountList)
                            //                    {
                            //                        Console.WriteLine(i + ". " + item.DollarAccountName + " : " + Math.Round(item.DollarBalance, 2));
                            //                        i++;
                            //                    }

                            //                    bool MenuLoop2 = false;
                            //                    int index2 = 0;

                            //                    while (MenuLoop2 == false)
                            //                    {
                            //                        try
                            //                        {
                            //                            index2 = int.Parse(Console.ReadLine());
                            //                            Console.Write("Set name for the converted Account:");
                            //                            string NewAccountNameSEK = Console.ReadLine();
                            //                            if (index2 <= ActiveUser.DollarAccountList.Count && index2 >= 0)
                            //                            {
                            //                                double Amount2 = ActiveUser.DollarAccountList[index2 - 1].DollarBalance;
                            //                                ActiveUser.DollarAccountList.RemoveAt(index2 - 1);
                            //                                BankAccount ConvertedAcc2 = new BankAccount(NewAccountNameSEK, CurrencyRates.USDtoSEK(Amount2, ObjRates));
                            //                                ActiveUser.BankAccountList.Add(ConvertedAcc2);
                            //                                MenuLoop2 = true;
                            //                            }
                            //                        }
                            //                        catch (FormatException)
                            //                        {
                            //                            Console.WriteLine("Please use a number to choose from the list.");
                            //                            Console.ReadKey();
                            //                            break;
                            //                        }
                            //                    }
                            //                    break;
                            //                case 3:
                            //                    continue;
                            //                default:
                            //                    break;
                            //            }
                            //        }
                            //        catch (FormatException)
                            //        {
                            //            Console.WriteLine("Please use a number to choose from the list.");
                            //        }
                            //    } while (subMenu == true);


                            //    Console.WriteLine("Press any key to continue . . .");
                            //    Console.ReadKey();
                            //    break;

                            #endregion                        
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

