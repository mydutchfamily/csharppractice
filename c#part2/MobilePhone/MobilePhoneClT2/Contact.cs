using MobilePhoneClT2.Interfaces.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2
{
    public class Contact: IMemory
    {
        public string  Name { get;}
        public Action<SmsMessage> SmsReceiver { get;}
        public Contact(string name, Action<SmsMessage> receiver) {
            Name = name;
            SmsReceiver = receiver;
        }
    }
}
