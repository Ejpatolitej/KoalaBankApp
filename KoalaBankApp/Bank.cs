using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KoalaBankApp
{
    public class Bank
    {
        public void Run()
        {
            //Welcome();

            List<User> Users = new List<User>();
            List<CurrencyRates> Rates = new List<CurrencyRates>();
            CurrencyRates USDRates = new CurrencyRates("USD", 9.02);
            CurrencyRates SEKRates = new CurrencyRates("SEK", 0);
            Rates.Add(USDRates);
            Rates.Add(SEKRates);

            //user 1
            List<BankAccount> BAList1 = new List<BankAccount>();
            List<SavingsAccount> SavingsList1 = new List<SavingsAccount>();
            List<Transactions> TransactionsList1 = new List<Transactions>();
            BankAccount DAccount1 = new BankAccount("Private-USD-Account", 2500, "USD");
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000, "SEK");
            User Account1 = new User("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, SavingsList1, TransactionsList1, true);
            Account1.BankAccountList.Add(BAccount1);
            Account1.BankAccountList.Add(DAccount1);
            Users.Add(Account1);

            //user 2
            List<BankAccount> BAList2 = new List<BankAccount>();
            List<SavingsAccount> SavingsList2 = new List<SavingsAccount>();
            List<Transactions> TransactionsList2 = new List<Transactions>();
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000, "SEK");
            BankAccount BAccount3 = new BankAccount("Extra-Konto", 2925000, "USD");
            User Account2 = new User("Ludde", "hemlis", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, SavingsList2, TransactionsList2, false);
            Account2.BankAccountList.Add(BAccount2);
            Account2.BankAccountList.Add(BAccount3);
            Users.Add(Account2);

            //user 3
            List<BankAccount> BAList3 = new List<BankAccount>();
            List<SavingsAccount> SavingsList3 = new List<SavingsAccount>();
            List<Transactions> TransactionsList3 = new List<Transactions>();
            BankAccount BAccount4 = new BankAccount("Privat-Konto", 2000000, "SEK");
            BankAccount BAccount5 = new BankAccount("Extra-Konto", 1000000, "SEK");
            User Account3 = new User("Elias", "hejhej123", "Eliasl", "Lövdinger", "elias.lovdinger@xX13Cool37Xx", BAList3, SavingsList3, TransactionsList3, false);
            Account3.BankAccountList.Add(BAccount4);
            Account3.BankAccountList.Add(BAccount5);
            Users.Add(Account3);

            Login login = new Login();
            login.UserLogin(Users, USDRates);
        }
        public static void UserMenu(List<User> Users, User ActiveUser, CurrencyRates Rates)
        {
            // Meny
            bool MenuActive = true;
            do
            {
                Console.Clear();

                ////Clock
                //Task clockTask = Task.Run(() =>
                //{
                //    Bank.Clock();
                //});
                Console.WriteLine(@"Welcome " + ActiveUser.Firstname + " " + ActiveUser.Lastname + " To KoalaBank! O( ^ ■ ^)O");

                Console.WriteLine();
                Console.WriteLine("1. Transfer" +
                    "\n2. Account information" +
                    "\n3. Account management" +
                    "\n4. Take new loan" +
                    "\n5. PLACEHOLDER" +
                    "\n6. PLACEHOLDER" +
                    "\n7. Logout");

                int menuChoice = 0;
                try
                {
                    menuChoice = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input a valid number!");
                    Console.ReadKey();
                }
                switch (menuChoice)
                {
                    case 1:
                        Transfer Transaction = new Transfer();
                        Transaction.transferMenu(ActiveUser.BankAccountList, ActiveUser, Users, ActiveUser.UserTransactionsList,Rates);
                        break;
                    case 2:
                        ActiveUser.PrintAccountInfo(ActiveUser, Rates);
                        break;
                    case 3:
                        BankAccount B = new BankAccount();
                        B.AccountManagement(ActiveUser, Users, Rates);
                        break;
                    case 4:
                        Console.Clear();
                        Loans loans = new Loans();
                        loans.Loan(ActiveUser);
                        break;
                    case 5:
                        Transactions.timeUntilTransaction();
                        break;
                    case 6:
                        break;
                    case 7:
                        Login logout = new Login();
                        logout.UserLogin(Users, Rates);
                        break;
                }
            } while (MenuActive);
            //No more menu
        }
        //public static void Clock()
        //{
        //    var clockTimer = DateTime.Now;
        //    bool alarm = false;
        //    while (DateTime.Now != clockTimer)
        //    {
        //        Console.WriteLine();
        //        clockTimer = DateTime.Now;
        //        Console.WriteLine("The clock is currently: "+clockTimer);
        //        Thread.Sleep(5000);
        //    }
        //}

        public void Welcome()
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
            Console.WriteLine();
            Console.WriteLine(@"             __                      __         ");
            Console.WriteLine(@"          .-'  `'.._...-----..._..-'`  ' -.     ");
            Console.WriteLine(@"         /                                \     ");
            Console.WriteLine(@"         |  ,   ,'                '.   ,  |     ");
            Console.WriteLine(@"          \  '-/                    \-'  /      ");
            Console.WriteLine(@"              |    /\   / \    /\    |          ");
            Console.WriteLine(@"              |    \/   | |    \/    |          ");
            Console.WriteLine(@"               \        \ /         /           ");
            Console.WriteLine(@"                '.   ==' ^ '==    .'            ");
            Console.WriteLine(@"                  `'------------'`              ");
            Console.WriteLine();
            Console.WriteLine("Press any key to start the application. . .");

            Console.ReadKey();

        }
    }
}
