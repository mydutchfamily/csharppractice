using MobilePhoneClT2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation
{
    public class Keyboard : IKeyboard
    {
        private List<IComponent> vKeyboardComponents = new List<IComponent>();
        public virtual ComponentTypes ComponentType { get; } = ComponentTypes.Keyboard;
        public string SerialNumber { get; }
        public List<string> Languages { get; } = new List<string>();

        public virtual List<IComponent> KeyboardComponents
        {
            get { return vKeyboardComponents?.GetRange(0, vKeyboardComponents.Count); }
            protected set { vKeyboardComponents = value; }
        }

        public Keyboard(List<string> languages, string serialNumber)
        {
            this.SerialNumber = serialNumber;
            this.Languages = languages;
        }
        public override string ToString()
        {
            return $"keyboard support {Languages.Count} languages: {String.Join(",", Languages)}";
        }

    }
}
