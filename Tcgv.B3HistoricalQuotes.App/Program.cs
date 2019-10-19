using System;
using Tcgv.B3HistoricalQuotes.IO;

namespace Tcgv.B3HistoricalQuotes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = 2019;
            var symbol = "PETR4";

            var quotes = new QuotesFileReader().ReadFile("Resources/COTAHIST_A" + year + ".ZIP");

            Console.WriteLine("DATE\tCLOSING");
            foreach (var q in quotes[symbol])
                Console.WriteLine("{0:yyyy-MM-dd}\t{1:00.00}", q.Date, q.Close);

            Console.ReadKey();
        }
    }
}
