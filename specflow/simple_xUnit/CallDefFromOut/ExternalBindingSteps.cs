using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace CallDefFromOut
{
    [Binding]
    public class ExternalBindingSteps
    {

        private readonly ITestOutputHelper output;

        public ExternalBindingSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [When(@"I press add button")]
        public void WhenIPressAddButton()
        {
            output.WriteLine("Add button pressed locally");
        }

    }
}
