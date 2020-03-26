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
        public void HeadsetSonyOutputTest()
        {
            IPhone gamePhone = new GamePhone("Bar", "BP20200321");

            IOutput output = new outputTest();

            IInterconnection headsetSony = new HeadsetSony("BP20200321", output);

            headsetSony.PluginToUse = Plugins.HeadSetJack35;
            gamePhone.PluginDevice(headsetSony).ExecuteDevice(typeof(HeadsetSony).Name);

            Assert.AreEqual("HeadsetSony in Action\n", writtenText);
        }

        [TestMethod()]
        public void PowerBankOutputTest()
        {
            IPhone gamePhone = new GamePhone("Bar", "BP20200321");

            IOutput output = new outputTest();

            IInterconnection powerBank = new PowerBank("BP20200325", output);
            powerBank.PluginToUse = Plugins.Usb;

            gamePhone.PluginDevice(powerBank).ExecuteDevice(typeof(PowerBank).Name);

            Assert.AreEqual("Phone is charging by PowerBank\n", writtenText);
        }
    }
}