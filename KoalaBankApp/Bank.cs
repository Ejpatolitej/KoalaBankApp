using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    class Bank
    {
        List<Accounts> Accounts = new List<Accounts>();
        BankAccount[] Useraccount = new BankAccount[5];

        public void Run()
        {
            login l1 = new login();
            l1.userLogin();


        }

     
    }
}
