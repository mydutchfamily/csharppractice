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
using static MobilePhoneWfT4.InvokedClasses;

namespace MobilePhoneWfT4
{

    public partial class SendManySms : Form
    {
        private GeneralPhone smsPhone1, smsPhone2, smsPhone3, smsPhone4;
        private TextBoxOutput output;
        private Func<IEnumerable<GeneralPhone>, FilterParams, ListViewItem[]> filterChanged = UpdateFiltering;
        private Func<IEnumerable<GeneralPhone>, string[]> getAllSenders = FilteringSenders;
        private int smsCount = 0;
        private Random random = new Random();
        private GeneralPhone[] phones;
        public SendManySms()
        {
            InitializeComponent();

            smsPhone1 = new SmsPhone("Bar", "BP20200406");
            smsPhone1.SimCard = "Alex";
            smsPhone2 = new SmsPhone("Bar", "BP20200409");
            smsPhone2.SimCard = "Vova";
            smsPhone3 = new SmsPhone("Bar", "BP20200406");
            smsPhone3.SimCard = "Stas";
            smsPhone4 = new SmsPhone("Bar", "BP20200409");
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

            phones = new GeneralPhone[] { smsPhone1, smsPhone2, smsPhone3, smsPhone4 };

            smsFormatting.DataSource = Enum.GetNames(typeof(TextBoxOutput.FormatingStyle));
            cmbWords.DataSource = new List<string>() { FILTER_ALL_VALUES }.Concat(words).ToArray();
            cmbLogic.DataSource = Enum.GetNames(typeof(LogicOperand));
            dtpFrom.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dtpTo.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            resetFilters();
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
                Enum.TryParse(cmbLogic.Text,out logic);

                FilterParams filterParams = new FilterParams() {
                    SubString = cmbWords.Text,
                    ReceivedFrom = cbxSubscribers.Text,
                    Logic = logic,
                    From = dtpFrom.Value,
                    To = dtpTo.Value.AddMilliseconds(999) };
                lvFilteredSms.Items.AddRange(filterChanged(phones, filterParams));
            }
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            resetFilters();
        }

        private void receivedSms_DoubleClick(object sender, EventArgs e)
        {
            receivedSms.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = timerSms.Enabled ? "Start sending sms" : "Stop sending sms";
            timerSms.Enabled = !timerSms.Enabled;
        }

        private void timerSms_Tick(object sender, EventArgs e)
        {
            int arrLength = words.Length - 1;
            smsPhone1.SendSms($"smsVSO|{words[random.Next(arrLength)]}|{smsCount++}", output, "Vova", "Stas", "Oleg");
            smsPhone2.SendSms($"smsVA|{words[random.Next(arrLength)]}|{smsCount++}", output, "Alex");
            smsPhone3.SendSms($"smsSA|{words[random.Next(arrLength)]}|{smsCount++}", output, "Alex");
            smsPhone4.SendSms($"smsOA|{words[random.Next(arrLength)]}|{smsCount++}", output, "Alex");

            cbxSubscribers.DataSource = getAllSenders(phones);
        }

        private void smsFormatting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (output != null)
                output.Formating = (TextBoxOutput.FormatingStyle)smsFormatting.SelectedIndex;
        }
    }
}
