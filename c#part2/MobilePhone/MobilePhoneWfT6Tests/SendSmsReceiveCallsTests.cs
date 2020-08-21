using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneClT2;
using System;
using System.Collections.Generic;
using System.Linq;
using static MobilePhoneClT2.PhoneCall;

namespace MobilePhoneWfT6.Tests
{
    [TestClass()]
    public class SendSmsReceiveCallsTests
    {
        [TestMethod()]
        public void SortCallListByTime()
        {
            var firstCall = new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() {From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) },
                new PhoneCall() {From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                new PhoneCall() {From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) },
                lastCall,
                firstCall,
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },

            };

            calls.Sort(PhoneCallsByTime.Instance);

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByTimeDeleteFirst()
        {
            var firstCall = new PhoneCall() { From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };
            var removeFirst = new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() {From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) },
                removeFirst,
                new PhoneCall() {From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) },
                lastCall,
                firstCall,
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },

            };

            calls.Sort(PhoneCallsByTime.Instance);

            calls.Remove(removeFirst);

            calls.Sort(PhoneCallsByTime.Instance);

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByTimeDeleteLast()
        {
            var firstCall = new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) };
            var lastCall = new PhoneCall() { From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) };
            var removeLast = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() {From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) },
                removeLast,
                new PhoneCall() { From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                lastCall,
                firstCall,
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },
            };

            calls.Sort(PhoneCallsByTime.Instance);

            calls.Remove(removeLast);

            calls.Sort(PhoneCallsByTime.Instance);

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByTimeDeleteMiddle()
        {
            var firstCall = new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) };
            var removeMiddle = new PhoneCall() { From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() {From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) },
                removeMiddle,
                new PhoneCall() { From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                lastCall,
                firstCall,
                new PhoneCall() { From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) },
            };

            calls.Sort(PhoneCallsByTime.Instance);

            calls.Remove(removeMiddle);

            calls.Sort(PhoneCallsByTime.Instance);

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByFrom()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) },
                firstCall,
                new PhoneCall() {From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                new PhoneCall() {From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) },
                lastCall,            
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },
            };

            calls.Sort();

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByFromAddFirst()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) },
                new PhoneCall() {From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                new PhoneCall() {From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) },
                lastCall,
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },
            };

            calls.Sort();

            calls.Add(firstCall);

            Assert.AreNotEqual(calls.First(), firstCall);

            calls.Sort();

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByFromAddLast()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) },
                new PhoneCall() {From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                new PhoneCall() {From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) },
                firstCall,
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },
            };

            calls.Sort();

            calls.Insert(2,lastCall);

            Assert.AreNotEqual(calls.Last(), lastCall);

            calls.Sort();

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void SortCallListByFromAddMiddle()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "PPPP", To = "TTTT", Caller = null, Direction = CallDirection.Outgoing, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };
            var middleCall = new PhoneCall() { From = "EEEE", To = "RRRR", Caller = null, Direction = CallDirection.Incoming, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 10) };

            var calls = new List<PhoneCall>() {
                new PhoneCall() { From = "OOOO", To = "YYYY", Caller = null, Direction = CallDirection.Outgoing, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 50) },
                new PhoneCall() {From = "CCCC", To = "DDDD", Caller = null, Direction = CallDirection.Incoming, Duration = 200, StartTime = new DateTime(2000, 10, 5, 10, 20, 40) },
                lastCall,
                firstCall,
                new PhoneCall() {From = "IIII", To = "UUUU", Caller = null, Direction = CallDirection.Outgoing, Duration = 300, StartTime = new DateTime(2000, 10, 5, 10, 20, 30) },
            };

            calls.Sort();

            calls.Insert(0, middleCall);

            Assert.AreNotEqual(calls.First(), firstCall);

            calls.Sort();

            Assert.AreEqual(calls.First(), firstCall);
            Assert.AreEqual(calls.Last(), lastCall);
        }

        [TestMethod()]
        public void CallsOverrideEquals()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };


            Assert.IsTrue(firstCall.Equals(lastCall));           
        }

        [TestMethod()]
        public void CallsHashCodeEquals()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };


            Assert.AreEqual(firstCall.GetHashCode(), lastCall.GetHashCode());
        }

        [TestMethod()]
        public void CallsIEquatableNotEquals()
        {
            IEquatable<PhoneCall> firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };


            Assert.IsFalse(firstCall.Equals(lastCall));
        }

        [TestMethod()]
        public void CallsIEquatableEquals()
        {
            IEquatable<PhoneCall> firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 20, 20, 300) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 19, 700) };


            Assert.IsTrue(firstCall.Equals(lastCall));
        }

        [TestMethod()]
        public void CallsCompareTo()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 21, 20, 300) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "CCCC", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 19, 700) };

            Assert.IsTrue(firstCall.CompareTo(lastCall) == 0);
        }

        [TestMethod()]
        public void CallsOperatorEqual()
        {
            var firstCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };


            Assert.IsTrue(firstCall == lastCall);
        }

        [TestMethod()]
        public void CallsOperatorNotEqual()
        {
            var firstCall = new PhoneCall() { From = "CCCC", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 120, StartTime = new DateTime(2000, 10, 5, 10, 20, 20) };
            var lastCall = new PhoneCall() { From = "AAAA", To = "BBBB", Caller = null, Direction = CallDirection.Incoming, Duration = 100, StartTime = new DateTime(2000, 10, 5, 10, 20, 0) };


            Assert.IsTrue(firstCall != lastCall);
        }

    }
}