using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System.Windows.Forms;

namespace MobilePhoneClT2.Implementation
{
    public class SmsCommunicator : IComponent
    {
        private Action<string> smsRecipients;
        public ComponentTypes ComponentType { get; } = ComponentTypes.Communicator;

        public string SerialNumber { get; }

        public SmsCommunicator(string serialNumber)
        {
            this.SerialNumber = serialNumber;
        }

        public void SendSms(string smsText)
        {
            smsRecipients(smsText);

            foreach (Action<string> del in smsRecipients.GetInvocationList()) {
                smsRecipients -= del;
            }
        }

        public Action<string> Subscribe(TextBoxOutput output)
        {
            return (s) => output.WriteLine(s);
        }

        public SmsCommunicator AddRecipient(Action<string> action)
        {
            smsRecipients += action;
            return this;
        }
        public override string ToString()
        {
            return $"{nameof(SmsCommunicator)} with serial number {SerialNumber}";
        }
    }
}
