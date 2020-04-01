﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadAndDelegates
{
    public partial class BackgroundWorkerDemo : Form
    {
        public BackgroundWorkerDemo()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new BackgroundWorkerDemo());
        }

        private void MyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Not on a UI thread
            e.Result = Calculate(sender as BackgroundWorker, e);
        }

        private void MyBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //GUI thread
            progressBar1.Value = e.ProgressPercentage;
        }

        private void MyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStart.Enabled = true;
            progressBar1.Value = 0;
            if (!e.Cancelled)
            {
                labelOutput.Text = "BackgroundWorker Completed!";
            }
            else {
                labelOutput.Text = "Cancelled!";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonCancel.Enabled = true;
            labelOutput.Text = "";
            MyBackgroundWorker.RunWorkerAsync();// execute DoWork method
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MyBackgroundWorker.CancelAsync();
            buttonCancel.Enabled = false;
        }

        private long Calculate(BackgroundWorker instance, DoWorkEventArgs e) {
            for(int i= 0; i < 100; i++)
            {
                if (instance.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }else
                {
                    System.Threading.Thread.Sleep(100);
                    instance.ReportProgress(i);
                }
            }
            return 0L;
        }
    }
}
