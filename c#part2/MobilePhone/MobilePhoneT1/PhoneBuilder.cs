using MobilePhoneT1.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneT1.Interfaces;

namespace MobilePhoneT1
{
    class PhoneBuilder
    {
        public static IPhone BuildSimplePhone(string phoneSerialNumber)
        {
            IPhone phone = new Phone("Bar", phoneSerialNumber);

            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200225"));
            components.Add(new Keyboard(new List<string> {"English", "Russian"}, "KP20200225"));

            phone.PhoneComponents.AddRange(components);

            return phone;

        }
    }
}
