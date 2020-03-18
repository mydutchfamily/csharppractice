using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1.Implementation
{
    class KeyboardWithJoystick : Keyboard
    {
        public enum JoystickButtons {Up, Down, Left, Right, Ok, Cancel, NumberOfItems};

        public override string ComponentType { get; } = $"Button keypad with {(int)JoystickButtons.NumberOfItems} buttons joystick";
        public KeyboardWithJoystick(List<string> languages, string serialNumber) : base(languages, serialNumber)
        {
        }

        public override string ToString()
        {
            return $"keyboard with {(int)JoystickButtons.NumberOfItems} buttons joystick support {Languages.Count} languages: {string.Join(",", Languages)}";
        }


    }
}
