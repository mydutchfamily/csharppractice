using MobilePhoneT2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT2.Implementation
{
    class Joystick : IComponent
    {
        private List<JoystickButtons> vJoystickButtons;
        public ComponentTypes ComponentType { get; } = ComponentTypes.Joystick;
        public string SerialNumber { get; }
        public Joystick(string serialNumber, List<JoystickButtons> joystickButtons)
        {
            SerialNumber = serialNumber;
            @JoystickButtons = joystickButtons;
        }

        public List<JoystickButtons> @JoystickButtons
        {
            get {
                return vJoystickButtons?.GetRange(0, vJoystickButtons.Count);
            }
            private set { vJoystickButtons = value; }
        }


    }
}
