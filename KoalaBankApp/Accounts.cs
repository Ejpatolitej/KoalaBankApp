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

        }
    }
    class BankAccount
    {
        public double Balance1 { get; set; }
        public double Balance2 { get; set; }
        public double Balance3 { get; set; }
        public double Balance4 { get; set; }
        public double Balance5 { get; set; }

        public BankAccount (double balance1,double balance2, double balance3,double balance4,double balance5)
        {

        }
    }
}
