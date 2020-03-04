using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string fileLocation = "C:\\csharp\\code\\pluralsight\\basics_unit_tests\\MyClasses\\MyClassesTest\\FileExist.txt";
        //private string fileLocation = "F:\\ARB\\GitHub\\csharppractice\\pluralsight\\basics_unit_tests\\MyClasses\\MyClassesTest\\FileExist.txt";

        private const string BAD_FILE_NAME = "F:\\FileNotExist.txt";

        private string _GoodFileName;

        public TestContext TestContext{ get; set; }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]")) {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(fileLocation);

            Assert.IsTrue(fromCall);

        }

        [TestMethod]
        public void CreateFileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();
            TestContext.WriteLine("Creating the file" + _GoodFileName);
            File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine("Testing the file" + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            TestContext.WriteLine("Deleting the file" + _GoodFileName);
            File.Delete(_GoodFileName);

            Assert.IsTrue(fromCall);

        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
            //Assert.Inconclusive();
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
