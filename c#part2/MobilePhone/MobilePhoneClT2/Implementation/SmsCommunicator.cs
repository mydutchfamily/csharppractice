using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System.Windows.Forms;
using MobilePhoneClT2.AbstractClass;

namespace MobilePhoneClT2.Implementation
{
    public class SmsCommunicator : IComponent
    {
        private Action<SmsMessage> smsRecipients;

        private readonly GeneralPhone phone;
        public ComponentTypes ComponentType { get; } = ComponentTypes.Communicator;

        public string SerialNumber { get; }

        public List<SmsMessage> ReceivedSms { get; private set; } = new List<SmsMessage>();

        public SmsCommunicator(string serialNumber, GeneralPhone phone)
        {
            this.SerialNumber = serialNumber;
            this.phone = phone;
        }

        public SmsMessage SendSms(Contact contact, string smsText)
        {
            var msg = new SmsMessage() { ReceivedFrom = phone?.SimCard, SendTo = contact?.Name, Text = smsText, SentTime = DateTime.Now, Status = SmsMessage.MsgStatus.Sent };

            phone.UseComponent<Memory>().Add<SmsMessage>(msg);

            contact.SmsReceiver(msg);

            return msg;
        }

        public SmsMessage SendSms(string smsText)
        {
            var msg = new SmsMessage() { ReceivedFrom = phone?.SimCard, Text = smsText, SentTime = DateTime.Now, Status = SmsMessage.MsgStatus.Sent };

            phone.UseComponent<Memory>().Add<SmsMessage>(msg);

            smsRecipients(msg);

            return msg;
        }

        public SmsMessage SendSms(Contact contact, string smsText, TextBoxOutput output = null)
        {
            var msg = SendSms(contact,smsText);
            output?.WriteLine(msg.ToString());
            return msg;
        }

        public Action<SmsMessage> Subscribe(TextBoxOutput output = null)
        {          
            return (s) =>
            {
                var r = s.Clone();
                r.ReceivedTime = DateTime.Now;
                r.Status = SmsMessage.MsgStatus.Received;
                phone.UseComponent<Memory>().Add<SmsMessage>(r);
                output?.WriteLine(r.ToString());
            };
        }

        public SmsCommunicator SetRecipient(Action<SmsMessage> smsRecipients)
        {
            this.smsRecipients = smsRecipients;
            return this;
        }

        public override string ToString()
        {
            return $"{nameof(SmsCommunicator)} with serial number {SerialNumber}";
        }
    }
}
