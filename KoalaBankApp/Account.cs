using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{

    public class Account : Bank
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

        public static List<Account> CreateAccount(List<Account> Accounts,bool isadmin)
        {
            string UserAdmin;
            bool Isadmin;
            Console.Clear();
            if (isadmin == true)
            {
                Console.Clear();
                Console.Write("Välj ett Användarnamn: "); 
                string UserName = Console.ReadLine().ToLower();
                Console.Write("Välj ett Lösenord: ");
                string PassWord = Console.ReadLine();
                Console.Write("Vad heter Personen(Förnamn): ");
                string FirstName = Console.ReadLine().ToLower();
                Console.Write("Vad heter Personen(Efternamn): ");
                string LastName = Console.ReadLine().ToLower();
                Console.Write("Email Adress: ");
                string Email = Console.ReadLine().ToLower();
                do
                {
                    Console.WriteLine("Ska kontot vara Admin (Yes/No): ");
                    UserAdmin = Console.ReadLine().ToLower();
                    if (UserAdmin == "yes")
                    {
                        Isadmin = true;
                        break;
                    }
                    else
                    {
                        Isadmin = false;
                        break;
                        
                    }
                } while (Isadmin == true || Isadmin == false);

            List<BankAccount> NewBankAcc = new List<BankAccount>();
            BankAccount NewAcc = new BankAccount();
            Account NewAccount = new Account(UserName, PassWord, FirstName, LastName, Email, NewBankAcc, Isadmin);
            NewAccount.Useraccount.Add(NewAcc);
            Accounts.Add(NewAccount);
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
    }

    public class BankAccount
    {

        public string _AccountName;
        public double _Balance;

        public BankAccount(string accountname = "Privat-Konto", double balance = 0)
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

        public void CreateNewBankAccount(List<Account> Accounts)
        {
            string AccountName;
            double AccountBalance;
            

            Console.Clear();
            Console.WriteLine("---Skapa nytt konto---");
            Console.Write("Välj ett namn för kontot: ");
            AccountName = Console.ReadLine().ToUpper();
            AccountBalance = 0;
            BankAccount NewBankAcc = new BankAccount(AccountName,AccountBalance);
            
        }
 

    }
}
