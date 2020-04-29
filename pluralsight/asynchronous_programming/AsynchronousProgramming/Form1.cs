using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousProgramming
{
    public partial class Form1 : Form
    {
        delegate void GuiDelegate();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)// "async void" - allowed only for event handler or delegate
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

        private async void btnLoadFile_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>// without async/await code will be executed immediately, in another thread
            {
                var lines = File.ReadAllLines("StockPrices_Small.csv");

                var data = new List<StockPrice>();

                foreach (var line in lines.Skip(1))
                {
                    var segments = line.Split(',');

                    for (var i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
                    var price = new StockPrice
                    {
                        Ticker = segments[0],
                        TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        Volume = Convert.ToInt32(segments[6], CultureInfo.InvariantCulture),
                        Change = Convert.ToDecimal(segments[7], CultureInfo.InvariantCulture),
                        ChangePercent = Convert.ToDecimal(segments[8], CultureInfo.InvariantCulture),
                    };
                    data.Add(price);
                }

                GuiDelegate del = delegate {
                    dataGridView1.DataSource = data.Where(price => price.Ticker == tbTicker.Text).Select(p => new { value = $"{p.Ticker} {p.Volume}" }).ToList();
                    dataGridView1.Columns[0].Width = dataGridView1.Width;
                };

                dataGridView1.Invoke(del);// use invoke to execute delegate in original thread;
            });
        }
    }
}
