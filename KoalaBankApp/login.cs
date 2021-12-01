using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class login
    {

        public bool loginSuccess = false;
        public int loginAttempts = 1;

        public void userLogin(List<Account> Accounts)
        {
            Console.Clear();
            Console.WriteLine("Please enter username and password to log in.");
            while (loginSuccess == false)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                foreach (var users in Accounts)
                {
                    if (username == users.Username && password == users.Password)
                    {
                        if (users.Isadmin == true)
                        {
                            loginSuccess = true;
                            Account Check = Accounts.Find(s => s.Username == username);
                            loginAdmin(Accounts,Check);
                            Account.CreateUserAccount(Accounts, true);
                            Console.ReadKey();
                        }
                        if (users.Isadmin == false)
                        {
                            loginSuccess = true;
                            Account Check = Accounts.Find(s => s.Username == username);
                            Bank.userMenu(Accounts, Check);
                            Console.ReadKey();
                        }


                        Console.ReadKey();

                        loginSuccess = true;
                    }

                    if (username != users.Username && password != users.Password)
                    {
                        if (loginAttempts == 3)
                        {
                            loginSuccess = false;
                            Console.WriteLine("You've entered the wrong username or password too many times, the program will now exit . . .");
                            Environment.Exit(1);
                        }

                        else
                        {
                            loginSuccess = false;
                            Console.WriteLine("Wrong username or password!");
                            loginAttempts++;
                            loginSuccess = false;
                        }

                    }
                }
            }
        }

        public void loginAdmin(List<Account> Accounts,Account ActiveUser)
        {
            Console.Clear();
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Log out");
            int menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Account.CreateUserAccount(Accounts,true);
                    break;
                case 2:
                    login logout = new login();
                    logout.userLogin(Accounts);
                    break;
                default:
                    break;
            }
        }
    }
}
