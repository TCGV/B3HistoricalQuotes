using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Tcgv.B3HistoricalQuotes.DataModel;

namespace Tcgv.B3HistoricalQuotes.IO
{
    public class QuotesFileReader
    {
        static QuotesFileReader()
        {
            cache = new Dictionary<string, ILookup<string, Quote>>();
        }

        public ILookup<string, Quote> ReadFile(string filePath)
        {
            if (!cache.ContainsKey(filePath))
            {
                var val = ReadQuotes(filePath).ToLookup(q => q.Symbol);
                cache.Add(filePath, val);
            }
            return cache[filePath];
        }

        private IEnumerable<Quote> ReadQuotes(string filePath)
        {
            using (FileStream zipToOpen = new FileStream(filePath, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    foreach (var e in archive.Entries)
                    {
                        using (var s = new StreamReader(e.Open()))
                        {
                            while (!s.EndOfStream)
                            {
                                var l = s.ReadLine();
                                if (l.StartsWith(quote_line_code))
                                {
                                    yield return new Quote(l);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static string quote_line_code = "01";

        private static Dictionary<string, ILookup<string, Quote>> cache;
    }
}
