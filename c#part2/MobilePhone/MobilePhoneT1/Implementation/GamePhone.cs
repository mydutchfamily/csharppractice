using MobilePhoneClT2.Enums;
using MobilePhoneT1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1.Implementation
{
    class GamePhone : GeneralPhone
    {
        public GamePhone(FormFactor formFactor, string serialNumber) : base(formFactor, serialNumber)
        {
            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200318"));
            components.Add(new KeyboardWithJoystick(new List<string> { "English", "Russian" }, "KP20200318"));

            this.PhoneComponents = components;
        }
    }
}
