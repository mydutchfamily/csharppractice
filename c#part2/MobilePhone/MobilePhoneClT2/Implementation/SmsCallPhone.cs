using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using System.Collections.Generic;

namespace MobilePhoneClT2.Implementation
{
    public class SmsCallPhone : GeneralPhone
    {
        public override SimCard[] SimCards { get; } = new SimCard[2];
        public SmsCallPhone(FormFactor formFactor, string serialNumber) :base(formFactor, serialNumber)
        {
            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200225"));
            components.Add(new Keyboard(new List<string> { "English", "Russian" }, "KP20200225"));
            components.Add(new Communicator("SC20200406", this));
            Battery battery = new Battery("SC20200430", 60);
            components.Add(battery);

            var memory = new Memory("MC20200424");
            memory.Add<SmsMessage>(new List<SmsMessage>());
            memory.Add<Contact>(new List<Contact>());
            memory.Add<PhoneCall>(new List<PhoneCall>());
            
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

            this.deviceActions.Add(typeof(SmsCallPhone).Name, (powerDown) =>
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
