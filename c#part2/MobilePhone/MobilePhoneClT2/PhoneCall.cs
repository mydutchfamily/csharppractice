using MobilePhoneClT2.Interfaces.Markers;
using System;
using System.Collections.Generic;

namespace MobilePhoneClT2
{
    public class PhoneCall : IMemory, IEquatable<PhoneCall>, IComparable<PhoneCall>
    {
        private List<PhoneCall> vLinkedCalls;
        public enum CallDirection { Outgoing, Incoming };
        public int Duration { get;  set; }
        public string From { get;  set; }
        public DateTime StartTime { get;  set; }
        public string To { get;  set; }
        public CallDirection Direction { get; set; }

        public Action<PhoneCall> Caller { get; set; }

        public PhoneCall()
        {
            vLinkedCalls = new List<PhoneCall>();
            vLinkedCalls.Add(this);
        }

        public List<PhoneCall> LinkedCalls
        {
            get
            {
                return vLinkedCalls;
            }
        }

        internal PhoneCall Clone()
        {
            return new PhoneCall()
            {
                To = this.To == null ? null : String.Copy(this.To),
                From = this.From == null ? null : String.Copy(this.From),
                StartTime = this.StartTime,
                Duration = this.Duration,
                Direction = (CallDirection)(int)this.Direction,
                Caller = this.Caller
            };
        }

        public override string ToString()
        {
            return $"{Direction} call from {From} to {To} at {StartTime} {Duration} seconds long";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            var pc = obj as PhoneCall;
            return From == pc.From && To == pc.To && Direction == pc.Direction;
        }

        public override int GetHashCode()
        {
            return this.From.GetHashCode() ^ this.To.GetHashCode() ^ this.Direction.GetHashCode();
        }

        bool IEquatable<PhoneCall>.Equals(PhoneCall other)
        {
            return From == other.From
                && To == other.To
                && Math.Abs((StartTime - other.StartTime).TotalSeconds) < 1
                && Direction == other.Direction;
        }

        public int CompareTo(PhoneCall other)//IComparable<PhoneCall> used for xxx.Sort();
        {
            if (other == null)
                return 1;

            int order = string.Compare(From, other.From, StringComparison.CurrentCulture);

            if (order != 0)
                return order;

            return string.Compare(Direction.ToString(), other.Direction.ToString(), StringComparison.CurrentCulture);

        }

        public static bool operator ==(PhoneCall x, PhoneCall y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(PhoneCall x, PhoneCall y)
        {
            return !object.Equals(x, y);
        }
    }
}
