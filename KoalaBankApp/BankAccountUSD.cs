using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public partial class BankAccount
    {
        public static void PrintAccounts(User ActiveUser, CurrencyRates Rates)
        {
            
            List<BankAccount> CheckSEK = ActiveUser.BankAccountList.FindAll(c => c.Type == "SEK");
            foreach (var i in CheckSEK)
            {
                double BalanceSEK = i.Balance;
                Console.WriteLine("{0}: {1} SEK", i.AccountName, Math.Round(BalanceSEK, 2));
                Console.WriteLine();
            }
            
            List<BankAccount> CheckUSD = ActiveUser.BankAccountList.FindAll(c => c.Type == "USD");
            foreach (var i in CheckUSD)
            {
                double BalanceUSD = i.Balance / Rates._Rate;
                Console.WriteLine("{0}: ${1}", i.AccountName, Math.Round(BalanceUSD, 2));
                Console.WriteLine();
            }

        }
    }
}
