using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1
{
    class Phone : IPhone
    {
        private readonly string formFactor;
        private string @operator;
        List<IComponent> phoneComponents = new List<IComponent>();

        public Phone(string formFactor) {
            this.formFactor = formFactor;
        }
        public string FormFactor
        {
            get
            {
                return formFactor;
            }
        }

        public string Operator
        {
            get
            {
                return @operator ?? "N/A";
            }

            set
            {
                @operator = value;
            }
        }

        public List<IComponent> PhoneComponents
        {
            get
            {
                return phoneComponents;
            }

            set
            {
                this.phoneComponents = value;
            }
        }

        public string GetDescription()
        {
            StringBuilder strBldr = new StringBuilder();
            strBldr.AppendLine($"phone form factor is:{this.formFactor}, used operator {this.Operator}");

            if (phoneComponents != null && phoneComponents.Count > 0)
            {
                foreach (IComponent component in phoneComponents) {
                    strBldr.AppendLine(component.GetDescription());
                }
            }
            return strBldr.ToString();
            
        }
    }
}
