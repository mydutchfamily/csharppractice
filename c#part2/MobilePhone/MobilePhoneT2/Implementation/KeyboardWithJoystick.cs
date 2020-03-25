using MobilePhoneT2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT2.Implementation
{
    class KeyboardWithJoystick : Keyboard
    {
        private Joystick joystick;
        private List<IComponent> vKeyboardComponents = new List<IComponent>();
        public KeyboardWithJoystick(List<string> languages, string serialNumber, List<JoystickButtons> joystickButtons) : base(languages, serialNumber)
        {
            joystick = new Joystick(serialNumber, joystickButtons);
            KeyboardComponents.Add(joystick);
        }

        public override List<IComponent> KeyboardComponents
        {
            get { return vKeyboardComponents?.GetRange(0, vKeyboardComponents.Count); }
            protected set { vKeyboardComponents = value; }
        }

        public override string ToString()
        {
            return $"keyboard with {joystick.JoystickButtons.Count} buttons joystick support {Languages.Count} languages: {string.Join(",", Languages)}";
        }
    }
}
