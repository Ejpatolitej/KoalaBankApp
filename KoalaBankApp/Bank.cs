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



        }
    }
}
