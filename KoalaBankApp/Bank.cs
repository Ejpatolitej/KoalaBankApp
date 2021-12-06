using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KoalaBankApp
{
    public class Bank
    {
        public void Run()
        {
            //welcome();
            List<User> Accounts = new List<User>();
            List<CurrencyRates> Rates = new List<CurrencyRates>();
            CurrencyRates ObjRates = new CurrencyRates("USD",9.02);
            Rates.Add(ObjRates);

            //user 1
            List<BankAccount> BAList1 = new List<BankAccount>();
            List<DollarBankAccount> DAList1 = new List<DollarBankAccount>();
            DollarBankAccount DAccount1 = new DollarBankAccount("Private-USD-Account",2500);
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000);

            User Account1 = new User("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1,DAList1 ,true);
            //user 2
            List<BankAccount> BAList2 = new List<BankAccount>();
            List<DollarBankAccount> DAList2 = new List<DollarBankAccount>();
            DollarBankAccount DAccount2 = new DollarBankAccount("Private-USD-Account", 2500);
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000);
            BankAccount BAccount3 = new BankAccount("Extra-Konto", 2925000);
            User Account2 = new User("Ludde", "hemlis", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, DAList2, false);
            //user 3
            List<BankAccount> BAList3 = new List<BankAccount>();
            List<DollarBankAccount> DAList3 = new List<DollarBankAccount>();
            DollarBankAccount DAccount3 = new DollarBankAccount("Private-USD-Account", 2500);
            BankAccount BAccount4 = new BankAccount("Privat-Konto", 2000000);
            BankAccount BAccount5 = new BankAccount("Extra-Konto", 1000000);
            User Account3 = new User("Elias", "hejhej123", "EliasL", "Lövdinger", "Eliasmail@mail.nu", BAList3, DAList3, false);

            //user 1 ADD
            Account1.BankAccountList.Add(BAccount1);
            Account1.DollarAccountList.Add(DAccount1);
            Accounts.Add(Account1);
            //user 2 ADD
            Account2.BankAccountList.Add(BAccount2);
            Account2.BankAccountList.Add(BAccount3);
            Account2.DollarAccountList.Add(DAccount2);
            Accounts.Add(Account2);
            //user 3 ADD
            Account3.BankAccountList.Add(BAccount4);
            Account3.BankAccountList.Add(BAccount5);
            Account3.DollarAccountList.Add(DAccount3);
            Accounts.Add(Account3);

            login inlog = new login();
            inlog.userLogin(Accounts,ObjRates);
        }
        public static void userMenu(List<User> Accounts, User ActiveUser , CurrencyRates ObjRates)
        {
            // Meny
            bool MenuActive = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome " +/*Name*/ " To KoalaBank!");
                Console.WriteLine();
                Console.WriteLine("1. Transfer" +
                    "\n2. Account information" +
                    "\n3. Search user" +
                    "\n4. Account Management" +
                    "\n5. Loans" +
                    "\n6. PLACEHOLDER" +
                    "\n7. PLACEHOLDER" +
                    "\n8. Logout");

                int menuChoice = 0;
                try
                {
                    menuChoice = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input a number instead");
                    Console.ReadKey();
                }
                switch (menuChoice)
                {
                    case 1:
                        Transfer Transaction = new Transfer();
                        Transaction.transferMenu(ActiveUser.BankAccountList, ActiveUser, Accounts);
                        break;
                    case 2:
                        ActiveUser.PrintAccountInfo(ActiveUser);
                        break;
                    case 3:
                        Console.Write("Enter a valid username: ");
                        string userinput = Console.ReadLine();
                        User Check = Accounts.Find(c => c.Username == userinput);
                        if (Check == null)
                        {
                            Console.WriteLine("User does not exist.");
                        }
                        else
                        {
                            Console.WriteLine("User {0} exists in the database.", Check.Username);
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        BankAccount B = new BankAccount();
                        B.AccountManagement(ActiveUser,Accounts,ObjRates);
                        break;
                    case 5:
                        Console.Clear();
                        Loans loans = new Loans();
                        loans.Loan(ActiveUser);
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        login logout = new login();
                        logout.userLogin(Accounts,ObjRates);
                        break;
                }
            } while (MenuActive);
            //No more meny
        }

        public void welcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("LOADING... ");

            for (int i = 0; i < 100; i++)
            {
                Console.CursorVisible = false;
                if (i > 0 && i < 10)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■         ]");
                    Thread.Sleep(50);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 20 && i < 30)
                {
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■        ]");
                    Thread.Sleep(60);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 30 && i < 40)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■       ]");
                    Thread.Sleep(70);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 40 && i < 50)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■■      ]");
                    Thread.Sleep(30);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 50 && i < 60)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■■■     ]");
                    Thread.Sleep(70);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 60 && i < 70)
                {
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■■■■    ]");
                    Thread.Sleep(50);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 70 && i < 80)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■■■■■   ]");
                    Thread.Sleep(70);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 80 && i < 90)
                {
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■■■■■■  ]");
                    Thread.Sleep(70);
                    Console.SetCursorPosition(0, 0);
                }
                if (i > 90 && i < 100)
                {
                    Console.WriteLine("LOADING:" + i + "%");
                    Console.WriteLine("[■■■■■■■■■ ]");
                    Thread.Sleep(70);
                    Console.SetCursorPosition(0, 0);
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("100%");
            Console.WriteLine("Koalabank.exe loading complete! ");
            Thread.Sleep(2000);
            Console.Clear();

            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"╔═════════════════════════════════════════════════════╗");
            Console.WriteLine(@"║ WELCOME TO                                          ║");
            Console.WriteLine(@"║   _  __           _         ____              _     ║");
            Console.WriteLine(@"║  | |/ /          | |       |     \           | |    ║");
            Console.WriteLine(@"║  | ' / ___   __ _| | __ _  | |_) | __ _ _ __ | | __ ║");
            Console.WriteLine(@"║  |  < / _ \ / _` | |/ _` | |  _ < / _` | '_ \| |/ / ║");
            Console.WriteLine(@"║  | . \ (_) | (_| | | (_| | | |_) | (_| | | | |   <  ║");
            Console.WriteLine(@"║  |_|\_\___/ \__,_|_|\__,_| |____/ \__,_|_| |_|_|\_\ ║");
            Console.WriteLine(@"╚═════════════════════════════════════════════════════╝");
            Console.WriteLine("Press any key to start the application. . .");
            Console.ReadKey();
        }
    }
}
