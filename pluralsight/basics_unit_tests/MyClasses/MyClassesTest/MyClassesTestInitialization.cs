using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Summary description for MyClassesTestInitialization
    /// </summary>
    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            testContext.WriteLine("In the Assembly Initialize Method.");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            
        }
    }
}
