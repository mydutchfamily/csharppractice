﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BizTests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            var currentProduct = new Product();

            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void SayHello_ParameterizedConstructor()
        {
            var currentProduct = new Product("Saw", "15-inch steel blade hand saw", 1);

            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            var currentProduct = new Product {// in did default constructor will be used and parameters set, no need in custom constructor
               ProductName = "Saw",
                Description = "15-inch steel blade hand saw",
                ProductId = 1
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void Product_Null()
        {
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            Assert.AreEqual(expected, companyName);
        }

    }
}