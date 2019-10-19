using System;

namespace Tcgv.B3HistoricalQuotes.DataModel
{
    public class OptionCode
    {
        public static string Call(string symbol, DateTime expiring)
        {
            return symbol.Substring(0, 4) + char.ConvertFromUtf32('A' + (expiring.Month - 1));
        }

        public static bool IsCall(string symbol)
        {
            return symbol.Length >= 5 && symbol[4] >= 'A' && symbol[4] <= 'L';
        }

        public static string Put(string symbol, DateTime expiring)
        {
            return symbol.Substring(0, 4) + char.ConvertFromUtf32('M' + (expiring.Month - 1));
        }

        public static bool IsPut(string symbol)
        {
            return symbol.Length >= 5 && symbol[4] >= 'M' && symbol[4] <= 'Y';
        }
    }
}
