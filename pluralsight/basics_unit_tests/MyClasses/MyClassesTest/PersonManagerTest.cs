using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for PersonManagerTest
    /// </summary>
    [TestClass]
    public class PersonManagerTest
    {
        public PersonManagerTest()
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
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Paul", "Sheriff", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        public void GetEmployeeTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> per;

            per = mgr.GetEmployees();

            CollectionAssert.AllItemsAreInstancesOfType(per, typeof(Employee));
        }

        [TestMethod]

        public void DoEmployeesExistTest()
        {
            Supervisor supervisor = new Supervisor();

            supervisor.Employees = new List<Employee>();
            supervisor.Employees.Add(new Employee() {FirstName = "Jim", LastName = "Ruhl"});

            Assert.IsTrue(supervisor.Employees.Count > 0);
        }
    }
}
