using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandlingString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingString.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp";

            var actual = vendor.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PrepareDirectionsTest()
        {
            var vendor = new Vendor();
            var expceted = @"Insert \r\n to define a new line";

            var actual = vendor.PrepareDirections();
            Console.WriteLine(actual);

            Assert.AreEqual(expceted, actual);
        }
    }
}