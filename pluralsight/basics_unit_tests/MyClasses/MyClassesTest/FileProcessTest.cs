using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        //private const string fileLocation = "C:\\csharp\\code\\pluralsight\\basics_unit_tests\\MyClasses\\MyClassesTest\\FileExist.txt";
        private string fileLocation = "F:\\ARB\\GitHub\\csharppractice\\pluralsight\\basics_unit_tests\\MyClasses\\MyClassesTest\\FileExist.txt";

        private const string BAD_FILE_NAME = "F:\\FileNotExist.txt";

        private string _GoodFileName;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            testContext.WriteLine("In the Class Initialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName == "CreateFileNameDoesExist")
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File: "+ _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Text from TestInitialize");
                }

            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "CreateFileNameDoesExist")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting File: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }

        public TestContext TestContext{ get; set; }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]")) {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        [Owner("Vova")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore()]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(fileLocation);

            Assert.IsTrue(fromCall);

        }

        [TestMethod]
        [Timeout(3000)] //wait for 3 sec and fail the test
        public void SimulateTimeoutTest()
        {
            System.Threading.Thread.Sleep(4000);
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Egor")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fileProcess = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
                       TestContext.WriteLine("Checking file:" + fileName);

            fromCall = fileProcess.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Alex")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void CreateFileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            //SetGoodFileName();
            //TestContext.WriteLine("Creating the file" + _GoodFileName);
            //File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine("Testing the file" + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            //TestContext.WriteLine("Deleting the file" + _GoodFileName);
            //File.Delete(_GoodFileName);

            Assert.IsTrue(fromCall);

        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
            //Assert.Inconclusive();
        }

        [TestMethod]
        [Priority(2)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Priority(2)]
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
