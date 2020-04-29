using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsynchronousProgramming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsynchronousProgramming.Tests
{
    [TestClass()]
    public class MockStockServiceTests
    {
        [TestMethod()]
        public async Task SearchForStocksTest()
        {
            var service = new MockStockService();
            var stocks = await service.SearchForStocks("MSFT", CancellationToken.None);

            Assert.AreEqual(stocks.Count(), 2);
            Assert.AreEqual(stocks.Sum(stock => stock.Change), 0.7m);
        }
    }
}