using System.Collections.Generic;
using System.Text;

namespace MobilePhoneT1.Interfaces
{
    public abstract class GeneralPhone:IPhone
    {
    
    private string vOperator;
    private List<IComponent> vPhoneComponents = new List<IComponent>();

    public string ComponentType { get; } = "Phone body";
    public string SerialNumber { get; set; }

    public string FormFactor { get; set; }

        public string Operator
    {
        get
        {
            return vOperator ?? "N/A";
        }

        set
        {
            vOperator = value;
        }
    }

    public List<IComponent> PhoneComponents {
        get { return vPhoneComponents; }
        set { vPhoneComponents = value; }
    }

        public string GetDescription()
    {
        StringBuilder strBldr = new StringBuilder();
        strBldr.AppendLine($"phone form factor is:{this.FormFactor}, used operator: {this.Operator}");

        if (vPhoneComponents != null && vPhoneComponents.Count > 0)
        {
            foreach (IComponent component in vPhoneComponents)
            {
                strBldr.AppendLine(component.GetDescription());
            }
        }
        return strBldr.ToString();
    }
}
}
