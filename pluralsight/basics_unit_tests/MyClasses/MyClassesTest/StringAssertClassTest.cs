using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for StringAssertClassTest
    /// </summary>
    [TestClass]
    public class StringAssertClassTest
    {
        public StringAssertClassTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "John Kuhn";
            string str2 = "Kuhn";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartWithTest()
        {
            string str1 = "All Lower Case";
            string str2 = "All Lower";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All Lower Case", r);
        }
    }
}
