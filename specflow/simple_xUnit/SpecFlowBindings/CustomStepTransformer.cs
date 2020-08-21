using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace SpecFlowBindings
{
    [Binding]
    public class CustomStepTransformer
    {

        private readonly ITestOutputHelper output;

        public CustomStepTransformer(ITestOutputHelper output)
        {
            this.output = output;
        }

        //this method will transform date for ThenISeeLastDateLoggedInDataIsDaysFromCurrentDate step as input parameter
        [StepArgumentTransformation(@"(\d+) days from current date")]
        public DateTime DayAdderTransformer(int days)
        {
            output.WriteLine("DayAdderTransformer executed");
            return DateTime.Today.AddDays(days);
        }
    }
}
