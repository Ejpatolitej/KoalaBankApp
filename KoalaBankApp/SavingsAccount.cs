using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class SavingsAccount : BankAccount
    {
        public double _Interest;
        private static Random random = new Random();

        public SavingsAccount(string accountName = "Savings-Account", double balance = 0, string type = "Default", double interest = 1.02)
        {
            this._AccountName = accountName;
            this._Balance = balance;
            this._Type = type;
            this._Interest = interest;
        }
        public double Interest
        {
            get { return _Interest; }
            set { _Interest = value; }
        }
        public double randomInterest()
        {
            double interest = RandomNumber(1.01, 1.25);
            interest = (interest - 1) * 100;
            return interest;
        }
        private static double RandomNumber(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
    }
}
