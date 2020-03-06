using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for AssertClassTest
    /// </summary>
    [TestClass]
    public class AssertClassTest
    {
        public AssertClassTest()
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
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]// expected that test will fail
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Paul";
            string str2 = "paul";

            Assert.AreEqual(str1, str2, false);// ignore case?
        }

        [TestMethod]
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "John";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x= new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x,y);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Paul", "Sheriff", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Sheriff", true);

            Assert.IsNull(per);
        }
    }
}
