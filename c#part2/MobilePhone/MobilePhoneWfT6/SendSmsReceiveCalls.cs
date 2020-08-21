using MobilePhoneClT2.Interfaces;
using MobilePhoneClT2.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobilePhoneClT2;
using MobilePhoneClT2.Enums;
using static MobilePhoneWfT6.InvokedClasses;
using System.Threading;
using System.Diagnostics;
using static MobilePhoneClT2.PhoneCall;

namespace MobilePhoneWfT6
{

    public partial class SendSmsReceiveCalls : Form
    {
        private IPhone phone1, phone2, phone3, phone41, phone42, phone5;
        private TextBoxOutput outputEvents;
        private Func<IEnumerable<IPhone>, FilterParams, ListViewItem[]> filterChanged = UpdateFiltering;
        private Func<IEnumerable<IPhone>, string[]> getAllSenders = FilteringSenders;
        private Func<IEnumerable<IPhone>, string[]> getAllCallers = FilteringCallers;
        private int smsCount = 0;
        private Random random = new Random();
        private IPhone[] phones;
        private CancellationTokenSource cancelSms = null;
        private CancellationTokenSource cancelCalls = null;
        private PowerBank powerbank;
        private bool showByGroup = false;

        public delegate void MainThread();
        public MainThread sendSms;
        public MainThread receiveCalls;

        public SendSmsReceiveCalls()
        {
            InitializeComponent();

            outputEvents = new TextBoxOutput(this.receivedEvents);

            phone1 = new SmsCallPhone(FormFactor.Bar, "BP20200406");
            phone1.AddSimCard(new SimCard(), outputEvents);

            phone2 = new SmsCallPhone(FormFactor.Bar, "BP20200409");
            phone2.AddSimCard(new SimCard(), outputEvents);

            phone3 = new SmsCallPhone(FormFactor.Bar, "BP20200406");
            phone3.AddSimCard(new SimCard(), outputEvents);

            phone41 = new SmsCallPhone(FormFactor.Bar, "BP20200409");
            phone41.AddSimCard(new SimCard(), outputEvents);

            phone42 = new SmsCallPhone(FormFactor.Bar, "BP20200507");
            phone42.AddSimCard(new SimCard(), outputEvents);

            phone5 = new SmsCallPhone(FormFactor.Bar, "BP20200511");
            phone5.AddSimCard(new SimCard(), outputEvents);
            phone5.AddSimCard(new SimCard(), outputEvents);

            var contact1 = phone1.GetMyContact("Alex");
            var contact2 = phone2.GetMyContact("Vova");
            var contact3 = phone3.GetMyContact("Stas");
            var contact41 = phone41.GetMyContact("Oleg");
            var contact42 = phone42.GetMyContact("Oleg");
            var contact51 = phone5.GetMyContact("Roma");
            var contact52 = phone5.GetMyContact("Roma", 1);

            phone1.AddContact(contact2, contact42, contact51, contact52);
            phone2.AddContact(contact1);
            phone3.AddContact(contact1);
            phone41.AddContact(contact1);
            phone42.AddContact(contact1);
            phone5.AddContact(contact1);

            phones = new IPhone[] { phone1, phone2, phone3, phone41, phone42, phone5 };

            smsFormatting.DataSource = Enum.GetNames(typeof(TextBoxOutput.FormatingStyle));
            cmbWords.DataSource = new List<string>() { FILTER_ALL_VALUES }.Concat(words).ToArray();
            cmbLogic.DataSource = Enum.GetNames(typeof(LogicOperand));
            dtpFrom.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dtpTo.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            resetFilters();

            sendSms = delegate
            {
                int arrLength = words.Length - 1;
                phone1.SendSms($"smsVSOR|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Vova", "Oleg", "Roma");
                phone2.SendSms($"smsVA|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Alex");
                phone3.SendSms($"smsSA|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Alex");
                phone41.SendSms($"smsOA|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Alex");
                phone42.SendSms($"smsOA|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Alex");
                phone5.SetActiveSimCard(0).SendSms($"smsR1A|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Alex");
                phone5.SetActiveSimCard(1).SendSms($"smsR2A|{words[random.Next(arrLength)]}|{smsCount++}", outputEvents, 0, "Alex");

                cbxSubscribers.DataSource = getAllSenders(phones);
            };

            var callers = new IPhone[] { phone2, phone41, phone42, phone5 };
            var callTo = new string[] { "Vova", "Oleg", "Roma" };

            receiveCalls = delegate
            {
                callers[random.Next(3)].SetActiveSimCard(0).MakeCall(random.Next(300, 3000), "Alex", outputEvents);
                phone1.MakeCall(random.Next(300, 3000), callTo[random.Next(2)], outputEvents);

                phone5.SetActiveSimCard(0).MakeCall(random.Next(300, 3000), "Alex", outputEvents);
                phone5.SetActiveSimCard(1).MakeCall(random.Next(300, 3000), "Alex", outputEvents);

                phone1.MakeCall(random.Next(300, 3000), "Oleg", outputEvents);
                phone1.MakeCall(random.Next(300, 3000), "Roma", outputEvents, 1);
                phone1.MakeCall(random.Next(300, 3000), "Roma", outputEvents);


                phone3.MakeCall(111, "Alex", outputEvents);
                phone3.MakeCall(222, "Alex", outputEvents);

                phone41.MakeCall(333, "Alex", outputEvents);
                phone41.MakeCall(444, "Alex", outputEvents);

                cbxSubscribers.DataSource = getAllCallers(phones);
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
            cbxSubscribers.Enabled = false;
            cmbLogic.Enabled = false;
            cmbWords.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;

            if (tabControl1.SelectedTab == tbpgFilteredSms)
            {

                cbxSubscribers.Enabled = true;
                cmbLogic.Enabled = true;
                cmbWords.Enabled = true;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;

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
            else if (tabControl1.SelectedTab == tbpgCollsLog)
            {
                showCallList();
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
                phone1.PluginDevice(powerbank)
                .ExecuteDevice<PowerBank>((i) => { progressBar1.Value = i; });
            }
            else
            {
                phone1.DisconnectDevice(powerbank);
            }
        }

        private void chbxSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxSwitch.Checked)
            {
                phone1.PluginDevice(phone1).ExecuteDevice<SmsCallPhone>((i) => { progressBar1.Value = i; });
            }
            else
            {
                phone1.DisconnectDevice(phone1);
            }
        }

