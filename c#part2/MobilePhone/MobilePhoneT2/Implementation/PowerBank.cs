using MobilePhoneT2.AbstractClass;
using MobilePhoneT2.Enums;
using MobilePhoneT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT2.Implementation
{
    class PowerBank : InterconnectionCommon, IPowerSupply
    {
        private IOutput output;
        public PowerBank(string serialNumber, IOutput output) {
            this.SerialNumber = serialNumber;
            this.vSupportedPlugins = new List<Plugins> { Plugins.Usb, Plugins.TypeC };
            this.output = output;
        }
        public override ComponentTypes ComponentType { get; } = ComponentTypes.Interconnection;
        public override string SerialNumber { get; }
        public override bool DoAction(object data = null)
        {
            output.WriteLine($"Phone is charging by {nameof(PowerBank)}");
            return true;
        }

        public override string ToString()
        {
            return $"This is Powerbank. It supports {String.Join(" and ", vSupportedPlugins)} plugins";
        }
    }
}
