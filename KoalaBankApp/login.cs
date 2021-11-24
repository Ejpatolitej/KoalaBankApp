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
            while (loginSuccess == false)
            {
                Console.WriteLine("Ange ditt användarnamn: ");
                string username = Console.ReadLine();
                Console.WriteLine("Ange ditt lösenord: ");
                string password = Console.ReadLine();
                //
                foreach (var user in Accounts)
                {


                    if (username == user.Username && password == user.Password)
                    {
                        loginSuccess = true;
                    }
                }

                //
                if (username == "användare1" && password == "password")
                {
                    loginSuccess = true;
                }
                if (username != "användare1" && password != "password")
                {
                    if (loginAttempts == 3)
                    {
                        Console.WriteLine("Du har angett fel användarnamn eller lösenord tre gånger, programmet avslutas...");
                        Environment.Exit(1);
                    }

                    else
                    {
                        Console.WriteLine("Fel användarnamn eller lösenord!");
                        loginAttempts++;
                        loginSuccess = false;
                    }

                }
            }

            

        }

        public void adminLogin()
        {

        }
    }
    


}
