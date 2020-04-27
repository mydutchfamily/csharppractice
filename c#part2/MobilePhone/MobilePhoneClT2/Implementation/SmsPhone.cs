using MobilePhoneClT2;
using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation
{
    public class SmsPhone : GeneralPhone
    {
        public SmsPhone(string formFactor, string serialNumber) :base(formFactor, serialNumber)
        {
            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200225"));
            components.Add(new Keyboard(new List<string> { "English", "Russian" }, "KP20200225"));
            components.Add(new SmsCommunicator("SC20200406", this));

            var memory = new Memory("MC20200424");
            memory.Add<SmsMessage>(new List<SmsMessage>());
            memory.Add<Contact>(new List<Contact>());

            components.Add(memory);

            this.PhoneComponents = components;
        }
    }
}
