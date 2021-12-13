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

    public void transferMenu(List<BankAccount> AccountsTransfer, User activeUser, List<User> Accounts, List <Transactions> ActiveTransaction,CurrencyRates Rates)
    {
        bool MenuActive = true;
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
                    TransferMoney(AccountsTransfer, activeUser, ActiveTransaction);
                    break;
                case 2:
                    transferToOtherUser(AccountsTransfer, activeUser, Accounts);
                    break;
                case 3:
                    BankAccount.InternationalTransfer(Accounts,activeUser,Rates);
                    break;
                case 4:
                    Console.Clear();
                    Transactions.printTransactions(activeUser.UserTransactionsList);
                    Console.WriteLine("\nPress any key to return to transfer menu");
                    Console.ReadKey();
                    //Transaction log
                    break;
                case 5:
                    MenuActive = false;
                    break;
            }
        } while (MenuActive);
    }
    public void TransferMoney(List<BankAccount> AccountsTransfer, User activeUser, List<Transactions> ActiveTransaction)
    {
        int maxAccounts = AccountsTransfer.Count;

        Console.Clear();
        bool transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("From what account you wanna move money from?");
            int nr = 1;
            foreach (BankAccount item in activeUser.BankAccountList)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
                nr++;
            }
            if (activeUser.SavingsAccountList.Count > 0)
            {
                Console.WriteLine("\nSavings Accounts:\n");
                foreach (var item in activeUser.SavingsAccountList)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
                    nr++;
                }
            }
            try
            {
                accountFrom = int.Parse(Console.ReadLine());
                if (accountFrom <= maxAccounts && accountFrom > 0)
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
                Console.Clear();
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }
        Console.Clear();
        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("To what account you wanna move money to?");
            int nr = 1;
            foreach (BankAccount item in activeUser.BankAccountList)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
                nr++;
            }
            if (activeUser.SavingsAccountList.Count > 0)
            {
                Console.WriteLine("\nSavings Accounts:\n");
                foreach (var item in activeUser.SavingsAccountList)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
                    nr++;
                }
            }
            try
            {
                accountTo = int.Parse(Console.ReadLine());
                if (accountTo <= maxAccounts && accountTo != accountFrom && accountTo > 0)
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
                Console.Clear();
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }
        Console.Clear();
        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("How much money would u like to transfer");
            try
            {
                amountTotransfer = double.Parse(Console.ReadLine());
                if (amountTotransfer > 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("You can not transfer a amount below zero or equal to");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the amount with numbers");
            }
        }
        //calc for amount to be removed and added
        Console.Clear();
        accountFrom = accountFrom - 1;
        accountTo = accountTo - 1;
        int coverage = 0;
        if (AccountsTransfer[accountFrom].Balance >= amountTotransfer)
        {
            // Transaction task
            Task transactionTask = Task.Run(() =>
            {
                Transactions.AddTransaction(activeUser, amountTotransfer, AccountsTransfer[accountFrom].AccountName, AccountsTransfer[accountTo].AccountName); ;
            });

            //ActiveTransaction.AddTransactions1(amountTotransfer);
            //ActiveTransaction.AddTransactions2(AccountsTransfer[accountFrom].AccountName);
            //ActiveTransaction.AddTransactions3(AccountsTransfer[accountTo].AccountName);

            AccountsTransfer[accountFrom].Balance -= amountTotransfer;
            AccountsTransfer[accountTo].Balance += amountTotransfer;
            coverage = 1;
        }
        if (coverage == 1)
        {
            double newAmountFrom = AccountsTransfer[accountFrom].Balance;
            double newAmountTo = AccountsTransfer[accountTo].Balance;

            Console.WriteLine("New balance of the account money was moved from: " + Math.Round(newAmountFrom, 2));
            Console.WriteLine("New balance of the account money was moved to: " + Math.Round(newAmountTo, 2));
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("The tranfer was terminated due to insufficent funds");
            Console.ReadKey();
        }
    }
    public void transferToOtherUser(List<BankAccount> ActiveUserTransfer, User ActiveUser, List<User> Accounts)
    {
        string accountToName = "";
        // LIST USER ACCOUNTS
        Console.Clear();
        int maxAccounts = ActiveUserTransfer.Count;
        int nr = 1;
        // SELECT USERACCOUNT
        bool transferLoop = true;
        while (transferLoop)
        {
            Console.Clear();
            Console.WriteLine("Select the account you want to transfer money from: ");
            nr = 1;
            foreach (BankAccount item in ActiveUserTransfer)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
                Console.WriteLine("----------------------");
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
                    Console.WriteLine("Please enter a active account");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the accountnumber with a number/numbers");
                Console.WriteLine("Press any button to try again");
                Console.ReadLine();
            }
        }
        transferLoop = true;

        //!
        //Change to index instead of name in future
        //!

        while (transferLoop)
        {
            Console.Clear();
            Console.WriteLine("Select the user that you want to transfer money to:"); //Choose user to transfer to
            nr = 1;
            foreach (User item in Accounts)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nr + ". Account name: {0}", item.Username);
                Console.WriteLine("----------------------");
                nr++;
            }
            try
            {
                accountToName = Console.ReadLine();
                User userTransfer1 = Accounts.Find(c => c.Username == accountToName);

                if (accountToName == userTransfer1.Username)
                {
                    transferLoop = false;
                }
                else if (accountToName != userTransfer1.Username)
                {
                    Console.WriteLine("User not found!");
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
        transferLoop = true;
        while (transferLoop)
        {
            Console.Clear();
            Console.WriteLine("How much money would u like to transfer");   // Amount of money to transfer
            try
            {
                amountTotransfer = double.Parse(Console.ReadLine());
                if (amountTotransfer > 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("You can not transfer a amount below zero or equal to");
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

        User userTransfer = Accounts.Find(c => c.Username == accountToName);
        List<BankAccount> namn = userTransfer.BankAccountList.FindAll(c => c.Balance > 0);
        BankAccount name = namn.Find(c => c.Balance > 0);
        int coverage = 0;

        if (ActiveUserTransfer[accountFrom].Balance >= amountTotransfer)

        {
            ActiveUserTransfer[accountFrom].Balance -= amountTotransfer;
            namn[0].Balance += amountTotransfer;
            coverage = 1;
        }
        if (coverage == 1)
        {
            double newAmountFrom = ActiveUserTransfer[accountFrom].Balance;
            double newAmountTo = amountTotransfer;

            Console.WriteLine("New balance of the account money was moved from: " + Math.Round(newAmountFrom, 2));
            Console.WriteLine("You have transfered {0} to {1}: ", Math.Round(newAmountTo, 2), accountToName);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("The tranfer was terminated due to insufficent funds");
            Console.ReadKey();
        }
    }
}