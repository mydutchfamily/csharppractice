using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace AsynchronousProgramming
{
    public partial class Form1 : Form
    {
        delegate void GuiDelegate();
        private Action<Task<string[]>> continuationAction;
        private Action loadFile;

        public static Func<string, StockPrice> createStock = s =>
        {
            var segments = s.Split(',');

            for (var i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
            return new StockPrice
            {
                Ticker = segments[0],
                TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                Volume = Convert.ToInt32(segments[6], CultureInfo.InvariantCulture),
                Change = Convert.ToDecimal(segments[7], CultureInfo.InvariantCulture),
                ChangePercent = Convert.ToDecimal(segments[8], CultureInfo.InvariantCulture),
            };
        };

        private string buttonCaption;
        public Form1()
        {
            InitializeComponent();

            continuationAction = t =>
            {// use results from previous Task
                var lines = t.Result;// may ask for result ONLY when task completed

                var data = new List<StockPrice>();

                foreach (var line in lines.Skip(1))
                {
                    data.Add(createStock(line));
                }

                GuiDelegate del = delegate
                {
                    dataGridView1.DataSource = data.Where(price => price.Ticker == tbTicker.Text).Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                    dataGridView1.Columns[0].Width = dataGridView1.Width;
                };

                dataGridView1.Invoke(del);
            };

            loadFile = () =>
            {
                var lines = File.ReadAllLines("StockPrices_Small.csv");

                var data = new List<StockPrice>();

                foreach (var line in lines.Skip(1))
                {
                    data.Add(createStock(line));
                }

                GuiDelegate del = delegate
                {
                    dataGridView1.DataSource = data.Where(price => price.Ticker == tbTicker.Text).Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                    dataGridView1.Columns[0].Width = dataGridView1.Width;
                };

                dataGridView1.Invoke(del);// use invoke to execute delegate in original thread;
            };
        }

        private async void btnSearchFiles_Click(object sender, EventArgs e)// "async void" - allowed only for event handler or delegate
        {
            try
            {
                await GetAllFiles(10);// execute in another thread and return to main thread
                // private async void GetAllFiles() - for such method exception will not be caught
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private async Task GetAllFiles(int quantity)
        // "async Task" ~~ "async void" - need to return current task
        // method with "async void" will not return occured exception
        {
            var allFiles = await ProcessDirectory("C:\\", quantity);

            dataGridView1.DataSource = allFiles.Select(p => new { value = p }).ToList();
            dataGridView1.Columns[0].Width = dataGridView1.Width;
        }

        private async Task<List<string>> ProcessDirectory(string path, int quantity)
        {
            return await Task.Run(() =>// code below will be executed in another thread
            {
                List<string> files = new List<string>();
                List<string> folders = new List<string>();
                folders.Add(path);

                while (folders.Count > 0)
                {
                    string currentFolder = folders[folders.Count - 1];
                    folders.RemoveAt(folders.Count - 1);
                    //string currentFolder = folders[0];// fail on access to folder "My Documents"
                    //folders.RemoveAt(0);

                    string[] filesInFolder = Directory.GetFiles(currentFolder);
                    foreach (var item in filesInFolder)
                    {
                        files.Add(item);
                        if (quantity != 0 && files.Count >= quantity) return files;
                    }
                    //files.AddRange(filesInFolder);

                    string[] directories = Directory.GetDirectories(currentFolder);
                    foreach (var item in directories)
                    {
                        folders.Add(item);
                    }
                    //folders.AddRange(directories);
                }
                return files;
            });
        }

        private async void btnTaskRun_Click(object sender, EventArgs e)
        {
            // execute the code WITHOUT blocking GUI interaction
            // without async/await code will be executed immediately, in another thread
            buttonCaption = btnTaskRun.Text;
            btnTaskRun.Text = "In progress";

            await Task.Run(loadFile);

            btnTaskRun.Text = buttonCaption;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // execute the code WITH blocking GUI interaction
            buttonCaption = btnLoadFile.Text;
            btnLoadFile.Text = "In progress";

            loadFile();

            btnLoadFile.Text = buttonCaption;
        }

        private void btnContinuetion_Click(object sender, EventArgs e)
        {
            buttonCaption = btnContinuetion.Text;
            btnContinuetion.Text = "In progress";

            var loadedLines = Task.Run(() =>
            {
                var lines = File.ReadAllLines("StockPrices_Small.csv");
                return lines;
            });

            var processStocks = loadedLines.ContinueWith(continuationAction);

            processStocks.ContinueWith(t =>
            {
                GuiDelegate del = delegate
                {
                    btnContinuetion.Text = buttonCaption;
                };

                btnContinuetion.Invoke(del);
            });
        }

        private void btnAsyncAsync_Click(object sender, EventArgs e)
        {
            buttonCaption = btnAsyncAsync.Text;
            btnAsyncAsync.Text = "In progress";

            var loadedLines = Task.Run(async () =>
            {
                using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                {
                    var lines = new List<string>();
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                    return lines.ToArray();
                }
            });

            var processStocks = loadedLines.ContinueWith(continuationAction);

            processStocks.ContinueWith(t =>
            {
                GuiDelegate del = delegate
                {
                    btnAsyncAsync.Text = buttonCaption;
                };

                btnAsyncAsync.Invoke(del);
            });
        }

        private void btnException_Click(object sender, EventArgs e)
        {
            buttonCaption = btnException.Text;
            btnException.Text = "In progress";

            var loadedLines = Task.Run(() =>
            {
                var lines = File.ReadAllLines("SSSSSStockPrices_Small.csv");
                return lines;
            });

            var processStocks = loadedLines.ContinueWith(continuationAction, TaskContinuationOptions.OnlyOnRanToCompletion);

            loadedLines.ContinueWith(t =>
            {
                GuiDelegate del = delegate
                {
                    textBox1.Text = t.Exception.InnerException.Message;
                };

                textBox1.Invoke(del);
            }, TaskContinuationOptions.OnlyOnFaulted);

            processStocks.ContinueWith(t =>
            {
                GuiDelegate del = delegate
                {
                    btnException.Text = buttonCaption;
                };

                btnException.Invoke(del);
            });
        }

        CancellationTokenSource cancellationTokenSource = null;
        private void btnWithCancel_Click(object sender, EventArgs e)
        {
            btnWithCancel.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            var loadedLines = SearchForStocks(cancellationTokenSource.Token);

            var processStocks = loadedLines.ContinueWith(continuationAction,
                cancellationTokenSource.Token,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.Current);

            processStocks.ContinueWith(t =>
            {
                GuiDelegate del = delegate
                {
                    btnWithCancel.Text = "6 With Cancel";
                };

                btnWithCancel.Invoke(del);
            });
        }

        private Task<string[]> SearchForStocks(CancellationToken cancellationToken)
        {
            var loadedLinesTask = Task.Run(async () =>
            {
                using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                {
                    var lines = new List<string>();
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return lines.ToArray();
                        }
                        lines.Add(line);
                    }
                    return lines.ToArray();
                }
            }, cancellationToken);

            return loadedLinesTask;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private Task<List<StockPrice>> SearchForStocks(string ticker, CancellationToken cancellationToken)
        {
            var loadedLinesTask = Task.Run(async () =>
            {
                var data = new List<StockPrice>();

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
                            data.Add(createStock(line));
                    }
                    return data;
                }
            }, cancellationToken);

            return loadedLinesTask;
        }
        private async void btnManyTasks_Click(object sender, EventArgs e)
        {
            btnManyTasks.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<List<StockPrice>>>();

                foreach (var item in tickers)
                {
                    var loadedLines = SearchForStocks(item, cancellationTokenSource.Token);

                    tickerLoadingTasks.Add(loadedLines);
                }

                var timeoutTask = Task.Delay(2000);

                var allLoadingTasks = Task.WhenAll(tickerLoadingTasks);

                var completedTask = await Task.WhenAny(timeoutTask, allLoadingTasks);// return first completed task

                if (completedTask == timeoutTask)
                {
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource = null;
                    throw new Exception("Timeout");
                }

                var data = allLoadingTasks.Result.SelectMany(ls => ls);

                dataGridView1.DataSource = data.Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnManyTasks.Text = "7 Many Tasks";
        }

        private void btnMock_Click(object sender, EventArgs e)
        {
            btnMock.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();
                var service = new MockStockService();

                foreach (var item in tickers)
                {
                    var loadedLines = service.SearchForStocks(item, cancellationTokenSource.Token);

                    tickerLoadingTasks.Add(loadedLines);
                }

                var allLoadingTasks = Task.WhenAll(tickerLoadingTasks);

                var data = allLoadingTasks.Result.SelectMany(ls => ls);

                dataGridView1.DataSource = data.Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnMock.Text = "8 Use Mock";
        }

        private async void btnOneByOne_Click(object sender, EventArgs e)
        {
            btnOneByOne.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();
                var service = new StockService();
                var stocks = new ConcurrentBag<StockPrice>();//thread safe collection

                foreach (var item in tickers)
                {
                    var loadedLines = service.SearchForStocks(item, cancellationTokenSource.Token)
                        .ContinueWith(t =>
                        {
                            foreach (var stock in t.Result.Take(5))
                                stocks.Add(stock);

                            GuiDelegate del = delegate
                            {
                                dataGridView1.DataSource = stocks.Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                                dataGridView1.Columns[0].Width = dataGridView1.Width;
                            };

                            dataGridView1.Invoke(del);

                            return t.Result;
                        });

                    tickerLoadingTasks.Add(loadedLines);
                }

                var allLoadingTasks = Task.WhenAll(tickerLoadingTasks);

                await allLoadingTasks;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnOneByOne.Text = "9 One By One";
        }


        private async void btnStayOut_Click(object sender, EventArgs e)
        {
            var result = await GetStockFor(tbTicker.Text);
            textBox1.Text = "Stocks loaded";// back into inner thread
        }

        private async Task<IEnumerable<StockPrice>> GetStockFor(string text)
        {
            var stocks = await SearchForStocks(text, CancellationToken.None)
                .ConfigureAwait(false);// stay in outer thread, do not switch back 

            //textBox1.Text = "Stocks loaded"; //exception: control not in outer thread

            return stocks.Take(5);
        }

        private async void btnParallel_Click(object sender, EventArgs e)
        {
            btnParallel.Text = "Cancel";
            #region Cancel
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });
            #endregion
            try
            {
                #region Create Stock Tasks
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<List<StockPrice>>>();

                foreach (var item in tickers)
                {
                    var loadedLines = SearchForStocks(item, cancellationTokenSource.Token);

                    tickerLoadingTasks.Add(loadedLines);
                }
                #endregion

                var data = (await Task.WhenAll(tickerLoadingTasks)).SelectMany(ls => ls);

                Parallel.Invoke(// locks current thread - GUI
                    new ParallelOptions { MaxDegreeOfParallelism = 2 }, // optional, how many tasks can run at once
                    () =>
                    {
                        Debug.WriteLine("Starting Operation 1");

                        CalculateExpensiveComputation(data);

                        //GuiObj.Invoke(()=>{}); // will try to call UI thread and as it is locked - deadlock appear 

                        Debug.WriteLine("Completed Operation 1");
                    },
                    () =>
                    {
                        Debug.WriteLine("Starting Operation 2");

                        CalculateExpensiveComputation(data);

                        Debug.WriteLine("Completed Operation 2");
                    },
                    () =>
                    {
                        Debug.WriteLine("Starting Operation 3");

                        CalculateExpensiveComputation(data);

                        Debug.WriteLine("Completed Operation 3");
                    },
                    () =>
                    {
                        Debug.WriteLine("Starting Operation 4");

                        CalculateExpensiveComputation(data);

                        Debug.WriteLine("Completed Operation 4");
                    }
                    );

                dataGridView1.DataSource = data.Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnParallel.Text = "9 One By One";
        }

        private decimal CalculateExpensiveComputation(IEnumerable<StockPrice> stocks)
        {
            Thread.Yield();

            var computedValue = 0m;

            foreach (var stock in stocks)
            {
                for (int i = 0; i < stocks.Count() - 2; i++)
                {
                    for (int a = 0; a < 5; a++)
                    {
                        computedValue += stocks.ElementAt(i).Change + stocks.ElementAt(i + 1).Change;
                    }
                }
            }

            return computedValue;
        }

        private async void btnParallelForEach_Click(object sender, EventArgs e)
        {
            btnParallelForEach.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<List<StockPrice>>>();

                foreach (var item in tickers)
                {
                    var loadedLines = SearchForStocks(item, cancellationTokenSource.Token);

                    tickerLoadingTasks.Add(loadedLines);
                }

                var loadedStocks = await Task.WhenAll(tickerLoadingTasks);

                var values = new ConcurrentBag<StockCalculation>();

                var executionResult = Parallel.ForEach(loadedStocks,
                    new ParallelOptions { MaxDegreeOfParallelism = 2 }, // optional
                    (stocks,
                    state// optional
                    ) =>
                    //foreach (var stocks in loadedStocks)
                    {
                        var ticker = stocks.First().Ticker;

                        Debug.WriteLine($"Start processing {ticker}");

                        if (ticker == "MSFT")
                        {
                            Debug.WriteLine($"Found {ticker}, breaking");

                            //state.Break();// not terminating current tasks, but preventing to start new
                            state.Stop();// not terminating current tasks, but preventing to start new

                            return;
                        }

                        if (state.IsStopped) return;// <= state.Stop();

                        var result = CalculateExpensiveComputation(stocks);

                        var data = new StockCalculation
                        {
                            Ticker = stocks.First().Ticker,
                            Result = result
                        };

                        values.Add(data);
                    }
                );

                //executionResult.

                dataGridView1.DataSource = values.Select(p => new { value = $"{p.Ticker} {p.Result}" }).ToList();
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnParallelForEach.Text = "12 btnParallelForEach";

        }

        static object syncRoot = new object();
        private async void btnSharedVar_Click(object sender, EventArgs e)
        {
            btnSharedVar.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<List<StockPrice>>>();

                foreach (var item in tickers)
                {
                    var loadedLines = SearchForStocks(item, cancellationTokenSource.Token);

                    tickerLoadingTasks.Add(loadedLines);
                }

                var loadedStocks = await Task.WhenAll(tickerLoadingTasks);

                var loadedStocksFor = loadedStocks
                    .SelectMany(stock => stock)
                    .ToArray();

                decimal total = 0;
                int totalSafe = 0;
                decimal totalDecSafe = 0;

                var executionResult = Parallel.For(0, loadedStocksFor.Length, i =>
                    {
                        total += Compute(loadedStocksFor[i]);// not thread safe

                        Interlocked.Add(ref totalSafe, (int)Compute(loadedStocksFor[i]));// only for int

                        var value = Compute(loadedStocksFor[i]);
                        lock (syncRoot)// wait until code finished
                        {
                            totalDecSafe += value;
                        }
                    }
                );


                decimal totalDecSafeEach = 0;
                Parallel.ForEach(loadedStocks, stocks =>
                {
                    var value = 0m;
                    foreach (var stock in stocks)
                    {
                        value += Compute(stock);
                    }
                    lock (syncRoot)// wait until code finished
                    {
                        totalDecSafeEach += value;
                    }
                });

                textBox1.Text = $"{nameof(total)}: {total.ToString()}, {nameof(totalSafe)}:{totalSafe}, {nameof(totalDecSafe)}:{totalDecSafe}, {nameof(totalDecSafeEach)}:{totalDecSafeEach}";
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnSharedVar.Text = "13 Shared Var";
        }

        private decimal Compute(StockPrice stock)
        {
            Thread.Yield();

            decimal x = 0;
            for (var a = 0; a < 5; a++)
            {
                for (var b = 0; b < 10; b++)
                {
                    x += a + stock.Change;
                }
            }

            return x;
        }

        private async void btnProgress_Click(object sender, EventArgs e)
        {
            btnProgress.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var tickers = tbTickers.Text.Split(',', ' ');
                var tickerLoadingTasks = new List<Task<List<StockPrice>>>();

                progressBar1.Value = 0;
                progressBar1.Maximum = tickers.Count();

                IProgress<List<StockPrice>> progress = new Progress<List<StockPrice>>(stocks => {
                    progressBar1.Value += 1;
                    textBox1.Text += $"Loaded {stocks.Count()} for {stocks.First().Ticker} {Environment.NewLine}";
                });

                foreach (var item in tickers)
                {
                    var loadedLines = SearchForStocks(item, cancellationTokenSource.Token);

                    loadedLines= loadedLines.ContinueWith(st =>{
                        progress.Report(st.Result);
                        return st.Result;
                    });

                    tickerLoadingTasks.Add(loadedLines);
                }

                var allLoadingTasks = await Task.WhenAll(tickerLoadingTasks);

                var data = allLoadingTasks.SelectMany(ls => ls);

                dataGridView1.DataSource = data.Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnProgress.Text = "14 Progress";
        }

        private async void btnCompletion_Click(object sender, EventArgs e)
        {
            btnCompletion.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                var data = await GetStocksFor(tbTicker.Text);

                dataGridView1.DataSource = data.Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnCompletion.Text = "15 Completion";
        }

        private Task<List<StockPrice>> GetStocksFor(string ticker) {
            var source = new TaskCompletionSource<List<StockPrice>>();

            ThreadPool.QueueUserWorkItem(_ => {
                try
                {
                    var prices = new List<StockPrice>();

                    var lines = File.ReadAllLines("StockPrices_Small.csv");

                    foreach (var line in lines.Skip(1))
                    {
                        prices.Add(createStock(line));
                    }

                    source.SetResult(prices.Where(p => p.Ticker == ticker).ToList());
                }
                catch (Exception ex)
                {
                    source.SetException(ex);
                }
            });

            return source.Task;
        }

        private async void btnNotepad_Click(object sender, EventArgs e)
        {
            btnNotepad.Text = "Cancel";

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested"; });

            try
            {
                await WorkInNotepad();

            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            btnNotepad.Text = "16 Notepad";
        }

        private Task WorkInNotepad()
        {
            var source = new TaskCompletionSource<List<StockPrice>>();
            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo("Notepad.exe")
                {
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };

            process.Exited += (sender, e) =>
             {
                 source.SetResult(null);
             };

            process.Start();
            return source.Task;
        }
    }
}
