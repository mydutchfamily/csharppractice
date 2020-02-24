using MobilePhoneT1.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1
{
    class PhoneBuilder
    {
        public static IPhone BuildSimplePhone()
        {
            IPhone phone = new Phone("Bar");

            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70));
            components.Add(new Keyboard(new List<string> {"English", "Russian" }));

            phone.PhoneComponents.AddRange(components);

            return phone;

        }
    }
}
