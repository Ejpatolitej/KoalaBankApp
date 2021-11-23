using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    class Bank
    {
        List<Accounts> Accounts = new List<Accounts>();
        BankAccount[] Useraccount = new BankAccount[5];

        public void Run()
        {
            login l1 = new login();
            l1.userLogin();

            //Meny
                bool MenyAcitve = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Welcome "+/*Name*/ " !");
                    Console.WriteLine("Press 1 Account info\nPress 2 Move money between accounts\nPress 3 Transfer money to other account\nPress 4 loggout ");
                    
                    int menyChoice = 0;
                    try
                    {
                        menyChoice = Int32.Parse(Console.ReadLine());
                        if (menyChoice > 5) // to high number
                        {
                            Console.WriteLine("please enter a number that is a option");
                        }
                        else if (menyChoice < 1) // to low number
                        {
                            Console.WriteLine("please enter a number that is a option");
                        }
                        else //Purfect
                        {

                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please input a number instead");
                    }
                    switch (menyChoice)
                    {
                            case 1:
                                Console.WriteLine("Check accounts"); // Placeholder
                                break;
                            case 2:
                                Console.WriteLine("Move money between account"); // Placeholder
                                break;
                            case 3:
                                Console.WriteLine("Transfer to other account"); // Placeholder
                                break;
                            case 4:
                                Console.WriteLine("Insert Money");
                                break;
                            case 5:
                                Console.WriteLine("Logout");
                                MenyAcitve = false;
                                break;
                    }
                } while (MenyAcitve);
            //No more meny
        }


        public bool LogIn(List<Accounts> Accounts)
        {

            return true;
        }
    }
}