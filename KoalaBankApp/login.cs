using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class Login
    {
        public bool loginSuccess = false;
        public int loginAttempts = 2;

        public void UserLogin(List<User> accounts, CurrencyRates objRates)
        {
            Console.Clear();
            Console.WriteLine("Please enter username and password to log in.");
            while (loginSuccess == false)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                foreach (var users in accounts)
                {
                    if (username == users.Username && password == users.Password)
                    {
                        if (users.IsAdmin == true)
                        {
                            loginSuccess = true;
                            User Check = accounts.Find(s => s.Username == username);
                            //loginAdmin(accounts, Check, objRates);
                            Console.ReadKey();
                        }
                        else if (users.IsAdmin == false)
                        {
                            loginSuccess = true;
                            User Check = accounts.Find(s => s.Username == username);
                            Bank.UserMenu(accounts, Check, objRates);
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
        //public void loginAdmin(List<User> accounts, User activeUser, CurrencyRates objRates)
        //{
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("1. Update Currency Rates (Current Rate: {0})", Math.Round(objRates._Rate, 2));
        //        Console.WriteLine("2. Create Account");
        //        Console.WriteLine("3. Show all Accounts");
        //        Console.WriteLine("4. Log out");
        //        int menu = int.Parse(Console.ReadLine());

        //        switch (menu)
        //        {
        //            case 1:
        //                CurrencyRates.UpdateCurrencyRate(objRates);
        //                break;
        //            case 2:
        //                //User.CreateUser(accounts, true, activeUser, objRates);
        //                break;
        //            case 3:
        //                activeUser.PrintAllUsers(accounts, activeUser, objRates);
        //                break;
        //            case 4:
        //                Login logout = new Login();
        //                logout.UserLogin(accounts, objRates);
        //                break;
        //            default:
        //                break;
        //        }
        //    } while (true);
        //}
    }
}
