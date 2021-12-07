using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class CurrencyRates
    {
        public string _Type;
        public double _Rate;
        
        public CurrencyRates(string Type,double Rate)
        {
            this._Rate = Rate;
            this._Type = Type;
        }

        public static void UpdateCurrencyRate(CurrencyRates ObjRates)
        {
            double minValue = 8.5;
            Random R = new Random();
            double NewRate = R.NextDouble();
            ObjRates._Rate = NewRate + minValue;
        }

        public static double SEKtoUSD(double AmounttoCheck, CurrencyRates ObjRates)
        {
            return AmounttoCheck / ObjRates._Rate;
        }

        public static double USDtoSEK(double AmounttoCheck, CurrencyRates ObjRates)
        {
            return AmounttoCheck * ObjRates._Rate;
        }
    }
}
