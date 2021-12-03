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
        private bool _IsAdmin;

        public User(string username = "Default Username", string password = "password123", string firstname = "Default First Name", string lastname = "Default Last Name", string email = "Default@Email.com",
            List<BankAccount> bankAccountList = null, bool isAdmin = false)
        {
            this._UserName = username;
            this._PassWord = password;
            this._FirstName = firstname;
            this._LastName = lastname;
            this._Email = email;
            this._BankAccountList = bankAccountList;
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
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }
        public void PrintAllAccounts(List<User> Accounts, User ActiveUser)
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
                do
                {
                    Console.Clear();
                    Console.Write("Välj ett Användarnamn: ");
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

                Console.Write("Välj ett Lösenord: ");
                string PassWord = Console.ReadLine();
                Console.Write("Vad heter Personen(Förnamn): ");
                string FirstName = Console.ReadLine().ToLower();
                Console.Write("Vad heter Personen(Efternamn): ");
                string LastName = Console.ReadLine().ToLower();
                Console.Write("Email Adress: ");
                string Email = Console.ReadLine().ToLower();

                string UserAdmin = string.Empty;
                bool Isadmin = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ska kontot vara Admin (Yes/No):");
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
                BankAccount NewAcc = new BankAccount();
                User NewAccount = new User(UserName, PassWord, FirstName, LastName, Email, NewBankAcc, Isadmin);
                NewAccount.BankAccountList.Add(NewAcc);
                Accounts.Add(NewAccount);

                login back = new login();
                back.loginAdmin(Accounts, ActiveUser);

                return Accounts;

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Du är inte Admin.");
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

            foreach (var item in ActiveUser.BankAccountList)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(item.AccountName);
                Console.WriteLine("Balance: {0}", item.Balance);
                Console.WriteLine("----------------------");
            }
            Console.ReadKey();
        }

    }

    public class DollarBankAccount : BankAccount
    {
        public override double CurrencyCalc(double Balance)
        {
            double Calc = Balance / 9.03;
            return Balance / 9.03;
        }
        public DollarBankAccount(string accountname = "Dollar-Account", double balance = 0)
        {
            this._AccountName = accountname;
            this._Balance = balance;
        }
    }
    public class BankAccount
    {
        public string _AccountName;
        public double _Balance;

        public BankAccount(string accountName = "Privat-Konto", double balance = 25000)
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
        public virtual double CurrencyCalc(double Balance)
        {
            return Balance;
        }
        public void CreateBankAccount(User ActiveUser)
        {
            bool active = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1. Create new bank Account");
                    Console.WriteLine("2. Go Back");
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Set name for new Account: ");
                            string AccountName = Console.ReadLine();
                            BankAccount Account = new BankAccount();
                            Account.AccountName = AccountName;
                            ActiveUser.BankAccountList.Add(Account);

                            Console.WriteLine("Account Succesfully Created.");
                            Console.WriteLine("Press any key to continue.");
                            break;
                        case 2:
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
