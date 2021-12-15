using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KoalaBankApp
{
    public class Transactions
    {
        public Transactions(double transAmount, string acntFrom, string acntTo)
        {
            this.transferAmount = transAmount;
            this.accountFrom = acntFrom;
            this.accountTo = acntTo;
        }
        public double transferAmount { get; set; }
        public string accountFrom { get; set; }
        public string accountTo { get; set; }
       
        public static void AddTransaction(User activeUser, double trans, string accountFrom, string accountTo)
        {
            bool alarm = false;
            while (alarm == false)
            {
                Thread.Sleep(10000);
                
                var transactionTimer = DateTime.Now;
                if (transactionTimer.Minute == 20 || transactionTimer.Minute == 15 || transactionTimer.Minute == 30 || transactionTimer.Minute == 45)
                {
                    Transactions activeTransaction = new Transactions(trans, accountFrom, accountTo);
                    activeUser.UserTransactionsList.Add(activeTransaction);
                    alarm = true;
                }
            }
            Console.WriteLine("Transaction complete!");
            Console.ReadKey();
            
        }
        public static void printTransactions(List<Transactions> myTransactions)
        {
            myTransactions.Reverse();
            Console.WriteLine("Latest transaction at the top");
            int nr = 1;
            int integer = myTransactions.Count;
            integer = integer - 1;
            foreach (var item in myTransactions)
            {
                Console.WriteLine("Transaction " + nr + ": " + "You have transferd amount: {0} from account {1} to account {2}", item.transferAmount, item.accountFrom, item.accountTo);
                nr++;
            }
            myTransactions.Reverse();
        }

        public static void timeUntilTransaction()
        {
            var count = DateTime.Now;
            Console.WriteLine("Time left until next transaction:" );

        }

    }
}
