using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class User
    {
        private string _UserName;
        private string _PassWord;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private List<BankAccount> _BankAccountList;
        private List<DollarBankAccount> _DollarAccountList;
        private bool _IsAdmin;
        public double DollarRate = 9.02;

        public User(string username = "Default Username", string password = "password123", string firstname = "Default First Name", string lastname = "Default Last Name", string email = "Default@Email.com",
            List<BankAccount> bankAccountList = null, List<DollarBankAccount> dollarAccountList = null, bool isAdmin = false)
        {
            this._UserName = username;
            this._PassWord = password;
            this._FirstName = firstname;
            this._LastName = lastname;
            this._Email = email;
            this._BankAccountList = bankAccountList;
            this._DollarAccountList = dollarAccountList;
            this._IsAdmin = isAdmin;
        }
        public string Username
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }
        public string Firstname
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string Lastname
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public List<BankAccount> BankAccountList
        {
            get { return _BankAccountList; }
            set { _BankAccountList = value; }
        }
        public List<DollarBankAccount> DollarAccountList
        {
            get { return _DollarAccountList; }
            set { _DollarAccountList = value; }
        }
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }
        public void PrintAllUsers(List<User> Accounts, User ActiveUser)
        {
            Console.Clear();
            int i = 1;
            foreach (var item in Accounts)
            {
                Console.WriteLine("{0}. {1}", i, item.Username);
                i++;
            }
            Console.ReadKey();
            login back = new login();
            back.loginAdmin(Accounts, ActiveUser);
        }
        public static List<User> CreateUser(List<User> Accounts, bool isadmin, User ActiveUser)
        {
            Console.Clear();
            if (isadmin == true)
            {
                Console.Clear();
                bool CheckUsers = false;
                string UserName = string.Empty;
                string UserInput = string.Empty;
                Console.WriteLine("Please enter information for the new user.");
                Console.WriteLine();
                do
                {
                    Console.Clear();
                    Console.Write("Choose a username: ");
                    UserInput = Console.ReadLine();
                    CheckUsers = Accounts.Exists(cu => cu.Username == UserInput);

                    if (CheckUsers == true)
                    {
                        Console.WriteLine("Username already exists, please choose another one.");
                        Console.ReadKey();
                    }
                    else
                    {
                        UserName = UserInput;
                    }
                } while (CheckUsers == true);

                Console.Write("Choose a password: ");
                string PassWord = Console.ReadLine();
                Console.Write("What is the first name: ");
                string FirstName = Console.ReadLine().ToLower();
                Console.Write("What is the last name: ");
                string LastName = Console.ReadLine().ToLower();
                Console.Write("Email Adress: ");
                string Email = Console.ReadLine().ToLower();

                string UserAdmin = string.Empty;
                bool Isadmin = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Should this user be Administrator? (Yes/No):");
                    UserAdmin = Console.ReadLine().ToLower();

                    if (UserAdmin == "yes")
                    {
                        Isadmin = true;
                        break;
                    }
                    else if (UserAdmin == "no")
                    {
                        Isadmin = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please write YES or NO.");
                        Console.ReadKey();
                        continue;
                    }
                } while (true);

                List<BankAccount> NewBankAcc = new List<BankAccount>();
                List<DollarBankAccount> NewDollarAccount = new List<DollarBankAccount>();
                BankAccount NewAcc = new BankAccount();
                User NewAccount = new User(UserName, PassWord, FirstName, LastName, Email, NewBankAcc, NewDollarAccount, Isadmin);
                NewAccount.BankAccountList.Add(NewAcc);
                Accounts.Add(NewAccount);

                login back = new login();
                back.loginAdmin(Accounts, ActiveUser);

                return Accounts;

            }
            else
            {
                Console.Clear();
                Console.WriteLine("You are not Admin.");
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return null;
            }

        }
        public void PrintAccountInfo(User ActiveUser)
        {
            Console.Clear();
            Console.WriteLine("Username: {0}", ActiveUser.Username);
            Console.WriteLine("Full Name: {0} {1}", ActiveUser.Firstname, ActiveUser.Lastname);
            Console.WriteLine("Email Adress: {0}", ActiveUser.Email);
            Console.WriteLine();

            int i = 1;
            Console.WriteLine("-----Swedish Accounts-----");
            foreach (var item in ActiveUser.BankAccountList)
            {
                Console.WriteLine();
                Console.WriteLine(i + ". " + item.AccountName + " : {0} SEK", Math.Round(item.Balance,2));
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                i++;
            }
            int x = 1;
            Console.WriteLine("-----American Accounts----");
            foreach (var item in ActiveUser.DollarAccountList)
            {
                Console.WriteLine();
                Console.WriteLine(x + ". " + item.DollarAccountName + " : ${0}", Math.Round(item.DollarBalance,2));
                Console.WriteLine();
                Console.WriteLine("--------------------------");

                x++;
            }
            Console.ReadKey();
        }

    }

    public class DollarBankAccount
    {
        public string _DollarAccountName;
        public double _DollarBalance;

        public DollarBankAccount(string DollarAccountName = "Private-USD-Account", double DollarAccount = 2500)
        {
            this._DollarAccountName = DollarAccountName;
            this._DollarBalance = DollarAccount;
        }
        public string DollarAccountName
        {
            get { return _DollarAccountName; }
            set { _DollarAccountName = value; }
        }
        public double DollarBalance
        {
            get { return _DollarBalance; }
            set { _DollarBalance = value; }
        }
        public static double USDtoSEK(double AmounttoCheck)
        {
            return AmounttoCheck * 9.02;
        }

    }
    public class BankAccount
    {
        public string _AccountName;
        public double _Balance;
        

        public BankAccount(string accountName = "Private-Account", double balance = 25000)
        {
            this._AccountName = accountName;
            this._Balance = balance;
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

        public static double SEKtoUSD(double AmounttoCheck)
        {
            return AmounttoCheck / 9.02;
            
        }
        public void AccountManagement(User ActiveUser,List<User> Accounts)
        {
            bool active = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1. Create new Bank Account");
                    Console.WriteLine("2. Create new USD Bank Account");
                    Console.WriteLine("3. Convert Account");
                    Console.WriteLine("4. Go Back");
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Set name for new SEK Account: ");
                            string AccountName = Console.ReadLine();
                            BankAccount Account = new BankAccount();
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
                            DollarBankAccount DAccount = new DollarBankAccount();
                            DAccount.DollarAccountName = DAccountName;
                            ActiveUser.DollarAccountList.Add(DAccount);

                            Console.WriteLine("Account Succesfully Created.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case 3:
                            bool subMenu = false;
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("1. Convert SEK Account to USD");
                                    Console.WriteLine("2. Convert USD Account to SEK");
                                    Console.WriteLine("3. Go back");
                                    int submenu = int.Parse(Console.ReadLine());
                                    switch (submenu)
                                    {
                                        case 1:
                                            int x = 1;
                                            Console.WriteLine("---------Convert SEK to USD---------");
                                            Console.WriteLine("Which account do you want to convert?");
                                            foreach (var item in ActiveUser.BankAccountList)
                                            {
                                                Console.WriteLine(x + ". " + item.AccountName + " : " + Math.Round(item.Balance,2));
                                                x++;
                                            }

                                            bool MenuLoop1 = false;
                                            int index1 = 0;

                                            while (MenuLoop1 == false)
                                            {
                                                try
                                                {
                                                    index1 = int.Parse(Console.ReadLine()); ;
                                                    if (index1 <= ActiveUser.BankAccountList.Count && index1 >= 0)
                                                    {
                                                        double Amount1 = ActiveUser.BankAccountList[index1 - 1].Balance;
                                                        ActiveUser.BankAccountList.RemoveAt(index1 - 1);
                                                        DollarBankAccount ConvertedAcc1 = new DollarBankAccount("Converted Account", BankAccount.SEKtoUSD(Amount1));
                                                        ActiveUser.DollarAccountList.Add(ConvertedAcc1);
                                                        MenuLoop1 = true;
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Please use a number to choose from the list.");
                                                }
                                            }
                                            break;
                                        case 2:
                                            int i = 1;
                                            Console.WriteLine("---------Convert USD to SEK---------");
                                            Console.WriteLine("Which account do you want to convert?");
                                            foreach (var item in ActiveUser.DollarAccountList)
                                            {
                                                Console.WriteLine(i + ". " + item.DollarAccountName + " : " + Math.Round(item.DollarBalance,2));
                                                i++;
                                            }

                                            bool MenuLoop2 = false;
                                            int index2 = 0;

                                            while (MenuLoop2 == false)
                                            {
                                                try
                                                {
                                                    index2 = int.Parse(Console.ReadLine());
                                                    if (index2 <= ActiveUser.DollarAccountList.Count && index2 >= 0)
                                                    {
                                                        double Amount2 = ActiveUser.DollarAccountList[index2 - 1].DollarBalance;
                                                        ActiveUser.DollarAccountList.RemoveAt(index2 - 1);
                                                        BankAccount ConvertedAcc2 = new BankAccount("Converted Account", DollarBankAccount.USDtoSEK(Amount2));
                                                        ActiveUser.BankAccountList.Add(ConvertedAcc2);
                                                        MenuLoop2 = true;
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Please use a number to choose from the list.");
                                                }
                                            }
                                            break;
                                        case 3:
                                            continue;
                                        default:
                                            break;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please use a number to choose from the list.");
                                }
                            } while (subMenu == true);

                            Console.WriteLine("Press any key to continue . . .");
                            Console.ReadKey();
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
