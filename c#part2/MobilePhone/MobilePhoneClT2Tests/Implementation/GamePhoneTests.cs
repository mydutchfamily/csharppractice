using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Implementation;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Implementation.Tests
{
    [TestClass()]
    public class GamePhoneTests
    {
        private static string writtenText = "";
        private class outputTest : IOutput
        {
            public void Write(string text)
            {
                writtenText = text;
            }
            public void WriteLine(string text)
            {
                writtenText = text + "\n";
            }
        }

        [TestMethod()]
        public async Task HeadsetSonyOutputTest()
        {
            IPhone gamePhone = new GamePhone(FormFactor.Bar, "BP20200321");

            IOutput output = new outputTest();

            IInterconnection headsetSony = new HeadsetSony("BP20200321");

            headsetSony.PluginToUse = Plugins.HeadSetJack35;
            await gamePhone.PluginDevice(headsetSony, (i) => { output.WriteLine("HeadsetSony in Action"); }).ExecuteDevice<HeadsetSony>();

            Assert.AreEqual("HeadsetSony in Action\n", writtenText);
        }

        [TestMethod()]
        public async Task PowerBankOutputTest()
        {
            IPhone gamePhone = new GamePhone(FormFactor.Bar, "BP20200321");

            IOutput output = new outputTest();

            IInterconnection powerBank = new PowerBank("BP20200325");
            powerBank.PluginToUse = Plugins.Usb;

            await gamePhone.PluginDevice(powerBank, (i) => { output.WriteLine($"Phone is charging by {nameof(PowerBank)}"); }).ExecuteDevice<PowerBank>(executeTimes: 1);

            Assert.AreEqual("Phone is charging by PowerBank\n", writtenText);
        }
    }
}