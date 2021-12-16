using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class CurrencyRates
    {
        public string _Type;
        public double _Rate;

        public CurrencyRates(string type, double rate)
        {
            this._Rate = rate;
            this._Type = type;
        }
        public static void UpdateCurrencyRate(CurrencyRates objRates)
        {
            double minValue = 8.5;
            Random R = new Random();
            double newRate = R.NextDouble();
            objRates._Rate = newRate + minValue;
        }
    }
}
