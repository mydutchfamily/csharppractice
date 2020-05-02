using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation
{
    public class PowerBank : InterconnectionCommon, IPowerSupply
    {
        public PowerBank(string serialNumber) : base(serialNumber)
        {
            this.vSupportedPlugins = new List<Plugins> { Plugins.Usb, Plugins.TypeC };
        }

        public override ComponentTypes ComponentType { get; } = ComponentTypes.Interconnection;

        public override async Task DoAction(int? executeTimes = null)
        {
            await Task.Run(() =>
            {
                while ((Action != null && executeTimes != null && executeTimes > 0)
                        || (Action != null && executeTimes == null))
                {
                    lock (syncRoot)
                    {
                        Action?.Invoke(4);
                    }

                    executeTimes = executeTimes == null ? null : --executeTimes;
                    Thread.Sleep(2000);
                    Debug.WriteLine("**** power is supplied  *****");
                }
                if (Action == null || (executeTimes != null && executeTimes <= 0))
                    return;
            }
            );
        }

        public override string ToString()
        {
            return $"This is Powerbank. It supports {String.Join(" and ", vSupportedPlugins)} plugins";
        }
    }
}
