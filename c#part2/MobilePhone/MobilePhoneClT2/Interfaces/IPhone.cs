using System.Collections.Generic;
using MobilePhoneClT2.Implementation;
using System;
using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Interfaces
{
    public interface IPhone:IComponent, IInterconnection
    {
        List<IComponent> PhoneComponents { get;}
        FormFactor FormFactor { get;}
        string SimCard { get; set;}

        IPhone PluginDevice(IInterconnection device, Action<int> action = null);
        IPhone DisconnectDevice(IInterconnection device);
        Task ExecuteDevice<T>(Action<int> progressReportAction = null, int? executeTimes = null) where T : class, IInterconnection;
        T UseComponent<T>() where T : class, IComponent;
        Contact GetMyContact(TextBoxOutput output);
        void AddContact(params Contact[] contacts);
        void SendSms(string smsText, TextBoxOutput output = null, params string[] names);

    }
}
