using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace GettingInfo
{
    [Binding]
    public class LoginSteps
    {
        private readonly ITestOutputHelper output;

        public LoginSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I have navigate to the application")]
        public void GivenIHaveNavigateToTheApplication()
        {
            output.WriteLine("GivenIHaveNavigateToTheApplication");
        }
        
        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            output.WriteLine("GivenISeeApplicationOpened");
        }
        
        [When(@"I enter UserName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            output.WriteLine("WhenIEnterUserNameAndPassword");
        }
        
        [Then(@"I click login link")]
        public void ThenIClickLoginLink()
        {
            output.WriteLine("ThenIClickLoginLink");
        }
        
        [Then(@"I click login button")]
        public void ThenIClickLoginButton()
        {
            output.WriteLine("ThenIClickLoginButton");
        }
        
        [Then(@"I should see the username with hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            output.WriteLine("ThenIShouldSeeTheUsernameWithHello");
        }
        
        [Then(@"I click logout")]
        public void ThenIClickLogout()
        {
            output.WriteLine("ThenIClickLogout");
        }
    }
}
