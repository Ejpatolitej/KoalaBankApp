using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class login
    {

        public bool loginSuccess;
        public int loginAttempts = 0;

        public void userLogin()
        {
            while (loginAttempts < 4)
            {
                Console.WriteLine("Ange ditt användarnamn: ");
                string username = Console.ReadLine();
                Console.WriteLine("Ange ditt lösenord: ");
                string password = Console.ReadLine();


                if (username == "användare1" && password == "password")
                {
                    loginSuccess = true;
                }
                else
                {
                    Console.WriteLine("Fel användarnamn eller lösenord!");
                    loginAttempts++;
                    loginSuccess = false;
                }
            }
            Console.WriteLine("Du har angett fel användarnamn eller lösenord tre gånger, programmet avslutas...");
            Environment.Exit(1);

        }
        public void adminLogin()
        {

        }
    }
    


}
