using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class Loans
    {
        public double total;

        //Adding all the accounts for the user for total balance
        private static double TotalBalance(List<BankAccount> BAList)
        {
            double total = 0;
            foreach (BankAccount item in BAList)
            {
                total += item.Balance;
            }
            return total;
        }

        //Calculates interest for the loan
        static void Interest(double loanAmount)
        {
            for (int i = 1; i <= 20; i++)
            {
                double total = loanAmount * Math.Pow(1.02, i);
                if (i == 1 || i % 5 == 0)
                {
                    Console.WriteLine("Interest after {0} years: {1}", i, total);
                }
            }
        }

        //Loan main method
        public static void Loan(List<BankAccount> BAList)
        {
            double balanceTotal = TotalBalance(BAList);
            Console.WriteLine("Enter loan amount: ");
            double loanAmount = Double.Parse(Console.ReadLine());
            double loanMax = loanAmount * 5;

            if (loanMax > balanceTotal)
            {
                Console.WriteLine("Du kan inte låna så mycket.");
                Console.WriteLine("Du kan låna max " + loanMax);
            }
            else
            {
                Console.WriteLine("Om du lånar " + loanAmount + " med en ränta på 2% ser det ut såhär: ");
                Interest(loanAmount);
            }
        }
    }
}
