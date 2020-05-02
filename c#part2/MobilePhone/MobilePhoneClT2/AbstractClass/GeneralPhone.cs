using System;
using System.Collections.Generic;
using System.Text;
using MobilePhoneClT2.Implementation;
using System.Linq;
using MobilePhoneClT2.Interfaces;
using MobilePhoneClT2.Enums;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MobilePhoneClT2.AbstractClass
{
    public abstract class GeneralPhone : IPhone
    {

        private string vSimCard;
        private string vFormFactor;
        private string vSerialNumber;
        private Contact myContact;
        private List<IComponent> vPhoneComponents;
        protected IProgress<int> progress;
        protected static object syncRoot = new object();
        protected HashSet<IInterconnection> connectedDevices;
        protected HashSet<System.Collections.ICollection> Memory { get; set; }
        protected Dictionary<string, Action<int>> deviceActions;

        public GeneralPhone(FormFactor formFactor, string serialNumber)
        {
            SerialNumber = serialNumber;
            FormFactor = formFactor;
            this.deviceActions = new Dictionary<string, Action<int>>();
            connectedDevices = new HashSet<IInterconnection>();
        }

        public ComponentTypes ComponentType { get; } = ComponentTypes.Phone;

        public string SimCard
        {
            get
            {
                return vSimCard ?? "N/A";
            }

            set
            {
                vSimCard = value;
            }
        }

        public string SerialNumber { get; }
        public List<IComponent> PhoneComponents
        {
           get { return vPhoneComponents?.GetRange(0, vPhoneComponents.Count); }
           protected set { vPhoneComponents = value; }
        }
        public FormFactor FormFactor { get; }
        public virtual List<Plugins> SupportedPlugins { get; } = new List<Plugins>() { Plugins.Button };

        public Plugins PluginToUse { get; set; } = Plugins.Button;
        public Action<int> Action { get; set; }

        public override string ToString()
        {
            StringBuilder strBldr = new StringBuilder();
            strBldr.AppendLine($"phone form factor is:{FormFactor}, used operator: {SimCard}");

            if (vPhoneComponents != null && vPhoneComponents.Count > 0)
            {
                foreach (IComponent component in vPhoneComponents)
                {
                    strBldr.AppendLine(component.ToString());
                }
            }
            return strBldr.ToString();
        }

        public virtual IPhone PluginDevice(IInterconnection device, Action<int> action = null)
        {
            if (SupportedPlugins.Contains(device.PluginToUse))
            {
                connectedDevices.Add(device);

                if (action != null)
                    device.Action = action;
                else if (deviceActions.ContainsKey(device.GetType().Name))
                    device.Action = deviceActions[device.GetType().Name];
                else
                    throw new NotImplementedException($"No action provided to execute for device: {device.GetType().Name}");
            } else
            {
                throw new NotImplementedException($"Not supported type of device connection: {device.PluginToUse}");
            }
            return this;
        }

        public IPhone DisconnectDevice(IInterconnection device)
        {
            if (connectedDevices.Remove(device))
            {
                device.Action = null;
            };

            return this;
        }

        public async Task ExecuteDevice<T>(Action<int> progressReportAction = null, int? executeTimes = null) where T : class, IInterconnection
        {
            T device = null;
            foreach (IInterconnection item in connectedDevices) {
                if (typeof(T).Name == item.GetType().Name)
                {
                    device = (T)item;
                    break;
                }
            }

            if (progressReportAction != null) {
                progress = new Progress<int>(progressReportAction);
            }

            await device.DoAction(executeTimes);
        }

       public T UseComponent<T>() where T : class, IComponent
        {
            T component = null;
            foreach (IComponent item in vPhoneComponents)
            {
                if (typeof(T).Name.Equals(item.GetType().Name))
                {
                    component = (T)item;
                    break;
                }
            }

            return component;
        }

        public bool TryGetContact(string name, out Contact contact) {
            contact = this.UseComponent<Memory>()?.Get<Contact>()?.Where(c => c.Name == name).Single();
            return contact != null;
        }

        public void SendSms(string smsText, TextBoxOutput output = null, params string[] names) {
            Contact contact;
            foreach (var name in names)
            {
                if (this.TryGetContact(name, out contact))
                {
                    this.UseComponent<SmsCommunicator>().SendSms(contact, smsText, output);
                }
            }
        }

        public Contact GetMyContact(TextBoxOutput output = null) {
            if (myContact == null)
            {
                Action<SmsMessage> subscribe = this.UseComponent<SmsCommunicator>().Subscribe(output);
                myContact = new Contact(this.SimCard, subscribe);
            }

            return myContact;
        }
        public void AddContact(params Contact[] contacts) {
            this.UseComponent<Memory>().Add<Contact>(contacts);
        }

        public async Task DoAction(int? executeTimes = null) {
            await Task.Run(() =>
            {
                while ((Action != null && executeTimes != null && executeTimes > 0)
                        || (Action != null && executeTimes == null))
                {
                    lock (syncRoot)
                    {
                        Action?.Invoke(3);
                    }

                    executeTimes = executeTimes == null ? null : --executeTimes;
                    Thread.Sleep(3000);
                    Debug.WriteLine("**** power is consumed  *****");
                }
                if (Action == null && executeTimes != null && executeTimes <= 0)
                    return;
            }
            );
        }
    }
}
