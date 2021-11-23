using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    class Accounts
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public BankAccount[] UserAccount { get; set; }

        public Accounts (string username,string password,BankAccount useraccount)
        {
            this.UserName = username;
            this.PassWord = password;
        }
    }
    class BankAccount
    {
        public double Balance { get; set; }

        public BankAccount (double balance = 25000)
        {
            this.Balance = balance;
        }
    }
}
