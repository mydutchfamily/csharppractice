﻿using MobilePhoneClT2.AbstractClass;
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
        private IOutput output;
        public HeadsetSony(string serialNumber, IOutput output) {
            this.SerialNumber = serialNumber;
            this.vSupportedPlugins = new List<Plugins> { Plugins.Bluetooth, Plugins.HeadSetJack35 };
            this.output = output;
        }
        public override ComponentTypes ComponentType { get; } = ComponentTypes.Interconnection;
        
        public override string SerialNumber { get; }


        public override Boolean DoAction(object data = null)
        {
            output.WriteLine("HeadsetSony in Action");
            return true;
        }

        public override string ToString()
        {
            return $"This is Sony headphones. It supports {String.Join(" or ", vSupportedPlugins)} plugins";
        }
    }
}