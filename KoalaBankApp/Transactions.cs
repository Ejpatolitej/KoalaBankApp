using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class Transactions
    {
        List<double> TranscationList1 = new List<double>();
        List<string> TranscationList2 = new List<string>();
        List<string> TranscationList3 = new List<string>();
        public void AddTransactions1(double trans)
        {
            TranscationList1.Add(trans);

        }
        public void AddTransactions2(string accountName)
        {
            TranscationList2.Add(accountName);
        }
        public void AddTransactions3(string accountName)
        {
            TranscationList3.Add(accountName);
        }
        public void printTransactions()
        {
            int nr = 1;
            for (int i = 0; i < TranscationList1.Count; i++)
            {
                Console.WriteLine("Transaction "+nr+": "+"You have transferd amount: {0} from account {1} to account {2}",TranscationList1[i],TranscationList2[i],TranscationList3[i]);
                nr++;
            }
        }

    }
}
