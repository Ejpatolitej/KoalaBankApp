using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KoalaBankApp.Test
{
    [TestClass]
    public class KoalaBankAppTesting
    {
        [TestMethod]
        [Description("Test transfers 100sek from one account to another. Returning the balance of the from account")]
        //Given_When_Then
        public void Transfer_TransferMoney_FromAccount0_ToAccount1_100sek_Return_24900()
        {
            ///AAA
            
            //Arrange
            List<User> TestUsers = new List<User>();
            List<BankAccount> TestBAList = new List<BankAccount>();
            List<SavingsAccount> TestSavingsList = new List<SavingsAccount>();
            List<Transactions> TestTransactionsList = new List<Transactions>();
            BankAccount TestBAccount1 = new BankAccount("TestAcc1", 25000, "SEK");
            BankAccount TestBAccount2 = new BankAccount("TestAcc2", 2925000, "SEK");
            User TestUser = new User("Test", "TestPassword", "Test", "TestPerson", "Test@test.com", TestBAList, TestSavingsList, TestTransactionsList, false);
            TestUser.BankAccountList.Add(TestBAccount1);
            TestUser.BankAccountList.Add(TestBAccount2);
            TestUsers.Add(TestUser);

            Transfer transferTest1 = new Transfer();

            //Act
            transferTest1.TransferMoney(TestBAList, TestUser, TestTransactionsList);
            var actual = TestBAccount1.Balance;
            var expected = 24900;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [Description("The test creates a new user with default values. Should return Default first name as first name and should not be null")]
        //Given_When_Then
        public void User_CreateUser_Return_Default_First_Name_Return_IsNotNull()
        {
            //Arrange
            User TestUser = new User();
            List<User> Users = new List<User>();
            CurrencyRates TestUsdRates = new CurrencyRates("USD", 10);

            //Act
            TestUser.CreateUser(Users, false, TestUser, TestUsdRates);

            var actual = TestUser.Firstname;
            var expected = "Default First Name";

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(TestUser);
        }


        [TestMethod]
        [Description("This test adds 1000 sek to the active account, and should return 26000 sek")]
        //Given_When_Then
        public void Loans_NewAccountBalance_Add_1000_To_Active_User_Account_Return_26000()
        {
            //Arrange
            List<User> TestUsers = new List<User>();
            List<BankAccount> TestBAList = new List<BankAccount>();
            List<SavingsAccount> TestSavingsList = new List<SavingsAccount>();
            List<Transactions> TestTransactionsList = new List<Transactions>();
            BankAccount TestBAccount1 = new BankAccount("TestAcc1", 25000, "SEK");
            BankAccount TestBAccount2 = new BankAccount("TestAcc2", 2925000, "SEK");
            User TestUser = new User("Test", "TestPassword", "Test", "TestPerson", "Test@test.com", TestBAList, TestSavingsList, TestTransactionsList, false);
            TestUser.BankAccountList.Add(TestBAccount1);
            TestUser.BankAccountList.Add(TestBAccount2);
            TestUsers.Add(TestUser);

            Loans TestLoans = new Loans();

            //Act
            TestLoans.NewAccountBalance(1000, TestUser);

            var actual = TestUser.BankAccountList[0].Balance;
            var expected = 26000;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
