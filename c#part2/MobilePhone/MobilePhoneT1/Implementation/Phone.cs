using System.Collections.Generic;
using System.Text;
using MobilePhoneT1.Interfaces;

namespace MobilePhoneT1.Implementation
{
    class Phone : GeneralPhone
    {
        public Phone(string formFactor, string serialNumber) :base(formFactor, serialNumber)
        {
            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200225"));
            components.Add(new Keyboard(new List<string> { "English", "Russian" }, "KP20200225"));

            this.PhoneComponents = components;
        }
    }
}
