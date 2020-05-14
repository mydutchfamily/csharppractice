using System.Collections.Generic;
using System;
using MobilePhoneClT2.Enums;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Interfaces
{
    public interface IPhone:IComponent, IInterconnection
    {
        List<IComponent> PhoneComponents { get;}
        FormFactor FormFactor { get;}
        SimCard[] SimCards { get;}
        SimCard ActiveSimCard { get; }

        IPhone PluginDevice(IInterconnection device, Action<int> action = null);
        IPhone DisconnectDevice(IInterconnection device);
        Task ExecuteDevice<T>(Action<int> progressReportAction = null, int? executeTimes = null) where T : class, IInterconnection;
        T UseComponent<T>() where T : class, IComponent;
        Contact GetMyContact(string name, int simNum = 0);
        void AddContact(params Contact[] contacts);
        void SendSms(string smsText, TextBoxOutput output = null, int simNum = 0, params string[] names);
        void MakeCall(int duration, string name, TextBoxOutput output = null, int simNum = 0);

        IPhone AddSimCard(SimCard simCard, TextBoxOutput output = null);
        SimCard RemoveSimCard(int simCardIx);
        IPhone RemoveSimCard(SimCard simCard);
        IPhone SetActiveSimCard(int simCardIx);
    }
}
