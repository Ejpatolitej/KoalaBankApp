using System;
using System.Collections.Generic;
using System.Text;

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
            Transactions activeTransaction = new Transactions(trans, accountFrom, accountTo);
            activeUser.UserTransactionsList.Add(activeTransaction);
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

    }
}
