using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace ParallelRunning.Steps
{
    [Binding]
    public class LoginSteps
    {

        private readonly ITestOutputHelper output;

        public LoginSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I have navigate to application")]
        public void GivenIHaveNavigateToApplication()
        {
            output.WriteLine("GivenIHaveNavigateToApplication ");
        }
        
        [Given(@"I enter UserName and Password")]
        public void GivenIEnterUserNameAndPassword(Table table)
        {
            output.WriteLine("GivenIEnterUserNameAndPassword ");
        }
        
        [Then(@"I click login")]
        public void ThenIClickLogin()
        {
            output.WriteLine("ThenIClickLogin ");
        }
        
        [Then(@"I should see user logged into application")]
        public void ThenIShouldSeeUserLoggedIntoApplication()
        {
            output.WriteLine("ThenIShouldSeeUserLoggedIntoApplication ");
        }
    }
}
