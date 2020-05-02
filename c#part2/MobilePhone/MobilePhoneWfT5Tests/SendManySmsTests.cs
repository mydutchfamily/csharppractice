using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Implementation;
using MobilePhoneClT2.Interfaces;
using MobilePhoneWfT5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWfT5.Tests
{
    [TestClass]
    public class SendManySmsTests
    {
        [TestMethod]
        public async Task PowerIsConsumed()
        {
            IPhone phone = new SmsPhone(FormFactor.Bar, "SP20200502");

            int originalCapacity = phone.UseComponent<Battery>().Capacity;

            await phone.PluginDevice(phone).ExecuteDevice<SmsPhone>(executeTimes:2);

            int dischargedCapacity = phone.UseComponent<Battery>().Capacity;

            Assert.IsTrue(originalCapacity > 0);
            Assert.IsTrue(originalCapacity > dischargedCapacity);
        }

        [TestMethod]
        public async Task PowerIsSupplied()
        {
            IPhone phone = new SmsPhone(FormFactor.Bar, "SP20200502");

            IInterconnection powerBank = new PowerBank("PB20200502");
            powerBank.PluginToUse = Plugins.Usb;

            int originalCapacity = phone.UseComponent<Battery>().Capacity;

            await phone.PluginDevice(powerBank).ExecuteDevice<PowerBank>(executeTimes: 2);

            int chargedCapacity = phone.UseComponent<Battery>().Capacity;

            Assert.IsTrue(originalCapacity < 100);
            Assert.IsTrue(originalCapacity < chargedCapacity);
        }

        [TestMethod]
        public async Task MaximumCapacityIs100()
        {
            IPhone phone = new SmsPhone(FormFactor.Bar, "SP20200502");

            IInterconnection powerBank = new PowerBank("PB20200502");
            powerBank.PluginToUse = Plugins.Usb;

            phone.UseComponent<Battery>().Capacity = 100;

            int maximumCapacity = phone.UseComponent<Battery>().Capacity;

            await phone.PluginDevice(powerBank).ExecuteDevice<PowerBank>(executeTimes: 2);

            int chargedCapacity = phone.UseComponent<Battery>().Capacity;

            Assert.IsTrue(maximumCapacity == 100);
            Assert.IsTrue(maximumCapacity == chargedCapacity);
        }

        [TestMethod]
        public async Task MinimumCapacityIs0()
        {
            IPhone phone = new SmsPhone(FormFactor.Bar, "SP20200502");

            phone.UseComponent<Battery>().Capacity = 0;

            int minimumCapacity = phone.UseComponent<Battery>().Capacity;

            await phone.PluginDevice(phone).ExecuteDevice<SmsPhone>(executeTimes: 2);

            int dischargedCapacity = phone.UseComponent<Battery>().Capacity;

            Assert.IsTrue(minimumCapacity == 0);
            Assert.IsTrue(minimumCapacity == dischargedCapacity);
        }
    }
}