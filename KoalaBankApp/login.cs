using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class login
    {
        public bool loginSuccess = false;
        public int loginAttempts = 2;

        public void userLogin(List<User> Accounts)
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
                        if (users.IsAdmin == true)
                        {
                            loginSuccess = true;
                            User Check = Accounts.Find(s => s.Username == username);
                            loginAdmin(Accounts, Check);
                            User.CreateUser(Accounts, true);
                            Console.ReadKey();
                        }
                        else if (users.IsAdmin == false)
                        {
                            loginSuccess = true;
                            User Check = Accounts.Find(s => s.Username == username);
                            Bank.userMenu(Accounts, Check);
                            Console.ReadKey();
                        }
                        loginSuccess = true;
                    }
                }
                if (loginAttempts == 0)
                {
                    loginSuccess = false;
                    Console.WriteLine("You've entered the wrong username or password too many times, the program will now exit . . .");
                    Environment.Exit(1);
                }
                else
                {
                    loginSuccess = false;
                    Console.WriteLine("Wrong username or password! You have " + loginAttempts + " attempts left");
                    loginAttempts--;
                    loginSuccess = false;
                }
            }
        }
        public void loginAdmin(List<User> Accounts, User ActiveUser)
        {
            Console.Clear();
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Log out");
            int menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    User.CreateUser(Accounts, true);
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
