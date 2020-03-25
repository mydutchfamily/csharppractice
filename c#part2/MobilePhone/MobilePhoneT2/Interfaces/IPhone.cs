using System.Collections.Generic;
using MobilePhoneT2.Implementation;
using System;
using MobilePhoneT2.AbstractClass;
using MobilePhoneT2.Enums;

namespace MobilePhoneT2.Interfaces
{
    public interface IPhone:IComponent
    {
        List<IComponent> PhoneComponents { get;}

        string FormFactor { get;}

        string SimCard { get; set;}

        IPhone PluginDevice(IInterconnection device);

        List<Plugins> SupportedPlugins { get; }

        Boolean ExecuteDevice(string deviceType);
    }
}
