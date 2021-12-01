using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{

    public class Account
    {
        private string _UserName;
        private string _PassWord;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private List<BankAccount> _UserAccount;
        private bool _IsAdmin;

        public Account(string username = "Default Username", string password = "password123", string firstname = "Default First Name", string lastname = "Default Last Name", string email = "Default@Email.com",
            List<BankAccount> useraccount = null, bool isadmin = false)
        {
            this._UserName = username;
            this._PassWord = password;
            this._FirstName = firstname;
            this._LastName = lastname;
            this._Email = email;
            this._UserAccount = useraccount;
            this._IsAdmin = isadmin;
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
        public List<BankAccount> Useraccount
        {
            get { return _UserAccount; }
            set { _UserAccount = value; }
        }
        public bool Isadmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }

        public static List<Account> CreateUserAccount(List<Account> Accounts, bool isadmin)
        {
            string UserAdmin;
            bool Isadmin;
            Console.Clear();
            if (isadmin == true)
            {
                Console.Clear();
                Console.Write("Välj ett Användarnamn: ");
                string UserName = Console.ReadLine();
                Console.Write("Välj ett Lösenord: ");
                string PassWord = Console.ReadLine();
                Console.Write("Vad heter Personen(Förnamn): ");
                string FirstName = Console.ReadLine().ToLower();
                Console.Write("Vad heter Personen(Efternamn): ");
                string LastName = Console.ReadLine().ToLower();
                Console.Write("Email Adress: ");
                string Email = Console.ReadLine().ToLower();


                Console.WriteLine("Ska kontot vara Admin (Yes/No): ");
                UserAdmin = Console.ReadLine().ToLower();
                if (UserAdmin == "yes")
                {
                    Isadmin = true;
                }
                else
                {
                    Isadmin = false;
                }

                List<BankAccount> NewBankAcc = new List<BankAccount>();
                BankAccount NewAcc = new BankAccount();
                Account NewAccount = new Account(UserName, PassWord, FirstName, LastName, Email, NewBankAcc, Isadmin);
                NewAccount.Useraccount.Add(NewAcc);
                Accounts.Add(NewAccount);

                login n = new login();
                n.userLogin(Accounts);

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
        public void PrintAccountInfo(List<Account> Accounts,Account ActiveUser)
        {
            Console.Clear();
            Console.WriteLine("Username: {0}",ActiveUser.Username);
            Console.WriteLine("Full Name: {0} {1}",ActiveUser.Firstname,ActiveUser.Lastname);
            Console.WriteLine("Email Adress: {0}",ActiveUser.Email);
            Console.WriteLine();

            foreach (var item in ActiveUser.Useraccount)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(item.AccountName);
                Console.WriteLine("Balance: {0}",item.Balance);
                Console.WriteLine("----------------------");
            }

            Console.ReadKey();
        }
    }

    public class BankAccount
    {

        public string _AccountName;
        public double _Balance;

        public BankAccount(string accountname = "Privat-Konto", double balance = 25000)
        {
            this._AccountName = accountname;
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

        public void CreateBankAccount(List<Account> Accounts,Account ActiveUser)
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
                            ActiveUser.Useraccount.Add(Account);

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
                catch(FormatException)
                {
                    Console.WriteLine("Use a Number to choose from the menu.");
                }
            } while (active == true);
            
        }
    }
    public class EuroBankAccount : BankAccount
    {
        public override double CurrencyCalc(double Balance)
        {
            return Balance / 10.22;
        }
        public EuroBankAccount(string accountname = "Euro-Account", double balance = 25000)
        {
            this._AccountName = accountname;
            this._Balance = balance;
        }
    }
    public class DENBankAccount : BankAccount
    {
        public override double CurrencyCalc(double Balance)
        {
            return Balance / 1.37;
        }
        public DENBankAccount(string accountname = "Danish-Account", double balance = 25000 )
        {
            this._AccountName = accountname;
            this._Balance = balance;
        }
    }
    public class NORBankAccount : BankAccount
    {
        public override double CurrencyCalc(double Balance)
        {
            double Calc = Balance / 1;
            return Balance / 1;
        }
        public NORBankAccount(string accountname = "Norwegian-Account", double balance = 25000)
        {
            this._AccountName = accountname;
            this._Balance = balance;
        }
    }
    public class DollarBankAccount : BankAccount
    {
        public override double CurrencyCalc(double Balance)
        {
            double Calc = Balance / 9.03;
            return Balance / 9.03;
        }
        public DollarBankAccount(string accountname = "Dollar-Account", double balance = 25000)
        {
            this._AccountName = accountname;
            this._Balance = balance;
        }
    }
}
