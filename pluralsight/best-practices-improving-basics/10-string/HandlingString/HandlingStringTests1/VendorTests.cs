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

        [TestMethod()]
        public void ProductCodeTest()
        {
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "ABC Corp-001";

            var actual = vendor.ProductCode;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void VendorCodeTest()
        {
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "ABC Corp-001";

            var actual = vendor.VendorCode;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";

            var actual = vendor.PlaceOrder(50);
            var expected = "Order from Acme\r\nProduct: rtgfh\r\nQuantity: 50\r\nInstructions: standard delivery";

            Assert.AreEqual(expected, actual);
        }
    }
}