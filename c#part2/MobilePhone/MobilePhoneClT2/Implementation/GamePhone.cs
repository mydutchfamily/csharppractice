using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation
{
    public class GamePhone : GeneralPhone
    {
        public GamePhone(FormFactor formFactor, string serialNumber) : base(formFactor, serialNumber)
        {
            List<IComponent> components = new List<IComponent>();
            components.Add(new MonochromeScreen("Monochrome", 120, 70, "2LTMD20200318"));

            var joystickButtons = new List<JoystickButtons> { JoystickButtons.Up, JoystickButtons.Down, JoystickButtons.Left, JoystickButtons.Right };
            var languages = new List<string> { "English", "Russian" };
            components.Add(new KeyboardWithJoystick(languages, "KP20200318", joystickButtons));

            this.PhoneComponents = components;
        }
        public override List<Plugins> SupportedPlugins { get; } = new List<Plugins> { Plugins.Usb, Plugins.HeadSetJack35};

}
}
