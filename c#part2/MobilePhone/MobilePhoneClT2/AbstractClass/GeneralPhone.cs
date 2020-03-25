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
        private List<IComponent> vPhoneComponents;
        protected List<IInterconnection> connectedDevices = new List<IInterconnection>();

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
    }
}
