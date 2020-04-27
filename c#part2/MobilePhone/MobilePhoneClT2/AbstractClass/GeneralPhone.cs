using System;
using System.Collections.Generic;
using System.Text;
using MobilePhoneClT2.Implementation;
using System.Linq;
using MobilePhoneClT2.Interfaces;
using MobilePhoneClT2.Enums;

namespace MobilePhoneClT2.AbstractClass
{
    public abstract class GeneralPhone : IPhone
    {

        private string vSimCard;
        private string vFormFactor;
        private string vSerialNumber;
        private Contact myContact;
        private List<IComponent> vPhoneComponents;
        protected List<IInterconnection> connectedDevices = new List<IInterconnection>();
        protected HashSet<System.Collections.ICollection> Memory { get; set; }

        public GeneralPhone(string formFactor, string serialNumber)
        {
            SerialNumber = serialNumber;
            FormFactor = formFactor;
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
        public string FormFactor { get; }
        public virtual List<Plugins> SupportedPlugins
        {
            get
            {
                throw new NotImplementedException("No supported plugins provided for this phone");
            }
        }

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

        public virtual IPhone PluginDevice(IInterconnection device)
        {
            if (SupportedPlugins.Contains(device.PluginToUse))
            {
                connectedDevices.Add(device);
            }
            else
            {
                throw new NotImplementedException("Not supported type of device connection");
            }

            return this;
        }

        public Boolean ExecuteDevice(string deviceType)
        {
            IInterconnection device = null;
            foreach (IInterconnection item in connectedDevices) {
                if (deviceType.Equals(item.GetType().Name))
                {
                    device = item;
                    break;
                }
            }

            if (device is IPlayback)
            {
                return device.DoAction();
            }
            else if (device is IPowerSupply)
            {
                return device.DoAction();
            }
            else {
                return false;
            }
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
    }
}
