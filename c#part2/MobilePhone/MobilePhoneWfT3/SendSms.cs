using MobilePhoneClT2.Interfaces;
using System;
using System.Windows.Forms;
using MobilePhoneClT2;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Implementation;

namespace MobilePhoneWfT3
{
    public partial class SendSms : Form
    {
        
        private IPhone smsPhone1;
        private IPhone smsPhone2;
        private Action<SmsMessage> subscribe;
        private TextBoxOutput output;
        int smsCount = 0;
        public SendSms()
        {
            InitializeComponent();

            smsFormatting.DataSource = Enum.GetNames(typeof(TextBoxOutput.FormatingStyle));

            smsPhone1 = new SmsPhone(FormFactor.Bar, "BP20200406");
            smsPhone2 = new SmsPhone(FormFactor.Bar, "BP20200409");

            output = new TextBoxOutput(this.receivedSms);
            subscribe = smsPhone2.UseComponent<Communicator>().SmsSubscribe(output);           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = timerSms.Enabled ? "Start sending sms" : "Stop sending sms";
            timerSms.Enabled = !timerSms.Enabled;
        }

        private void timerSms_Tick(object sender, EventArgs e)
        {
            smsPhone1.UseComponent<Communicator>().SetRecipient(subscribe).SendSms($"sms{smsCount++}");
        }

        private void smsFormatting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (output != null)
            {
                output.Formating = (TextBoxOutput.FormatingStyle)smsFormatting.SelectedIndex;
            }
        }
    }
}
