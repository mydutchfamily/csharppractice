using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneT1.Interfaces
{
    public abstract class GeneralPhone : IPhone
    {

        private string vSimCard;
        private string vFormFactor;
        private string vSerialNumber;
        private List<IComponent> vPhoneComponents;

        public GeneralPhone(string formFactor, string serialNumber)
        {
            vSerialNumber = serialNumber;
            vFormFactor = formFactor;
        }

        public string ComponentType { get; } = "Phone body";

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

        public string SerialNumber
        {
            get
            {
                return vSerialNumber;
            }
        }

        public List<IComponent> PhoneComponents
        {
           get { return vPhoneComponents?.GetRange(0, vPhoneComponents.Count); }
           protected set { vPhoneComponents = value; }
        }

        public string FormFactor
        {
            get
            {
                return vFormFactor;
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
    }
}
