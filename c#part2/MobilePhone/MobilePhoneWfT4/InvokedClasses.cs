using MobilePhoneClT2;
using MobilePhoneClT2.AbstractClass;
using MobilePhoneClT2.Implementation;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static MobilePhoneWfT4.InvokedClasses;

namespace MobilePhoneWfT4
{
    public class InvokedClasses
    {
        public static string[] words = new string[] { "Game", "Box", "Beggin", "Mountains", "Hey", "Scarlett", "Dj", "Dragons", "Skyfall", "Lada", "Xray", "Connected" };
        public enum LogicOperand { OR, AND };
        public const string FILTER_ALL_VALUES = "";

        public static ListViewItem[] UpdateFiltering(IEnumerable<GeneralPhone> phones, FilterParams filterParams)
        {
            IEnumerable<SmsMessage> allSms = new SmsMessage[0];

            allSms = phones.Select(p => p.UseComponent<Memory>().Get<SmsMessage>()).SelectMany(p => p);

            Func<SmsMessage, bool> where;

            if (filterParams.Logic == LogicOperand.OR)
            {
                where = sm => (filterParams.SubString == FILTER_ALL_VALUES ? true : sm.Text.Contains(filterParams.SubString))
                || (filterParams.ReceivedFrom == FILTER_ALL_VALUES ? true : sm.ReceivedFrom == filterParams.ReceivedFrom)
                || sm.SentTime.CompareTo(filterParams.From) >= 0
                || sm.SentTime.CompareTo(filterParams.To) <= 0;
            }
            else
            {
                where = sm => (filterParams.SubString == FILTER_ALL_VALUES ? true : sm.Text.Contains(filterParams.SubString))
                && (filterParams.ReceivedFrom == FILTER_ALL_VALUES ? true : sm.ReceivedFrom == filterParams.ReceivedFrom)
                && sm.SentTime.CompareTo(filterParams.From) >= 0
                && sm.SentTime.CompareTo(filterParams.To) <= 0;
            };

            return allSms.Where(where).GroupBy(sm => new { sm.ReceivedFrom, sm.SendTo, sm.Text }).Select(g => g.First())
            .Select(sm => new ListViewItem(new[] { sm.ReceivedFrom, sm.SendTo, sm.Text }))
            .ToArray();
        }

        public static string[] FilteringSenders(IEnumerable<GeneralPhone> phones)
        {
            IEnumerable<SmsMessage> allSms = new SmsMessage[0];

            foreach (IPhone phone in phones)
            {
                allSms = allSms.Concat(phone.UseComponent<Memory>().Get<SmsMessage>());
            }

            var receivedFrom = allSms.Where(c=> c.ReceivedFrom != null).Select(c => c.ReceivedFrom).Distinct();

            return new List<string>() { FILTER_ALL_VALUES }.Concat(receivedFrom).ToArray();
        }

    }
    public class FilterParams
    {
        public string SubString { get; set; }
        public string ReceivedFrom { get; set; }

        public LogicOperand Logic { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
