using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class CurrencyRates
    {
        public string Name;
        public double DollarRate;
        
        public CurrencyRates(string name = "USD",double dollarRate = 9.02)
        {
            this.DollarRate = dollarRate;
            this.Name = name;
        }


        public static void PrintRate()
        {

        }
        public static void UpdateCurrencyRate(CurrencyRates ObjRates)
        {
            double minValue = 8.5;
            Random R = new Random();
            double NewRate = R.NextDouble();
            ObjRates.DollarRate = NewRate + minValue;
        }
    }
}
