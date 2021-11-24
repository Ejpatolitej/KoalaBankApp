using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    class Bank
    {

        public void Run()
        {

            List<Account> Accounts = new List<Account>();

            List<BankAccount> BAList1 = new List<BankAccount>();
            BankAccount BAccount1 = new BankAccount();
            Account Account1 = new Account("Lukkelele", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1);
            Account1.Useraccount.Add(BAccount1);
            Accounts.Add(Account1);




            //BankAccount Test1BA1 = new BankAccount("Test1PrivateAcc1", 5050020);
            //BankAccount Test1BA2 = new BankAccount("Test1PrivateAcc2", 3000100);
            //List<BankAccount> Test1BAList = new List<BankAccount>();
            //Test1BAList.Add(Test1BA1);
            //Test1BAList.Add(Test1BA2);
            //Account Test1 = new Account("Test1", "Test1", "Test1FirstName", "Test1LastName", "Test1@email.com", Test1BAList);



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
                                Console.WriteLine(""); // Placeholder
                                break;
                            case 2:
                                Transfer Transaction = new Transfer();
                                Transaction.TransferMenyOptions();
                                break;
                            case 3:
                                Console.WriteLine(""); // Placeholder
                                break;
                            case 4:
                                Console.WriteLine(""); // placeholder
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