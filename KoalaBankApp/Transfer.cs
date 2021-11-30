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


    public void TransferMoney(List<BankAccount> AccountsTransfer, Account ActiveUserTransfer)
    {

        BankAccount Transfermoney1 = ActiveUserTransfer.Useraccount.Find(c => c.AccountName == "Privat-Konto");

        BankAccount Transfermoney2 = ActiveUserTransfer.Useraccount.Find(c => c.AccountName == "Extra-Konto");



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

        // ---------------------------------------------------------------
        //The actual transfer

        foreach (var item in ActiveUserTransfer.Useraccount)
        {
            amountLeft = item.Balance;
            break;
        }

        amountLeft = Transfermoney1.Balance;
        amountLeft = amountLeft - amountTotransfer;
        Transfermoney1.Balance = amountLeft;

        //Calculation of amount to be added to account after transfering
        amountAdd = Transfermoney2.Balance;
        amountAdd = amountAdd + amountTotransfer;
        Transfermoney2.Balance = amountAdd;



        Console.WriteLine(Transfermoney1.Balance);
        Console.WriteLine(Transfermoney2.Balance);
        Console.ReadKey();

        Console.ReadLine();
    }
}
