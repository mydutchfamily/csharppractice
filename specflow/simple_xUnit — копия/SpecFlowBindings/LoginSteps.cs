using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace SpecFlowBindings
{
    [Binding]
    public class LoginSteps
    {

        private readonly ITestOutputHelper output;

        public LoginSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I have opened the application")]
        public void GivenIHaveOpenedTheApplication()
        {
            output.WriteLine("I have opened the application - LoginSteps.cs");
        }
        
        //there are two feature with the same step definite in two files
        [Given(@"I login to application")]
        //[Scope(Feature = "LoginFeature")]
        [Scope(Scenario = "Login for customer portal")]
        public void GivenILoginToApplication()
        {
            output.WriteLine("I login to application - LoginSteps.cs");
        }

        [Then(@"I see user portal")]
        public void ThenISeeUserPortal()
        {
            output.WriteLine("I see user portal - LoginSteps.cs");
        }

        [Then(@"I see customer portal")]
        public void ThenISeeCustomerPortal()
        {
            output.WriteLine("I see customer portal - LoginSteps.cs");
        }

    }
}
