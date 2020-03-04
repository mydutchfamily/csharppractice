using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            //FileProcess fp = new FileProcess();
            //bool fromCall;

            //fromCall = fp.FileExists("F:\\ARB\\GitHub\\csharppractice\\pluralsight\\basics_unit_tests\\MyClasses\\MyClassesTest\\FileExist.txt");

            //Assert.IsTrue(fromCall);
            Assert.Inconclusive();
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //FileProcess fp = new FileProcess();
            //bool fromCall;

            //fromCall = fp.FileExists("F:\\ARB\\GitHub\\csharppractice\\pluralsight\\basics_unit_tests\\MyClasses\\MyClassesTest\\FileNotExist.txt");

            //Assert.IsFalse(fromCall);
            Assert.Inconclusive();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();


            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException e)
            {
                return;
            }

            Assert.Fail("Call to FileExist did not throw an exception");
        }
    }
}
