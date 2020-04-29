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
        Func<string, StockPrice> createStock;
        private string buttonCaption;
        public Form1()
        {
            InitializeComponent();

             createStock = s => {
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

            cancellationTokenSource.Token.Register(() => { textBox1.Text = "Cancellation requested";});

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

                var timeoutTask = Task.Delay(1000);

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
            finally {
                cancellationTokenSource = null;
            }

            btnManyTasks.Text = "7 Many Tasks";
        }
    }
}
