using System.Collections.Generic;
using System.Text;
using MobilePhoneT1.Interfaces;

namespace MobilePhoneT1.Implementation
{
    class Phone : GeneralPhone
    {
        public Phone(string formFactor, string serialNumber)
        {
            this.SerialNumber = serialNumber;
            this.FormFactor = formFactor;
        }

        private Phone()
        {
        }
    }
}
