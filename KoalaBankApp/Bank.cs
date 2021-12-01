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
            welcome();

            List<Account> Accounts = new List<Account>();

            List<BankAccount> BAList1 = new List<BankAccount>();
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000);
            Account Account1 = new Account("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, false);
            //UNDER TESTNING
            BankAccount dollar = new DollarBankAccount();
            BankAccount euro = new EuroBankAccount();
            BankAccount nor = new NORBankAccount();
            BankAccount den = new DENBankAccount();
            //--------------
            List<BankAccount> BAList2 = new List<BankAccount>();
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000);
            BankAccount BAccount3 = new BankAccount("Extra-Konto", 2925000);
            Account Account2 = new Account("Ludde", "hejhej123", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, false);

            Account1.Useraccount.Add(BAccount1);
            // TESTNING
            Account1.Useraccount.Add(dollar);
            Account1.Useraccount.Add(euro);
            Account1.Useraccount.Add(nor);
            Account1.Useraccount.Add(den);
            //--------------
            Accounts.Add(Account1);

            Account2.Useraccount.Add(BAccount2);
            Accounts.Add(Account2);
            Account2.Useraccount.Add(BAccount3);
            Accounts.Add(Account2);

            login inlog = new login();
            inlog.userLogin(Accounts);
        }

        public static void userMenu(List<Account> Accounts, Account ActiveUser)
        {

            // Meny
            bool MenyAcitve = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome " +/*Name*/ " To KoalaBank!");

                Console.WriteLine("Press 1 Transfer\nPress 2 Account information\nPress 3 Search user\nPress 4 Account Management\nPress 5 Logout");

                int menyChoice = 0;
                try
                {
                    menyChoice = Int32.Parse(Console.ReadLine());
                    if (menyChoice > 5) // to high number
                    {
                        Console.WriteLine("please enter a number that is a option");
                    }
                    else if (menyChoice < 1) // to low number
                    {
                        Console.WriteLine("please enter a number that is a option");
                    }
                    else //Purfect
                    {
                            case 1:
                                Transfer transaction = new Transfer();
                                transaction.TransferMenyOptions(ActiveUser, ActiveUser.Useraccount);
                                break;
                            case 2:

                                ActiveUser.PrintAccountInfo(Accounts, ActiveUser);
                                break;
                            case 3:
                                Console.Write("Skriv in ett Giltligt användarnamn: ");
                                string userinput = Console.ReadLine();

                                Account Check = Accounts.Find(c => c.Username == userinput);
                                if (Check == null)
                                {
                                    Console.WriteLine("Användare Existerar inte.");
                                }
                                else
                                {
                                    Console.WriteLine("Användare: {0} finns i databasen.", Check.Username);
                                }
                                Console.ReadKey();
                                break;
                            case 4:
                                BankAccount B = new BankAccount();
                                B.CreateBankAccount(Accounts, ActiveUser);
                                break;
                            case 5:
                                login logout = new login();
                                logout.userLogin(Accounts);
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input a number instead");
                }
            } while (MenyAcitve);
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