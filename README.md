# B3HistoricalQuotes
Parser for Brazilian Stock Exchange (B3) historical quotes.

You can download yearly historical quotes data files from B3's website, from 1986 up to the current year:
* http://www.b3.com.br/pt_br/market-data-e-indices/servicos-de-dados/market-data/historico/mercado-a-vista/series-historicas/

The current year historical quotes data file is updated daily.

## Sample Code

```csharp
  var year = 2019;
  var symbol = "PETR4";

  var quotes = new QuotesFileReader().ReadFile("Resources/COTAHIST_A" + year + ".ZIP");

  Console.WriteLine("DATE\tCLOSING");
  foreach (var q in quotes[symbol])
      Console.WriteLine("{0:yyyy-MM-dd}\t{1:00.00}", q.Date, q.Close);
```

## Licensing

This code is released under the MIT License:

Copyright (c) TCGV.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
