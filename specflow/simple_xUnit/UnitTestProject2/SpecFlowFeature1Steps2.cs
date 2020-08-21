using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace UnitTestProject2
{
    [Binding]
    public class SpecFlowFeature1Steps2
    {
        public readonly EmployeeDetails employee;
        private readonly ITestOutputHelper output;

        // seems can combine constructors
        // one for xUnit one for emp variable
        // emp will become Global for feature and by constructor will passed form another steps definitions - SpecFlowFeature1Steps
        public SpecFlowFeature1Steps2(ITestOutputHelper output, EmployeeDetails emp)
        {
            employee = emp;
            this.output = output;
        }

        [Then(@"I get the same value from extended steps")]
        public void ThenIGetTheSameValueFromExtendedSteps()
        {
            output.WriteLine("***********************");
            output.WriteLine(employee.Age.ToString());
            output.WriteLine(employee.Email);
            output.WriteLine(employee.Name);
            output.WriteLine(employee.Phone.ToString());
        }
    }
}