using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public partial class BankAccount
    {
        public string _AccountName;
        public double _Balance;
        public string _Type;

        public BankAccount(string accountName = "Private-Account", double balance = 25000,string type = "Default")
        {
            this._AccountName = accountName;
            this._Balance = balance;
            this._Type = type;
        }
        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}

