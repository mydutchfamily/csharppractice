using MobilePhoneClT2.Interfaces.Markers;
using System;
using System.Collections.Generic;

namespace MobilePhoneClT2
{
    public class Contact: IMemory, IEquatable<Contact>
    {
        public string  Name { get; private set; }
        public List<Action<SmsMessage>> SmsReceiver { get; private set; }
        public List<Action<PhoneCall>> CallReceiver { get; private set; }
        public Contact(string name, Action<SmsMessage> smsReceiver, Action<PhoneCall> callReceiver) {
            Name = name;

            var smsRs = new List<Action<SmsMessage>>();
            smsRs.Add(smsReceiver);
            SmsReceiver = smsRs;

            var callRs = new List<Action<PhoneCall>>();
            callRs.Add(callReceiver);
            CallReceiver = callRs;
        }
        private Contact() {}
        public Contact Clone() {
            Contact contact = new Contact();

            contact.SmsReceiver = new List<Action<SmsMessage>>();
            contact.SmsReceiver.AddRange(SmsReceiver);
            contact.CallReceiver = new List<Action<PhoneCall>>();
            contact.CallReceiver.AddRange(CallReceiver);
            contact.Name = String.Copy(Name);

            return contact;
        }

        public bool Equals(Contact other) // List.Contains(item)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(other, this))
                return true;

            bool equal = false;
            if (Name == other.Name) {

                foreach (var item1 in SmsReceiver)
                {
                    foreach (var item2 in other.SmsReceiver)
                    {
                        equal = equal || object.ReferenceEquals(item1, item2);
                    }
                }

                foreach (var item1 in CallReceiver)
                {
                    foreach (var item2 in other.CallReceiver)
                    {
                        equal = equal || object.ReferenceEquals(item1, item2);
                    }
                }

            }
            return equal;
        }
    }
}
