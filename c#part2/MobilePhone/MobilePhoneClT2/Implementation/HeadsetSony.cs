using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation
{
    public class HeadsetSony : InterconnectionCommon, IPlayback
    {
        public HeadsetSony(string serialNumber) :base(serialNumber)
        {
            this.vSupportedPlugins = new List<Plugins> { Plugins.Bluetooth, Plugins.HeadSetJack35 };
        }

        public override ComponentTypes ComponentType { get; } = ComponentTypes.Interconnection;
        
        public override string ToString()
        {
            return $"This is Sony headphones. It supports {String.Join(" or ", vSupportedPlugins)} plugins";
        }
    }
}
