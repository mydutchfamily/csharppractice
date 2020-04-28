using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var allFiles = await ProcessDirectory("C:\\");

            richTextBox1.Lines = allFiles.ToArray();
            richTextBox1.ScrollToCaret();
        }

        private Task<List<string>> ProcessDirectory(string path)
        {
            var allfiles = Task.Run(() =>
            {
                List<string> files = new List<string>();
                List<string> folders = new List<string>();
                folders.Add(path);

                while (folders.Count > 0)
                {
                    string currentFolder = folders[folders.Count - 1];
                    folders.RemoveAt(folders.Count - 1);

                    string[] filesInFolder = Directory.GetFiles(currentFolder);
                    foreach (var item in filesInFolder)
                    {
                        files.Add(item);
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
            return allfiles;
        }
    }
}
