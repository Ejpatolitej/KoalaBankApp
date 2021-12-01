﻿using System;
using System.Collections.Generic;
using System.Text;


namespace KoalaBankApp
{
    public class Loans
    {
        private static Random random = new Random();

        //Create a random for the interest
        private static double RandomNumber(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }

        //Adding all the accounts for the user for total balance
        private static double TotalBalance(List<BankAccount> BAList)
        {
            double total = 0;
            foreach (BankAccount item in BAList)
            {
                total += item.Balance;
            }
            return total;
        }

        //Calculates interest for the loan
        static void Interest(double loanAmount)
        {
            double interest = RandomNumber(1.01, 1.25);
            Console.WriteLine("Interest: {0:f2}%", (interest - 1) * 100);

            for (int i = 1; i <= 20; i++)
            {
                double total = loanAmount * Math.Pow(interest, i);
                if (i == 1 || i % 5 == 0)
                {
                    Console.WriteLine("Loan with interest after {0} years: {1:f2}", i, total);
                }
            }
        }

        //Takes balance from user account, adds the loan, and puts it back
        private static void NewAccountBalance(List<string> nameList, List<double> balanceList, double loanAmount, Account activeUser)
        {
            bool keepTrying = true;
            do
            {
                int index = Int32.Parse(Console.ReadLine()) - 1;
                try
                {
                    BankAccount bankAccount = new BankAccount();
                    bankAccount.Balance = balanceList[index] + loanAmount;
                    bankAccount.AccountName = nameList[index];

                    activeUser.Useraccount.RemoveAt(index);
                    activeUser.Useraccount.Insert(index, bankAccount);
                    keepTrying = false;
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            } while (keepTrying == true);
        }

        //Loan main method
        public void Loan(Account activeUser)
        {


            double balanceTotal = TotalBalance(activeUser.Useraccount);
            double loanMax = balanceTotal * 5;
            Console.WriteLine("You have a total of " + balanceTotal + " kr. in your account." +
                "\nYour maximum for the loan is " + loanMax + " kr.");
            Console.WriteLine("Enter loan amount: ");
            double loanAmount = Double.Parse(Console.ReadLine());

            if (loanAmount > loanMax)
            {
                Console.Clear();
                Console.WriteLine("You can not loan that amount.");
                Console.WriteLine("Maximum amount you can loan: " + loanMax);
                Console.WriteLine("Please try again.");
            }
            else
            {
                Interest(loanAmount);
                Console.WriteLine("\nWould you like to loan the amount " + loanAmount + " kr?");
                Console.WriteLine("Yes / No");
                string userChoice = Console.ReadLine().ToUpper();
                do
                {
                    if (userChoice == "NO")
                    {
                        Console.Clear();
                        Console.WriteLine("You did not approve of the loan. Heading back to menu.");
                        break;
                    }
                    else if (userChoice == "YES")
                    {
                        Console.Clear();
                        Console.WriteLine("Loan approved. Which account would you like the money transferred to?");
                        int i = 0;
                        List<double> balanceList = new List<double>();
                        List<string> nameList = new List<string>();
                        foreach (var item in activeUser.Useraccount)
                        {
                            i++;
                            Console.WriteLine("{0}: {1}", i, item.AccountName);
                            Console.WriteLine("     {0} kr.", item.Balance);
                            balanceList.Add(item.Balance);
                            nameList.Add(item.AccountName);
                        }
                        NewAccountBalance(nameList, balanceList, loanAmount, activeUser);

                        Console.Clear();
                        i = 0;
                        foreach (var item in activeUser.Useraccount)
                        {
                            i++;
                            Console.WriteLine("New balance in accounts: ");
                            Console.WriteLine("{0}: {1}", i, item.AccountName);
                            Console.WriteLine("     {0} kr.", item.Balance);
                        }
                        Console.WriteLine("\nPress any key to go back to menu");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter YES or NO");
                        Console.WriteLine("\nWould you like to loan the amount " + loanAmount + " kr?");
                        userChoice = Console.ReadLine().ToUpper();
                    }
                } while (userChoice != "NO" || userChoice != "YES");
            }
        }
    }
}
