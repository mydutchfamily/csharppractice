using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    public interface IStockService {
        Task<IEnumerable<StockPrice>> SearchForStocks(string ticker, CancellationToken cancellationToken);
    }

    public class MockStockService : IStockService
    {
        public Task<IEnumerable<StockPrice>> SearchForStocks(string ticker, CancellationToken cancellationToken)
        {
            var stocks = new List<StockPrice> {
                new StockPrice { Ticker = "MSFT", Change = 0.5m, ChangePercent = 0.75m },
                new StockPrice { Ticker = "MSFT", Change = 0.2m, ChangePercent = 0.15m },
                new StockPrice { Ticker = "GOOGL", Change = 0.3m, ChangePercent = 0.25m },
                new StockPrice { Ticker = "GOOGL", Change = 0.5m, ChangePercent = 0.65m }
            };

            return Task.FromResult(stocks.Where(stock => stock.Ticker == ticker));
        }
    }
    public class StockService: IStockService
    {
        int i = 0;
        public Task<IEnumerable<StockPrice>> SearchForStocks(string ticker, CancellationToken cancellationToken)
        {
            var loadedLinesTask = Task.Run(async () =>
            {
                var data = new List<StockPrice>();
                await Task.Delay((i++) * 1000);// increase delay for each interaction

                using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                {
                    var lines = new List<string>();
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return data;
                        }
                        if (line.Contains(ticker))
                            data.Add(Form1.createStock(line));
                    }
                    return (IEnumerable<StockPrice>)data;
                }
            }, cancellationToken);

            return loadedLinesTask;
        }
    }
}
