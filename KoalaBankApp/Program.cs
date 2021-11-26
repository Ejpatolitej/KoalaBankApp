using System;
using System.Collections.Generic;

namespace KoalaBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank BankSession = new Bank();
            BankSession.Run();

            BankAccount Test1BA1 = new BankAccount("Test1PrivateAcc1", 5050020);
            BankAccount Test1BA2 = new BankAccount("Test1PrivateAcc2", 3000100);
            List<BankAccount> Test1BAList = new List<BankAccount>();
            Test1BAList.Add(Test1BA1);
            Test1BAList.Add(Test1BA2);
            Account Test1 = new Account("Test1", "Test1", "Test1FirstName", "Test1LastName", "Test1@email.com", Test1BAList);

            BankAccount Test2BA = new BankAccount("Test2PrivateAcc", 5050);
            List<BankAccount> Test2BAList = new List<BankAccount>();
            Account Test2 = new Account("Test2", "Test2", "Test2FirstName", "Test2LastName", "Test2@email.com", Test2BAList);

            BankAccount Test3BA = new BankAccount("Test3PrivateAcc", -1231032);
            List<BankAccount> Test3BAList = new List<BankAccount>();
            Account Test3 = new Account("Test3", "Test3", "Test3FirstName", "Test3LastName", "Test3@email.com", Test3BAList);





        }
    }


}
