using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit.Abstractions;

namespace ParallelRunning.Steps
{
    [Binding]
    public class UserFormSteps
    {
        private readonly ITestOutputHelper output;

        public UserFormSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            output.WriteLine("GivenINavigateToApplication ");
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            output.WriteLine("GivenIClickLogin ");
        }

        [Given(@"I start entering user form details like")]
        public void GivenIStartEnteringUserFormDetailsLike(Table table)
        {
            output.WriteLine("GivenIStartEnteringUserFormDetailsLike ");
        }

        [Given(@"I click submit button")]
        public void GivenIClickSubmitButton()
        {
            output.WriteLine("GivenIClickSubmitButton ");
        }

        [Given(@"I verify the entered user form details in the application database")]
        public void GivenIVerifyTheEnteredUserFormDetailsInTheApplicationDatabase(Table table)
        {
            //Mock data
            List<AUTDatabase> mockAUTData = new List<AUTDatabase>()
            {
                new AUTDatabase() {
                    FirstName = "Karthik",
                    Initial = "k",
                    MiddleName = "k"
                }
            };

            var result = table.FindInSet(mockAUTData);

            //Mock data
            mockAUTData = new List<AUTDatabase>()
            {
                new AUTDatabase() {
                    FirstName = "Karthik",
                    Initial = "k",
                    MiddleName = "k"
                },
                new AUTDatabase() {
                    FirstName = "Prashanth",
                    Initial = "k",
                    MiddleName = "k"
                }
            };

            var resultAll = table.FindAllInSet(mockAUTData);// will return matching rows
        }

    }

    public class AUTDatabase
    {
        public string Initial { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }
    }
}
