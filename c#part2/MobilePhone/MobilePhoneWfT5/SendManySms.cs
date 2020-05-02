using MobilePhoneClT2.Interfaces;
using MobilePhoneClT2.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobilePhoneClT2;
using MobilePhoneClT2.Enums;
using static MobilePhoneClT2.TextBoxOutput;
using MobilePhoneClT2.AbstractClass;
using static MobilePhoneWfT5.InvokedClasses;
using System.Threading;
using System.Diagnostics;

namespace MobilePhoneWfT5
{

    public partial class SendManySms : Form
    {
        private IPhone smsPhone1, smsPhone2, smsPhone3, smsPhone4;
        private TextBoxOutput output;
        private Func<IEnumerable<IPhone>, FilterParams, ListViewItem[]> filterChanged = UpdateFiltering;
        private Func<IEnumerable<IPhone>, string[]> getAllSenders = FilteringSenders;
        private int smsCount = 0;
        private Random random = new Random();
        private IPhone[] phones;
        private CancellationTokenSource cancelSms = null;
        private PowerBank powerbank;

        public delegate void MainThread();
        public MainThread sendSms;

        public SendManySms()
        {
            InitializeComponent();

            smsPhone1 = new SmsPhone(FormFactor.Bar, "BP20200406");
            smsPhone1.SimCard = "Alex";
            smsPhone2 = new SmsPhone(FormFactor.Bar, "BP20200409");
            smsPhone2.SimCard = "Vova";
            smsPhone3 = new SmsPhone(FormFactor.Bar, "BP20200406");
            smsPhone3.SimCard = "Stas";
            smsPhone4 = new SmsPhone(FormFactor.Bar, "BP20200409");
            smsPhone4.SimCard = "Oleg";

            output = new TextBoxOutput(this.receivedSms);

            var contact1 = smsPhone1.GetMyContact(output);
            var contact2 = smsPhone2.GetMyContact(output);
            var contact3 = smsPhone3.GetMyContact(output);
            var contact4 = smsPhone4.GetMyContact(output);

            smsPhone1.AddContact(contact2, contact3, contact4);
            smsPhone2.AddContact(contact1);
            smsPhone3.AddContact(contact1);
            smsPhone4.AddContact(contact1);

            phones = new IPhone[] { smsPhone1, smsPhone2, smsPhone3, smsPhone4 };

            smsFormatting.DataSource = Enum.GetNames(typeof(TextBoxOutput.FormatingStyle));
            cmbWords.DataSource = new List<string>() { FILTER_ALL_VALUES }.Concat(words).ToArray();
            cmbLogic.DataSource = Enum.GetNames(typeof(LogicOperand));
            dtpFrom.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dtpTo.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            resetFilters();

            sendSms = delegate
            {
                int arrLength = words.Length - 1;
                smsPhone1.SendSms($"smsVSO|{words[random.Next(arrLength)]}|{smsCount++}", output, "Vova", "Stas", "Oleg");
                smsPhone2.SendSms($"smsVA|{words[random.Next(arrLength)]}|{smsCount++}", output, "Alex");
                smsPhone3.SendSms($"smsSA|{words[random.Next(arrLength)]}|{smsCount++}", output, "Alex");
                smsPhone4.SendSms($"smsOA|{words[random.Next(arrLength)]}|{smsCount++}", output, "Alex");

                cbxSubscribers.DataSource = getAllSenders(phones);
            };

            powerbank = new PowerBank("PB20200430");
            powerbank.PluginToUse = Plugins.Usb;
        }

        private void resetFilters()
        {
            dtpFrom.Value = DateTimePicker.MinimumDateTime;
            dtpTo.Value = DateTime.Now;
            cbxSubscribers.Text = FILTER_ALL_VALUES;
            cmbWords.Text = FILTER_ALL_VALUES;
            cmbLogic.Text = LogicOperand.OR.ToString();
        }

        private void cbx_SelectedValueChanged(object sender, EventArgs e)
        {
            lvFilteredSms.Items.Clear();

            if (filterChanged != null)
            {
                LogicOperand logic;
                Enum.TryParse(cmbLogic.Text, out logic);

                FilterParams filterParams = new FilterParams()
                {
                    SubString = cmbWords.Text,
                    ReceivedFrom = cbxSubscribers.Text,
                    Logic = logic,
                    From = dtpFrom.Value,
                    To = dtpTo.Value.AddMilliseconds(999)
                };
                lvFilteredSms.Items.AddRange(filterChanged(phones, filterParams));
            }
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            resetFilters();
        }

        private void chbxCharger_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxCharger.Checked)
            {
                smsPhone1.PluginDevice(powerbank)
                .ExecuteDevice<PowerBank>((i)=>{ progressBar1.Value = i;});
            }
            else {
                smsPhone1.DisconnectDevice(powerbank);
            }
        }

        private void chbxSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxSwitch.Checked)
            {
                smsPhone1.PluginDevice(smsPhone1).ExecuteDevice<SmsPhone>((i) => { progressBar1.Value = i; });
            }
            else
            {
                smsPhone1.DisconnectDevice(smsPhone1);
            }
        }

        private void receivedSms_DoubleClick(object sender, EventArgs e)
        {
            receivedSms.Clear();
        }

        private async void btnGenerateSms_Click(object sender, EventArgs e)
        {
            btnGenerateSms.Text = "Stop sending sms";

            if (cancelSms != null)
            {
                cancelSms.Cancel();
                cancelSms = null;
                return;
            }

            cancelSms = new CancellationTokenSource();
            cancelSms.Token.Register(() => { receivedSms.AppendText(Environment.NewLine + "Stop sending sms"); });
            CancellationToken cancelSmsToken = cancelSms.Token;

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    while (!cancelSmsToken.IsCancellationRequested)
                    {
                        cbxSubscribers.Invoke(sendSms);

                        Thread.Sleep(2000);
                        Debug.WriteLine("**** Sms sent *****");
                    }
                    if (cancelSmsToken.IsCancellationRequested)
                       return;
                }
                );
            }
            catch (Exception ex)
            {
                receivedSms.AppendText(Environment.NewLine + ex.Message);
            }
            finally
            {
                cancelSms = null;
            }

            btnGenerateSms.Text = "Start sending sms";
        }

        private void smsFormatting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (output != null)
                output.Formating = (TextBoxOutput.FormatingStyle)smsFormatting.SelectedIndex;
        }
    }
}
