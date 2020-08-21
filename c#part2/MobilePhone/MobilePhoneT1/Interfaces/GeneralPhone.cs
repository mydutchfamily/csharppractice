using MobilePhoneClT2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneT1.Interfaces
{
    public abstract class GeneralPhone : IPhone
    {

        private string vSimCard;
        private List<IComponent> vPhoneComponents;

        public GeneralPhone(FormFactor formFactor, string serialNumber)
        {
            SerialNumber = serialNumber;
            FormFactor = formFactor;
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
            get;
        }

        public List<IComponent> PhoneComponents
        {
           get { return vPhoneComponents?.GetRange(0, vPhoneComponents.Count); }
           protected set { vPhoneComponents = value; }
        }

        public FormFactor FormFactor
        {
            get;
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
