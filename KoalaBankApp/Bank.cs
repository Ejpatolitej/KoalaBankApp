using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class Bank
    {
        

        public void Run()
        {

            List<Account> Accounts = new List<Account>();

            List<BankAccount> BAList1 = new List<BankAccount>();
            BankAccount BAccount1 = new BankAccount("Privat-Konto",25000);
            Account Account1 = new Account("Lukkelele", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, true);
            Account1.Useraccount.Add(BAccount1);
            Accounts.Add(Account1);

            
            // TESTNINGS MENY!
            int menu = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Välkommen till KoalaBanken!");
                try
                {
                    Console.WriteLine("1. Logga in");
                    Console.WriteLine("2. Skapa Konto");
                    Console.WriteLine("3. Skriv ut Konton");
                    Console.WriteLine("4. Sök Användare");
                    Console.WriteLine("5. Avsluta programmet");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            login inlog = new login();
                            inlog.userLogin(Accounts);
                            break;
                        case 2:
                            Account newacc = new Account();
                            newacc.CreateAccount(Accounts,true);
                            break;
                        case 3:
                            foreach (var item in Accounts)
                            {
                                Console.WriteLine("-----------------------");
                                Console.WriteLine("Username: {0}",item.Username);
                                Console.WriteLine("First Name: {0}",item.Firstname);
                                Console.WriteLine("Last Name: {0}",item.Lastname);
                                Console.WriteLine("Email Adress: {0}",item.Email);
                                Console.WriteLine("Admin: {0}",item.Isadmin);
                                Console.WriteLine(item.Useraccount);
                                Console.WriteLine("-----------------------");
                            }
                            Console.ReadKey();
                            break;
                        case 4:

                            Console.Write("Skriv in ett Giltligt användarnamn: ");
                            string userinput = Console.ReadLine();

                            Account Check = Accounts.Find(c => c.Username == userinput);
                            if (Check == null)
                            {
                                Console.WriteLine("Användare Existerar inte.");
                            }
                            else
                            {
                                Console.WriteLine("Användare: {0} finns i databasen.",Check.Username);
                            }
                            Console.ReadKey();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            } while (true);

            
            //Account1.CreateAccount(Accounts, Account1.Isadmin);

            //foreach (var item in Accounts)
            //{
            //    Console.WriteLine(item.Firstname);
            //}


            //foreach (var item in Accounts)
            //{
            //    Console.WriteLine(item._UserName);
            //    Console.WriteLine(item.Firstname);
            //    Console.WriteLine(item.Lastname);
            //    Console.WriteLine(item.Password);
            //    Console.WriteLine(item.Useraccount);
            //    foreach (var i in B1)
            //    {
            //        Console.WriteLine(i.AccountName); 
            //        Console.WriteLine(i.Balance);
            //    }
            //}



            //login l1 = new login();
            //l1.userLogin(Accounts);

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
    }
}