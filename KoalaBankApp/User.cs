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
        private List<SavingsAccount> _SavingsAccountList;
        private bool _IsAdmin;

        public User(string username = "Default Username", string password = "password123", string firstname = "Default First Name", string lastname = "Default Last Name", string email = "Default@Email.com",
            List<BankAccount> bankAccountList = null, List<SavingsAccount> savingsAccountList= null, bool isAdmin = false)
        {
            this._UserName = username;
            this._PassWord = password;
            this._FirstName = firstname;
            this._LastName = lastname;
            this._Email = email;
            this._BankAccountList = bankAccountList;
            this._SavingsAccountList = savingsAccountList;
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
        public List<SavingsAccount> SavingsAccountList
        {
            get { return _SavingsAccountList; }
            set { _SavingsAccountList = value; }
        }
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }
        public void PrintAllUsers(List<User> Accounts, User ActiveUser, CurrencyRates ObjRates)
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
            back.loginAdmin(Accounts, ActiveUser, ObjRates);
        }
        public static List<User> CreateUser(List<User> Accounts, bool isadmin, User ActiveUser, CurrencyRates Rates)
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
                    Console.WriteLine("Please enter information for the new user.");
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
                List<SavingsAccount> NewSavingsAcc = new List<SavingsAccount>();
                BankAccount NewAcc = new BankAccount();
                User NewAccount = new User(UserName, PassWord, FirstName, LastName, Email, NewBankAcc, NewSavingsAcc, Isadmin);
                NewAccount.BankAccountList.Add(NewAcc);
                Accounts.Add(NewAccount);

                login back = new login();
                back.loginAdmin(Accounts, ActiveUser, Rates);

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
        public void PrintAccountInfo(User ActiveUser, CurrencyRates Rates)
        {
            Console.Clear();
            Console.WriteLine("Username: {0}", ActiveUser.Username);
            Console.WriteLine("Full Name: {0} {1}", ActiveUser.Firstname, ActiveUser.Lastname);
            Console.WriteLine("Email Adress: {0}", ActiveUser.Email);
            Console.WriteLine();

            BankAccount.PrintAccounts(ActiveUser,Rates);

            Console.ReadKey();
        }
    }
}
