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
            string userinput = "";
            string password = "";
            int tries = 1;

            do
            {
                do
                {

                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Logga in på ett konto, försök {0}", tries);
                        Console.Write("Användarnamn: ");
                        userinput = userinput = Console.ReadLine();
                        break;


                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ogiltigt Val");

                    }


                } while (true);

                do
                {
                    try
                    {
                        Console.Write("Pinkod: ");
                        password = password = Console.ReadLine();
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ogiltigt Val");

                    }

                } while (true);

                tries++;

                bool loggedin = false;
                foreach (var user in Accounts)
                {


                    if (userinput == user.Username && password == user.Password)
                    {
                        loggedin = true;
                        LoggedIn(Accounts, userinput);
                    }
                }
                if (loggedin == false)
                {
                    Console.WriteLine("Du har skrivit in fel användarnamn eller pinkod för många gånger.");
                    if (tries == 4)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Programmet avslutas . . .");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                }

            } while (tries < 4);

            Console.ReadKey();



            //while (loginSuccess == false)
            //{
            //    Console.WriteLine("Ange ditt användarnamn: ");
            //    string username = Console.ReadLine();
            //    Console.WriteLine("Ange ditt lösenord: ");
            //    string password = Console.ReadLine();
            //    //
            //    foreach (var user in Accounts)
            //    {


            //        if (username == user.Username && password == user.Password)
            //        {
            //            loginSuccess = true;
            //        }
            //    }

            //    //
            //    if (username == "användare1" && password == "password")
            //    {
            //        loginSuccess = true;
            //    }
            //    if (username != "användare1" && password != "password")
            //    {
            //        if (loginAttempts == 3)
            //        {
            //            Console.WriteLine("Du har angett fel användarnamn eller lösenord tre gånger, programmet avslutas...");
            //            Environment.Exit(1);
            //        }

            //        else
            //        {
            //            Console.WriteLine("Fel användarnamn eller lösenord!");
            //            loginAttempts++;
            //            loginSuccess = false;
            //        }

            //    }
            //}



        }
        public void LoggedIn(List<Account> Accounts, string CurrentUser)
        {
            Console.WriteLine("Hej {0}",CurrentUser);
        }
        public void adminLogin()
        {

        }
    }
    


}
