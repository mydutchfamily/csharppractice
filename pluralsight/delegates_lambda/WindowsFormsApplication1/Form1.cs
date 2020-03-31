using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadAndDelegates
{
    public partial class Form1 : Form
    {
        delegate void StartProcessDelegate(int val);
        delegate void ShowProgressDelegate(int val);
        public Form1()
        {
            InitializeComponent();
        }

        //public static void Main() {
        //    Application.Run(new Form1());
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            StartProcessDelegate progDel = new StartProcessDelegate(StartProcess);
            progDel.BeginInvoke(100, null, null);
            MessageBox.Show("Done with operation!!");
        }

        private void StartProcess(int max) {
            ShowProgress(0);
            for (int i = 0; i <= max; i++) {
                Thread.Sleep(100);
                ShowProgress(i);
            }
        }

        private void ShowProgress(int i) {
            // This is hit if a background thread calls ShowProgress()
            if (label1.InvokeRequired == true)
            {
                var del = new ShowProgressDelegate(ShowProgress);
                this.BeginInvoke(del, new object[] { i });// call ShowProgress but for else case, for different thread
            }
            else {
                label1.Text = i.ToString();
                progressBar1.Value = i;
            }
        }
    }
}
