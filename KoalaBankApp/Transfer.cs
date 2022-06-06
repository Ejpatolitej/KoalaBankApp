using KoalaBankApp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Transfer
{
    //- [x]  Transfer between personal accounts
    //- [x]  transfer to other users
    //- [x]  User transaction log
    //- [ ]  (admin) Transactions dont happen instantly, limit it so it only happens every 15 mins

    public int accountFrom = 0;
    public int accountTo = 0;
    public double amountTotransfer = 0;
    public double amountLeft = 0;
    public double amountAdd = 0;
    public string goBack;
    public int stopTransaction = 0;

    public void transferMenu(List<BankAccount> accountsTransfer, User activeUser, List<User> accounts, List<Transactions> activeTransaction, CurrencyRates rates)
    {
        bool menuActive = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Transfer between personal accounts \n2. Transfer to other users\n3. International transfer \n4. See Transaction log\n5. Go Back");
            int menuChoice = 0;
            try
            {
                menuChoice = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please input a number instead");
                Console.ReadKey();
            }
            switch (menuChoice)
            {
                case 1:
                    TransferMoney(accountsTransfer, activeUser, activeTransaction);
                    break;
                case 2:
                    TransferToOtherUser(accountsTransfer, activeUser, accounts);
                    break;
                case 3:
                    BankAccount.InternationalTransfer(accounts, activeUser, rates);
                    break;
                case 4:
                    //Transaction log
                    Console.Clear();
                    Transactions.printTransactions(activeUser.UserTransactionsList);
                    Console.WriteLine("\nPress any key to return to transfer menu");
                    Console.ReadKey();
                    break;
                case 5:
                    menuActive = false;
                    break;
            }
        } while (menuActive);
    }
    public void TransferMoney(List<BankAccount> accountsTransfer, User activeUser, List<Transactions> activeTransaction)
    {
        //int maxAccounts = accountsTransfer.Count;
        //stopTransaction = 0;
        ////Account from
        //bool transferLoop = true;
        //while (transferLoop)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Which account would you like to transfer money from?");
        //    int nr = 1;
        //    foreach (BankAccount item in activeUser.BankAccountList)
        //    {
        //        Console.WriteLine("----------------------");
        //        Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
        //        nr++;
        //    }
        //    //if (activeUser.SavingsAccountList.Count > 0)
        //    //{
        //    //    Console.WriteLine("\nSavings Accounts:\n");
        //    //    foreach (var item in activeUser.SavingsAccountList)
        //    //    {
        //    //        Console.WriteLine("----------------------");
        //    //        Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
        //    //        nr++;
        //    //    }
        //    //}
        //    try
        //    {
        //        accountFrom = int.Parse(Console.ReadLine());
        //        if (accountFrom <= maxAccounts && accountFrom > 0)
        //        {
        //            transferLoop = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Please enter an active account");
        //            Console.WriteLine("----------------------");
        //            Console.WriteLine("Would you like to continue with the transaction? Yes/No");
        //            goBack = Console.ReadLine();
        //            if (goBack.ToUpper() == "YES")
        //            {

        //            }
        //            else
        //            {
        //                stopTransaction = 1;
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Please input the account number with a number/numbers");
        //    }
        //}
        ////Account to
        //if (stopTransaction == 1)
        //{
        //    transferLoop = false;
        //}
        //else
        //{
        //    transferLoop = true;
        //}
        //while (transferLoop)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Which account would like the money transferred to?");
        //    int nr = 1;
        //    foreach (BankAccount item in activeUser.BankAccountList)
        //    {
        //        Console.WriteLine("----------------------");
        //        Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
        //        nr++;
        //    }
        //    //if (activeUser.SavingsAccountList.Count > 0)
        //    //{
        //    //    Console.WriteLine("\nSavings Accounts:\n");
        //    //    foreach (var item in activeUser.SavingsAccountList)
        //    //    {
        //    //        Console.WriteLine("----------------------");
        //    //        Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
        //    //        nr++;
        //    //    }
        //    //}
        //    try
        //    {
        //        accountTo = int.Parse(Console.ReadLine());
        //        if (accountTo <= maxAccounts && accountTo != accountFrom && accountTo > 0)
        //        {
        //            transferLoop = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Please enter a valid account. You can not choose the withdraw account.");
        //            Console.WriteLine("----------------------");
        //            Console.WriteLine("Would you like to continue with the transaction? Yes/No");
        //            goBack = Console.ReadLine();
        //            if (goBack.ToUpper() == "YES")
        //            {

        //            }
        //            else
        //            {
        //                stopTransaction = 1;
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Please input the account number with a number/numbers");
        //    }
        //}
        ////Amount
        //if (stopTransaction == 1)
        //{
        //    transferLoop = false;
        //}
        //else
        //{
        //    transferLoop = true;
        //}
        //while (transferLoop)
        //{
        //    Console.Clear();
        //    Console.WriteLine("What amount would you like to transfer?");
        //    try
        //    {
        //        amountTotransfer = double.Parse(Console.ReadLine());
        //        if (amountTotransfer > 0)
        //        {
        //            transferLoop = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("You can not transfer an amount lesser than, or equal to zero.");
        //            Console.WriteLine("Would you like to continue with the transaction? Yes/No");
        //            goBack = Console.ReadLine();
        //            if (goBack.ToUpper() == "YES")
        //            {

        //            }
        //            else
        //            {
        //                stopTransaction = 1;
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Please input the amount with numbers");
        //    }
        //}
        ////calc for amount to be removed and added
        //Console.Clear();
        //int coverage = 0;
        //if (stopTransaction != 1)
        //{
        //accountFrom = accountFrom - 1;
        //accountTo = accountTo - 1;

            accountFrom = 0;
            accountTo = 1;
            amountTotransfer = 100;
            stopTransaction = 0;
            if (accountsTransfer[accountFrom].Balance >= amountTotransfer && stopTransaction == 0)
            {
                // Transaction task
                Task transactionTask = Task.Run(() =>
                {
                    Transactions.AddTransaction(activeUser, amountTotransfer, accountsTransfer[accountFrom].AccountName, accountsTransfer[accountTo].AccountName); ;
                });
                accountsTransfer[accountFrom].Balance -= amountTotransfer;
                accountsTransfer[accountTo].Balance += amountTotransfer;
                //coverage = 1;
            }
        }
    //    if (coverage == 1)
    //    {
    //        double newAmountFrom = accountsTransfer[accountFrom].Balance;
    //        double newAmountTo = accountsTransfer[accountTo].Balance;

    //        Console.WriteLine("New balance of the account money was transferred from: " + Math.Round(newAmountFrom, 2));
    //        Console.WriteLine("New balance of the account money was transferred to: " + Math.Round(newAmountTo, 2));
    //        Console.ReadKey();
    //    }
    //    else
    //    {
    //        Console.WriteLine("The tranfer was terminated. Have a nice day!");
    //        Console.ReadKey();
    //    }

    //}
    public void TransferToOtherUser(List<BankAccount> accountsList, User activeUser, List<User> userList)
    {
        Console.Clear();
        stopTransaction = 0;
        string accountToName = "";
        // List user accounts
        int maxAccounts = accountsList.Count;
        int nr = 1;
        // select user account
        bool transferLoop = true;
        while (transferLoop)
        {
            Console.Clear();
            Console.WriteLine("Which account would you like to transfer money from?");
            nr = 1;
            foreach (BankAccount item in accountsList)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
                nr++;
            }
            try
            {
                accountFrom = int.Parse(Console.ReadLine());
                if (accountFrom <= maxAccounts && accountFrom > 0)
                {
                    accountFrom = accountFrom - 1;
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter an active account");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Would you like to continue with the transaction? Yes/No");
                    goBack = Console.ReadLine();
                    if (goBack.ToUpper() == "YES")
                    {

                    }
                    else
                    {
                        stopTransaction = 1;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the account number with a number/numbers");
                Console.WriteLine("Press any button to try again");
                Console.ReadLine();
            }
        }
        //Change to index instead of name in future
        if (stopTransaction == 1)
        {
            transferLoop = false;
        }
        else
        {
            transferLoop = true;
        }
        while (transferLoop)
        {
            Console.Clear();
            Console.WriteLine("Which user would you like the money transferred to:"); //Choose user to transfer to
            nr = 1;
            foreach (User item in userList)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nr + ". Account name: {0}", item.Username);
                nr++;
            }
            try
            {
                accountToName = Console.ReadLine();
                User userTransfer1 = userList.Find(c => c.Username == accountToName);

                if (accountToName == userTransfer1.Username)
                {
                    transferLoop = false;
                }
                else if (accountToName != userTransfer1.Username)
                {
                    Console.WriteLine("User not found!");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Would you like to continue with the transaction? Yes/No");
                    goBack = Console.ReadLine();
                    if (goBack.ToUpper() == "YES")
                    {

                    }
                    else
                    {
                        stopTransaction = 1;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the account number with a number/numbers");
                Console.WriteLine("Press any button to try again");
                Console.ReadLine();
            }
        }
        if (stopTransaction == 1)
        {
            transferLoop = false;
        }
        else
        {
            transferLoop = true;
        }
        while (transferLoop)
        {
            Console.Clear();
            Console.WriteLine("What amount would you like to transfer?");   // Amount of money to transfer
            try
            {
                amountTotransfer = double.Parse(Console.ReadLine());
                if (amountTotransfer > 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("You can not transfer an amount lesser than, or equal to zero.");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Would you like to continue with the transaction? Yes/No");
                    goBack = Console.ReadLine();
                    if (goBack.ToUpper() == "YES")
                    {

                    }
                    else
                    {
                        stopTransaction = 1;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the amount with numbers");
                Console.WriteLine("Press any button to try again");
                Console.ReadLine();
            }
        }
        //calc for amount to be removed and added
        Console.Clear();

        User userTransfer = userList.Find(c => c.Username == accountToName);
        List<BankAccount> namn = userTransfer.BankAccountList.FindAll(c => c.Balance > 0);
        BankAccount name = namn.Find(c => c.Balance > 0);
        int coverage = 0;

        if (accountsList[accountFrom].Balance >= amountTotransfer && stopTransaction != 1)
        {
            accountsList[accountFrom].Balance -= amountTotransfer;
            namn[0].Balance += amountTotransfer;
            coverage = 1;
        }
        if (coverage == 1)
        {
            double newAmountFrom = accountsList[accountFrom].Balance;
            double newAmountTo = amountTotransfer;

            Console.WriteLine("New balance of the account money was transferred from: " + Math.Round(newAmountFrom, 2));
            Console.WriteLine("You have transfered {0} to {1}: ", Math.Round(newAmountTo, 2), accountToName);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("The tranfer was terminated. Have a nice day!");
            Console.ReadKey();
        }
    }
}