using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneClT2;
using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static MobilePhoneWfT4.InvokedClasses;

namespace MobilePhoneWfT4.Tests
{
    [TestClass]
    public class SendManySmsTests
    {
        private string[] words = new string[] {"Game", "Box", "Box", "Hey", "Hey", "Hey"};

        //Add the packages MsTest.TestAdapter and MsTest.TestFramework.
        [DataRow(FILTER_ALL_VALUES, FILTER_ALL_VALUES, LogicOperand.OR, "MinAndMax", 12)]
        [DataRow(FILTER_ALL_VALUES, FILTER_ALL_VALUES, LogicOperand.AND, "MinAndMax", 12)]
        [DataRow("Game", FILTER_ALL_VALUES, LogicOperand.AND, "MinAndMax", 2)]
        [DataRow("Game", "Vova", LogicOperand.AND, "MinAndMax", 0)]
        [DataRow(FILTER_ALL_VALUES, "", LogicOperand.AND, "MinAndMax", 12)]
        [DataRow(FILTER_ALL_VALUES, FILTER_ALL_VALUES, LogicOperand.AND, "DayBefore", 0)]
        [DataRow(FILTER_ALL_VALUES, FILTER_ALL_VALUES, LogicOperand.AND, "DayAfter", 0)]
        [DataRow("Hey", "", LogicOperand.AND, "MinAndMax", 6)]
        [DataTestMethod]
        public void FilteringSms(string subString, string receivedFrom, LogicOperand logic, string fromTo, int expectedResults)
        {
            DateTime from, to;
            SetDates(fromTo, out from, out to);

            GeneralPhone smsPhone1 = new SmsPhone(FormFactor.Bar, "BP20200406");
            smsPhone1.AddSimCard(new SimCard());
            GeneralPhone smsPhone2 = new SmsPhone(FormFactor.Bar, "BP20200409");
            smsPhone2.AddSimCard(new SimCard());

            var contact2 = smsPhone2.GetMyContact("Vova");
            smsPhone1.AddContact(contact2);

            int i = 0;
            foreach (string word in words)
            {
                smsPhone1.SendSms(smsText: $"Test Message {i++} {word}", names: "Vova");
            }

            FilterParams filterParams = new FilterParams()
            {
                SubString = subString,
                ReceivedFrom = receivedFrom,
                Logic = logic,
                From = from,
                To = to
            };
            Func<IEnumerable<GeneralPhone>, FilterParams, ListViewItem[]> filterChanged = UpdateFiltering;
            ListViewItem[] lvItems = filterChanged(new List<GeneralPhone>() { smsPhone1, smsPhone2 }, filterParams);

            Assert.AreEqual(words.Length, smsPhone1.UseComponent<Memory>().Get<SmsMessage>().Count());
            Assert.AreEqual(words.Length, smsPhone2.UseComponent<Memory>().Get<SmsMessage>().Count());
            Assert.AreEqual(expectedResults, lvItems.Count());
        }

        private static void SetDates(string fromTo, out DateTime from, out DateTime to)
        {
            switch (fromTo)
            {
                case "MinAndMax":
                    from = DateTimePicker.MinimumDateTime;
                    to = DateTimePicker.MaximumDateTime;
                    break;
                case "DayBefore":
                    from = DateTime.Now.AddDays(-2);
                    to = DateTime.Now.AddDays(-1);
                    break;
                case "DayAfter":
                    from = DateTime.Now.AddDays(2);
                    to = DateTime.Now.AddDays(1);
                    break;
                default:
                    throw new Exception("No such case to set dates");
            }
        }
    }
}