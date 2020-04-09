using MobilePhoneClT2;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Implementation;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilePhoneWfT2
{
    public partial class Form1 : Form
    {
        private int choice;
        private IInterconnection headsetSony;
        private IInterconnection powerBank;
        private IPhone gamePhone;
        IOutput output;
        public Form1()
        {
            InitializeComponent();

            gamePhone = new GamePhone("Bar", "BP20200321");
            output = new TextBoxOutput(this.outputTextBox);
            headsetSony = new HeadsetSony("BP20200321", output);

            powerBank = new PowerBank("BP20200325", output);
            powerBank.PluginToUse = Plugins.Usb;
        }

        private void sonyBTH_CheckedChanged(object sender, EventArgs e)
        {
            choice = 1;
        }

        private void sony35_CheckedChanged(object sender, EventArgs e)
        {
            choice = 2;
        }

        private void powerbank_CheckedChanged(object sender, EventArgs e)
        {
            choice = 3;
        }

        private void Apply_Click(object sender, EventArgs a)
        {
            try {
                ApplyChoice();
            }
            catch (NotImplementedException e) {
                MessageBox.Show(e.Message);
            }
        }

        private void ApplyChoice()
        {
            switch (choice)
            {
                case 1:
                    headsetSony.PluginToUse = Plugins.Bluetooth;
                    gamePhone.PluginDevice(headsetSony).ExecuteDevice(typeof(HeadsetSony).Name);
                    break;
                case 2:
                    headsetSony.PluginToUse = Plugins.HeadSetJack35;
                    gamePhone.PluginDevice(headsetSony).ExecuteDevice(typeof(HeadsetSony).Name);
                    break;
                case 3:
                    gamePhone.PluginDevice(powerBank).ExecuteDevice(typeof(PowerBank).Name);
                    break;
                default:
                    output.WriteLine("Unknown device selected");
                    break;
            }
        }
    }
}