        private void lvCalls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                showByGroup = !showByGroup;
                showCallList();
            }
        }

        public void showCallList()
        {
            if (showByGroup)
            {
                lvCalls.Items.Clear();

                var calls = phone1.UseComponent<Memory>().Get<PhoneCall>().ToList();
                calls.Sort();//IComparable<PhoneCall>.CompareTo(PhoneCall other)

                while (0 < calls.Count)
                {
                    var call = calls[0];
                    ListViewGroup lvGroup = new ListViewGroup($"{call.From}/{call.Direction}", HorizontalAlignment.Left);
                    lvCalls.Groups.Add(lvGroup);

                    for (int ii = 0; ii < calls.Count; ii++)
                    {
                        var item = calls[ii];
                        if (call.Equals(item))
                        {
                            lvCalls.Items.Add(new ListViewItem(new string[] { item.From, item.To, item.StartTime.ToString(), item.Duration.ToString(), item.Direction.ToString(), item.LinkedCalls.Count.ToString() }, lvGroup));
                            calls.Remove(item);
                            ii--;
                        }
                    }
                }
            }
            else
            {
                lvCalls.Groups.Clear();

                lvCalls.Items.Clear();

                phone1.UseComponent<Memory>().Get<PhoneCall>();
                var sortedCalls = new List<PhoneCall>(phone1.UseComponent<Memory>().Get<PhoneCall>());
                sortedCalls.Sort(PhoneCallsByTime.Instance);

                var listViewItem = sortedCalls.Select(c => new ListViewItem(new[] { c.From, c.To, c.StartTime.ToString(), c.Duration.ToString(), c.Direction.ToString(), c.LinkedCalls.Count.ToString() })).ToArray();
                lvCalls.Items.AddRange(listViewItem);
            }
        }

        private void delCurCall_Click(object sender, EventArgs e)
        {
            if (lvCalls.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lvCalls.CheckedItems)
                {
                    lvCalls.Items.Remove(item);

                    var selectedCall = new PhoneCall()
                    {
                        From = (item.SubItems[0].Text == "" ? null: item.SubItems[0].Text),
                        To = item.SubItems[1].Text,
                        StartTime = DateTime.Parse(item.SubItems[2].Text),
                        Direction = (CallDirection)Enum.Parse(typeof(CallDirection), item.SubItems[4].Text)
                    };

                    var calls = phone1.UseComponent<Memory>().Get<PhoneCall>().ToList();

                    foreach (var call in calls)
                        if ((call as IEquatable<PhoneCall>).Equals(selectedCall))
                        {
                            phone1.UseComponent<Memory>().Get<PhoneCall>().Remove(call);
                        }
                }

            }
        }

        private void cleanCallHist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete ALL calls?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lvCalls.Items.Clear();
                phone1.UseComponent<Memory>().Get<PhoneCall>().Clear();
            }
        }

        private async void btnGenerateCalls_Click(object sender, EventArgs e)
        {
            btnGenerateCalls.Text = "Stop calling";

            if (cancelCalls != null)
            {
                cancelCalls.Cancel();
                cancelCalls = null;
                return;
            }

            cancelCalls = new CancellationTokenSource();
            cancelCalls.Token.Register(() => { receivedEvents.AppendText(Environment.NewLine + "Stop calling"); });
            CancellationToken cancelCallsToken = cancelCalls.Token;

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    while (!cancelCallsToken.IsCancellationRequested)
                    {
                        receivedEvents.Invoke(receiveCalls);

                        Thread.Sleep(2000);
                        Debug.WriteLine("**** Calls finished *****");
                    }
                    if (cancelCallsToken.IsCancellationRequested)
                        return;
                }
                );
            }
            catch (Exception ex)
            {
                receivedEvents.AppendText(Environment.NewLine + ex.Message);
            }
            finally
            {
                cancelCalls = null;
            }

            btnGenerateCalls.Text = "Start calling";
        }

        private void receivedSms_DoubleClick(object sender, EventArgs e)
        {
            receivedEvents.Clear();
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
            cancelSms.Token.Register(() => { receivedEvents.AppendText(Environment.NewLine + "Stop sending sms"); });
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
                receivedEvents.AppendText(Environment.NewLine + ex.Message);
            }
            finally
            {
                cancelSms = null;
            }

            btnGenerateSms.Text = "Start sending sms";
        }

        private void smsFormatting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputEvents != null)
                outputEvents.Formating = (TextBoxOutput.FormatingStyle)smsFormatting.SelectedIndex;
        }
    }
}
