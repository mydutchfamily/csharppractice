using System;
using System.Collections.Generic;
using System.Linq;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using static MobilePhoneClT2.PhoneCall;
using static MobilePhoneClT2.SmsMessage;

namespace MobilePhoneClT2.Implementation
{
    public class Communicator : IComponent
    {
        private Action<SmsMessage> smsRecipients;

        private readonly IPhone phone;

        private int unknown = 0;
        public ComponentTypes ComponentType { get; } = ComponentTypes.Communicator;

        public string SerialNumber { get; }

        public List<SmsMessage> smsLog { get; private set; } = new List<SmsMessage>();

        public List<PhoneCall> callsLog { get; private set; } = new List<PhoneCall>();

        public Communicator(string serialNumber, IPhone phone)
        {
            this.SerialNumber = serialNumber;
            this.phone = phone;
        }

        public SmsMessage SendSms(string smsText)
        {
            var msg = new SmsMessage() { Text = smsText, SentTime = DateTime.Now, Status = MsgStatus.Sent };

            phone.UseComponent<Memory>().Add<SmsMessage>(msg);

            smsRecipients(msg);

            return msg;
        }

        public void SendSms(Contact contact, string smsText, TextBoxOutput output, int simNum)
        {
            var msg = new SmsMessage() { SendTo = contact?.Name, Text = smsText, SentTime = DateTime.Now, Status = MsgStatus.Sent, Sender = phone?.ActiveSimCard.SmsReceiver };

            phone.UseComponent<Memory>().Add<SmsMessage>(msg);

            contact.SmsReceiver[simNum](msg);

            output?.WriteLine(msg.ToString());
        }

        public PhoneCall MakeCall(Contact contact, int duration, TextBoxOutput output, int simNum)
        {
            var call = new PhoneCall() { To = contact?.Name, StartTime = DateTime.Now, Direction = CallDirection.Outgoing, Duration = duration, Caller = phone?.ActiveSimCard.CallReceiver };

            SaveCallInMemory(call);

            contact.CallReceiver[simNum](call);

            output?.WriteLine(call.ToString());

            return call;
        }

        private void SaveCallInMemory(PhoneCall call)
        {
            var phoneCalls = phone.UseComponent<Memory>().Get<PhoneCall>();

            if (phoneCalls.Count > 0 && phoneCalls.Last().Equals(call))//from|to|direction
            {
                var lastCall = phoneCalls.Last();
                phoneCalls.Remove(lastCall);//IEquatable- from|to|time|direction
                foreach (var item in lastCall.LinkedCalls)
                {
                    call.LinkedCalls.Add(item);
                }
                phoneCalls.Add(call);
            }
            else
                phoneCalls.Add(call);
        }

        public Action<SmsMessage> SmsSubscribe(TextBoxOutput output = null)
        {          
            return (s) =>
            {
                var r = s.Clone();
                r.ReceivedTime = DateTime.Now;
                r.Status = SmsMessage.MsgStatus.Received;

                foreach (Contact contact in phone.UseComponent<Memory>().Get<Contact>())
                {
                    foreach (var item in contact.SmsReceiver)
                    {
                        if (item == r.Sender)
                        {
                            r.ReceivedFrom = contact.Name;
                            break;
                        }
                    }
                }

                if (r.ReceivedFrom == null)
                {
                    Contact contact = new Contact($"Unknown{unknown}", r.Sender, null);
                    r.ReceivedFrom = contact.Name;
                    phone.AddContact(contact);
                    unknown++;
                }

                phone.UseComponent<Memory>().Add<SmsMessage>(r);
                output?.WriteLine(r.ToString());
            };
        }

        public Action<PhoneCall> CallSubscribe(TextBoxOutput output = null)
        {
            return (s) =>
            {
                var r = s.Clone();
                r.StartTime = DateTime.Now;
                r.Direction = CallDirection.Incoming;

                foreach (Contact contact in phone.UseComponent<Memory>().Get<Contact>())
                {
                    foreach (var item in contact.CallReceiver)
                    {
                        if (item == r.Caller)
                        {
                            r.From = contact.Name;
                            break;
                        }
                    }
                }

                if (r.From == null) {
                    Contact contact = new Contact($"Unknown{unknown}", null, r.Caller);
                    r.From = contact.Name;
                    phone.AddContact(contact);
                    unknown++;
                }

                SaveCallInMemory(r);

                output?.WriteLine(r.ToString());
            };
        }

        public Communicator SetRecipient(Action<SmsMessage> smsRecipients)
        {
            this.smsRecipients = smsRecipients;
            return this;
        }

        public override string ToString()
        {
            return $"{nameof(Communicator)} with serial number {SerialNumber}";
        }
    }
}
