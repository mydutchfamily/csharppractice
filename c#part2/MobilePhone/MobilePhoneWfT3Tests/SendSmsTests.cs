using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneClT2;
using MobilePhoneClT2.Implementation;
using MobilePhoneClT2.Interfaces;
using MobilePhoneWfT3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobilePhoneClT2.Enums;

namespace MobilePhoneWfT3.Tests
{
    [TestClass()]
    public class SendSmsTests
    {
        RichTextBox richTextBox = new RichTextBox();
        TextBoxOutput output;

        [TestInitialize]
        public void Initialize()
        {
            output = new TextBoxOutput(richTextBox);
        }
        [TestCleanup]
        public void Cleanup()
        {
            richTextBox.Text = "";
        }

        [TestMethod()]
        public void TextBoxOutPut_NoneFormating()
        {
            output.Formating = TextBoxOutput.FormatingStyle.None;
            string tesString = "TEST STRING";
            output.Write(tesString);

            Assert.AreEqual<String>(tesString, richTextBox.Text, $"Formatting {TextBoxOutput.FormatingStyle.None} should be applied");
        }

        [TestMethod()]
        public void TextBoxOutPut_TimeFormating()
        {
            DateTime expectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
            output.Formating = TextBoxOutput.FormatingStyle.WithTime;
            string tesString = "TEST STRING";

            output.Write(tesString);

            int timeEndAt = richTextBox.Text.LastIndexOf(':');
            string time = richTextBox.Text.Remove(timeEndAt, richTextBox.Text.Length - timeEndAt);
            DateTime actualDateTime;

            Assert.IsTrue(DateTime.TryParse(time,out actualDateTime), "Time should be in the beginning of the message");
            Assert.IsTrue(actualDateTime.CompareTo(expectedDateTime)>= 0, "Actual time should be equal or after expected time");
        }

        private class MockTextBoxOutput : TextBoxOutput
        {
            public MockTextBoxOutput(RichTextBox richTextBox) : base(richTextBox)
            {
            }

            public override void Write(string text)
            {
                base.Write(text);
            }

            public override void WriteLine(string text)
            {
                base.WriteLine(text);
                methodCalled++;
            }
        }
        private static int methodCalled = 0;

        [TestMethod()]
        public void MessageWasReceived()
        {
            IPhone smsPhone1 = new SmsPhone("Bar", "BP20200406");
            IPhone smsPhone2 = new SmsPhone("Bar", "BP20200409");
            string tesString = "TEST STRING";
            MockTextBoxOutput mockoutput = new MockTextBoxOutput(richTextBox);

            Action<SmsMessage> subscribe = smsPhone2.UseComponent<SmsCommunicator>().Subscribe(mockoutput);
            smsPhone1.UseComponent<SmsCommunicator>().SetRecipient(subscribe).SendSms(tesString);

            Assert.IsTrue(methodCalled == 1, $"Method {nameof(mockoutput.WriteLine)} must be called once");
        }
    }
}