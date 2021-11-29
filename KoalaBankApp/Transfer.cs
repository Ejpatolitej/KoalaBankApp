using KoalaBankApp;
using System;
using System.Collections.Generic;
using System.Text;


public class Transfer
{
    //- [x]  Transfer between personal accounts
    //- [ ]  transfer to other users
    //- [ ]  User transaction log
    //- [ ]  (admin) Transactions dont happen instantly, limit it so it only happens every 15 mins


    public int maxAccounts = 5; //Max number of user accounts isnt decided yet.
    public int accountFrom = 0;
    public int accountTo = 0;
    public double amountTotransfer = 0;
    public double amountLeft = 0;
    public double amountAdd = 0;


    public void TransferMenyOptions(Account TransferActiveUser, List<BankAccount> TransferActiveAccount)
    {
        bool TransferMeny = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome " +/*Name*/ " !");
            Console.WriteLine("Press 1 Transfer Money between ur accounts \nPress 2 Make a payment  \nPress 3 Transaction logs \nPress 5 loggout ");

            int TransferMenyChoice = 0;

            try
            {
                TransferMenyChoice = Int32.Parse(Console.ReadLine());

                if (TransferMenyChoice > 5) // to high number  Might switch the 5 for something else dont know how many options this class will have yet
                {
                    Console.WriteLine("please enter a number that is a option");
                }
                else if (TransferMenyChoice < 1) // to low number
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
            switch (TransferMenyChoice)
            {
                case 1:
                    transfer();
                    transferCalc(TransferActiveUser, TransferActiveAccount);
                    break;
                case 2:

                    break;
                case 5:
                    Console.WriteLine("Logout");
                    TransferMeny = false;
                    break;
            }
        } while (TransferMeny);
    }

    public void transfer(/*List<Account> Accounts*/)
    {
        bool transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("From what account you wanna move money from?");
            try
            {
                accountFrom = int.Parse(Console.ReadLine());
                if (accountFrom <= maxAccounts && accountFrom >= 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a active account");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }

        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("To what account you wanna move money too?");
            accountTo = int.Parse(Console.ReadLine());
            try
            {
                if (accountTo <= maxAccounts && accountTo != accountFrom && accountTo >= 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("please enter a valid account and not the same account you wanna move from");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }

        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("How much money would u like to transfer");
            try
            {
                amountTotransfer = double.Parse(Console.ReadLine());
                if (amountTotransfer > 0) //maybe add some kind of variable that takes the "from" accounts balance and check so the amount isnt above that
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("You can not transfer a amount below zero or equal too");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please input the amount with numbers");
            }
        }
    }
    public void transferCalc(Account TransferCalc, List<BankAccount> TransferAccount)
    {
        //BankAccount Test1BA1 = new BankAccount("Test1PrivateAcc1", 5050020);
        //BankAccount Test1BA2 = new BankAccount("Test1PrivateAcc2", 3000100);
        //List<BankAccount> Test1BAList = new List<BankAccount>();
        //Test1BAList.Add(Test1BA1);
        //Test1BAList.Add(Test1BA2);
        //Account Test1 = new Account("Test1", "Test1", "Test1FirstName", "Test1LastName", "Test1@email.com", Test1BAList);

        //Calculation of amount to be left on account after transfering
        BankAccount transfer1 = TransferAccount.Find(c => c.AccountName == "Private account");
        BankAccount transfer2 = TransferAccount.Find(c => c.AccountName == "Private account");


        amountLeft = transfer1.Balance;
        amountLeft = amountLeft - amountTotransfer;
        transfer1.Balance = amountLeft;

        //Calculation of amount to be added to account after transfering
        amountAdd = transfer2.Balance;
        amountAdd = amountAdd + amountTotransfer;
        transfer2.Balance = amountAdd;

        Console.WriteLine(transfer1.Balance);
        Console.WriteLine(transfer2.Balance);
        Console.ReadLine();

    }
}
