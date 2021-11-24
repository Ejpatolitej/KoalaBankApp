using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    class Account
    {
        private string _UserName { get; set; }
        private string _PassWord { get; set; }
        private string _FirstName { get; set; }
        private string _LastName { get; set; }
        private string _Email { get; set; }
        public List<BankAccount> _UserAccount { get; set; }

        public Account (string username,string password,string firstname,string lastname,string email,List<BankAccount> useraccount)
        {
            this._UserName = username;
            this._PassWord = password;
            this._FirstName = firstname;
            this._LastName = lastname;
            this._Email = email;
            this._UserAccount = useraccount;
        }
        public string Username
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }
        public string Firstname
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string Lastname
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public List<BankAccount> Useraccount
        {
            get { return _UserAccount; }
            set { _UserAccount = value; }
        }
    }

    public class BankAccount
    {

        private string _AccountName;
        private double _Balance;

        public BankAccount(string accountname = "Privat-Konto", double balance = 0)
        {
            this._AccountName = accountname;
            this._Balance = balance;
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

        
 

    }
}
