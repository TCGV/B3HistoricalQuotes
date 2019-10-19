using System;
using System.Globalization;

namespace Tcgv.B3HistoricalQuotes.DataModel
{
    public class Quote
    {
        public Quote(string line)
        {
            this.Date = ReadDate(line, 03, 10);

            this.Symbol = Substring(line, 13, 24).Trim();

            this.Open = ReadDouble(line, 57, 69);
            this.Max = ReadDouble(line, 70, 82);
            this.Min = ReadDouble(line, 83, 95);
            this.Avg = ReadDouble(line, 96, 108);
            this.Close = ReadDouble(line, 109, 121);

            this.Maturity = ReadDate(line, 203, 210);
            this.Strike = ReadDouble(line, 189, 201);

            this.Deals = ReadInt(line, 148, 152);
            this.Volume = ReadLong(line, 153, 170);
        }

        public DateTime Date { get; private set; }

        public string Symbol { get; private set; }

        public double Open { get; private set; }

        public double Max { get; private set; }

        public double Min { get; private set; }

        public double Avg { get; private set; }

        public double Close { get; private set; }

        public DateTime Maturity { get; private set; }

        public double Strike { get; private set; }

        public int Deals { get; private set; }

        public long Volume { get; private set; }

        private DateTime ReadDate(string line, int s, int e)
        {
            DateTime dt;
            DateTime.TryParseExact(
                Substring(line, s, e),
                "yyyyMMdd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dt
            );
            return dt;
        }

        private double ReadDouble(string line, int s, int e)
        {
            return double.Parse(Substring(line, s, e)) / 100;
        }

        private int ReadInt(string line, int s, int e)
        {
            return int.Parse(Substring(line, s, e));
        }

        private long ReadLong(string line, int s, int e)
        {
            return long.Parse(Substring(line, s, e));
        }

        private string Substring(string line, int start, int end)
        {
            return line.Substring(start - 1, end - start + 1);
        }
    }
}
