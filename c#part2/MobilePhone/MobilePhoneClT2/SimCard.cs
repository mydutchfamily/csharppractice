using System;

namespace MobilePhoneClT2
{
    public class SimCard
    {
        public Action<SmsMessage> SmsReceiver { get; set; }
        public Action<PhoneCall> CallReceiver { get; set; }
    }
}
