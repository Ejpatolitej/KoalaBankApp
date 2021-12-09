using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class login
    {
        public bool loginSuccess = false;
        public int loginAttempts = 2;

        public void userLogin(List<User> Accounts, CurrencyRates ObjRates)
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
                            loginAdmin(Accounts, Check, ObjRates);
                            //User.CreateUser(Accounts, true);
                            Console.ReadKey();
                        }
                        else if (users.IsAdmin == false)
                        {
                            loginSuccess = true;
                            User Check = Accounts.Find(s => s.Username == username);
                            Bank.userMenu(Accounts, Check, ObjRates);
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

        public void loginAdmin(List<User> Accounts, User ActiveUser,CurrencyRates ObjRates)
        {
            do
            {
                
                
                Console.Clear();
                Console.WriteLine("1. Update Currency Rates (Current Rate: {0})", Math.Round(ObjRates._Rate, 2));
                Console.WriteLine("2. Create Account");
                Console.WriteLine("3. Show all Accounts");
                Console.WriteLine("4. Log out");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:

                        CurrencyRates.UpdateCurrencyRate(ObjRates);
                        break;
                    case 2:
                        User.CreateUser(Accounts,true,ActiveUser,ObjRates);
                        break;
                    case 3:
                        ActiveUser.PrintAllUsers(Accounts,ActiveUser,ObjRates);
                        break;
                    case 4:
                        login logout = new login();
                        logout.userLogin(Accounts,ObjRates);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
