using System.Collections.Generic;
using MobilePhoneClT2.Implementation;
using System;
using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;

namespace MobilePhoneClT2.Interfaces
{
    public interface IPhone:IComponent
    {
        List<IComponent> PhoneComponents { get;}

        string FormFactor { get;}

        string SimCard { get; set;}

        IPhone PluginDevice(IInterconnection device);

        List<Plugins> SupportedPlugins { get; }

        Boolean ExecuteDevice(string deviceType);
        T UseComponent<T>() where T : class, IComponent;
    }
}
