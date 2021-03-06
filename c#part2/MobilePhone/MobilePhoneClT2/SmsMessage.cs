﻿using MobilePhoneClT2.Interfaces.Markers;
using System;

namespace MobilePhoneClT2
{
    public class SmsMessage: IMemory
    {
        public enum MsgStatus { Sent, Received};
        public SmsMessage()
        {
        }
        public string SendTo{ get; set; }
        public string ReceivedFrom { get; set; }
        public string Text{ get; set; }
        public DateTime SentTime { get; set; }
        public DateTime ReceivedTime { get; set; }
        public MsgStatus Status { get; set; }
        public bool IsRead { get; set; } = false;
        public Action<SmsMessage> Sender { get; set; }

        public SmsMessage Clone() {
            return new SmsMessage() {
                SendTo = this.SendTo == null ? null:String.Copy(this.SendTo),
                ReceivedFrom = this.ReceivedFrom == null ? null : String.Copy(this.ReceivedFrom),
                Text = String.Copy(this.Text),
                ReceivedTime = this.ReceivedTime,
                SentTime = this.SentTime,
                Status = (MsgStatus)(int)this.Status,
                Sender = this.Sender
            };            
        }

        public override string ToString()
        {           
            if (Status == MsgStatus.Received)
                return $"{Status} from: {ReceivedFrom}/{ReceivedTime.ToString("dd/MM/yyyy HH:mm:ss")}/{Text}";
            else
                return $"{Status} to: {SendTo}/{SentTime.ToString("dd/MM/yyyy HH:mm:ss")}/{Text}";
        }
    }
}
