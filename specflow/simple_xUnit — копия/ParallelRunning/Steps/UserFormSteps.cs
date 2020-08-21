using System;
using TechTalk.SpecFlow;
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
    }
}
