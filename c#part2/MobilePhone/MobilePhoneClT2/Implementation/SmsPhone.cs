using MobilePhoneClT2;
using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation
{
    public class SmsPhone : GeneralPhone
    {
        public SmsPhone(FormFactor formFactor, string serialNumber) :base(formFactor, serialNumber)
        {
            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200225"));
            components.Add(new Keyboard(new List<string> { "English", "Russian" }, "KP20200225"));
            components.Add(new SmsCommunicator("SC20200406", this));
            Battery battery = new Battery("SC20200430", 60);
            components.Add(battery);

            var memory = new Memory("MC20200424");
            memory.Add<SmsMessage>(new List<SmsMessage>());
            memory.Add<Contact>(new List<Contact>());

            components.Add(memory);

            this.PhoneComponents = components;

            this.deviceActions.Add(typeof(PowerBank).Name, (powerUp) =>
            {
                lock (syncRoot)
                {
                    battery.Capacity = (battery.Capacity + powerUp) > 100 ? 100 : battery.Capacity + powerUp;
                }

                progress?.Report(battery.Capacity);
            });

            this.deviceActions.Add(typeof(SmsPhone).Name, (powerDown) =>
            {
                lock (syncRoot)
                {
                    battery.Capacity = (battery.Capacity - powerDown) < 0 ? 0 : battery.Capacity - powerDown;
                }

                progress?.Report(battery.Capacity);
            });

            base.SupportedPlugins.Add(Plugins.Usb);
        }
    }
}
