using System;
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
    public partial class DirectorySearcherForm : Form
    {
        public DirectorySearcherForm()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new DirectorySearcherForm());
        }

        private void directorySearcher_SearchComplete(object sender, System.EventArgs e) {
            labelSearch.Text = string.Empty;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            directorySearcher.SearchCriteria = textBoxSearch.Text;
            labelSearch.Text = "Searching...";
            directorySearcher.BeginSearch();
        }


    }
}
