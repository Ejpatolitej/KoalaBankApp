﻿using System;
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

            LogIn(Accounts);


        }

        public bool LogIn(List<Accounts> Accounts)
        {

            return true;
        }
    }
}