using System;
using System.Collections.Generic;

namespace KoalaBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bankSession = new Bank();
            bankSession.Run();
        }
    }
}