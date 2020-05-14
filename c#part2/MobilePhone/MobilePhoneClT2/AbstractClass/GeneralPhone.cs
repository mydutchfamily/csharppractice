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
        private List<IComponent> vPhoneComponents;
        private int activeSimCardIx = 0;
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

        public SimCard ActiveSimCard
        {
            get { return SimCards[activeSimCardIx]; }
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

        public virtual SimCard[] SimCards { get; } = new SimCard[1];

        public override string ToString()
        {
            StringBuilder strBldr = new StringBuilder();
            strBldr.AppendLine($"phone form factor is:{FormFactor}");

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
            }
            else
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
            foreach (IInterconnection item in connectedDevices)
            {
                if (typeof(T).Name == item.GetType().Name)
                {
                    device = (T)item;
                    break;
                }
            }

            if (progressReportAction != null)
            {
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

        public bool TryGetContact(string name, out Contact contact)
        {
            contact = this.UseComponent<Memory>()?.Get<Contact>()?.Where(c => c.Name == name).Single();
            return contact != null;
        }

        public void SendSms(string smsText, TextBoxOutput output = null, int simNum = 0, params string[] names)
        {
            Contact contact;
            foreach (var name in names)
            {
                if (this.TryGetContact(name, out contact))
                {
                    this.UseComponent<Communicator>().SendSms(contact, smsText, output, simNum);
                }
            }
        }

        public void MakeCall(int duration, string name, TextBoxOutput output = null, int simNum = 0)
        {
            Contact contact = this.UseComponent<Memory>().Get<Contact>().Where(x => x.Name == name).First();

            this.UseComponent<Communicator>().MakeCall(contact, duration, output, simNum);
        }

        public Contact GetMyContact(string name, int simNum = 0)
        {
            Contact contact = new Contact(name, SimCards[simNum].SmsReceiver, SimCards[simNum].CallReceiver);
            return contact;
        }

        public void AddContact(params Contact[] contacts)
        {
            var allContacts = this.UseComponent<Memory>().Get<Contact>();

            foreach (var item in contacts)
            {
                if (allContacts.Contains(item))//IEquatable<Contact>
                {
                    throw new Exception($"Contact details for {item.Name} already saved");
                }
                else
                {
                    var contact = allContacts.Where(c => c.Name == item.Name).FirstOrDefault();

                    if (contact == null)
                    {
                        var addContact = item.Clone();
                        this.UseComponent<Memory>().Add<Contact>(addContact);
                    }
                    else
                    {
                        contact.SmsReceiver.Add(item.SmsReceiver[0]);
                        contact.CallReceiver.Add(item.CallReceiver[0]);
                    }
                }
            }
        }

        public async Task DoAction(int? executeTimes = null)
        {
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

        public IPhone AddSimCard(SimCard simCard, TextBoxOutput output = null)
        {
            bool added = false;
            for (int i = 0; i < SimCards.Length; i++)
            {
                if (SimCards[i] == null)
                {
                    SimCards[i] = simCard;
                    added = true;
                    break;
                }
            }

            if (!added) throw new Exception("No free slot found for SimCard");

            simCard.CallReceiver = this.UseComponent<Communicator>().CallSubscribe(output);
            simCard.SmsReceiver = this.UseComponent<Communicator>().SmsSubscribe(output);

            return this;
        }

        public SimCard RemoveSimCard(int simCardIx)
        {
            SimCard sim = SimCards[simCardIx];
            SimCards[simCardIx] = null;
            sim.CallReceiver = null;
            sim.SmsReceiver = null;

            return sim;
        }

        public IPhone RemoveSimCard(SimCard simCard)
        {
            for (int i = 0; i < SimCards.Length; i++)
            {
                if (SimCards[i] == simCard) {
                    SimCards[i] = null;
                    simCard.CallReceiver = null;
                    simCard.SmsReceiver = null;
                }
            }
            return this;
        }

        public IPhone SetActiveSimCard(int simCardIx)
        {
            activeSimCardIx = simCardIx;
            return this;
        }
    }
}
