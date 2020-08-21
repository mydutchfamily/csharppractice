using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace GettingInfo
{
    [Binding]
    public class GeneralHook
    {

        private readonly ITestOutputHelper output;

        public GeneralHook(ITestOutputHelper output)
        {
            this.output = output;
        }

        [AfterScenario]
        public void AfterScenario() {
            var featureTitle = FeatureContext.Current.FeatureInfo.Title;
            var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;

            output.WriteLine($"FeatureTitle : {featureTitle} and ScenarioTitle = {scenarioTitle}");
        }
    }
}
