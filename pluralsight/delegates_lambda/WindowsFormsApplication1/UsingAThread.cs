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

namespace WindowsFormsApplication1
{
    public partial class UsingAThread : Form
    {
        private int _Max;
        private delegate void StartProcessDelegate();
        public UsingAThread()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main()
        {
            Application.Run(new UsingAThread());
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _Max = 100;
            var t = new Thread(new ThreadStart(StartProcess));
            t.Start();
        }

        private void StartProcess() {
            if (progressBar1.InvokeRequired)// switch from one thread to another
            {
                var del = new StartProcessDelegate(StartProcess); // do call from gui thread to non gui
                this.Invoke(del);
            } else {
                // will fail if execute the code from GUI thread
                this.Refresh();
                this.progressBar1.Maximum = _Max;
                for (int i = 0; i <= _Max; i++)
                {
                    Thread.Sleep(10);
                    this.labelOutput.Text = i.ToString();
                    this.progressBar1.Value = i;
                }
            }

        }
    }
}
