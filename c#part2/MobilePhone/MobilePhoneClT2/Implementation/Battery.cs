using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneClT2.Enums;

namespace MobilePhoneClT2.Implementation
{
    public class Battery : IComponent
    {
        private int _capacity;
        public Battery(string serialNumber, int capacity)
        {
            SerialNumber = serialNumber;
            Capacity = capacity;
        }
        public ComponentTypes ComponentType
        {
            get;
        } = ComponentTypes.Battery;

        public string SerialNumber
        {
            get; private set;
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    _capacity = value;
                else
                    throw new Exception("Battery out of order!");
            }
        }
    }
}
