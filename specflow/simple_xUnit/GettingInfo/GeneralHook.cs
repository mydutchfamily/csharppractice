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
        private int stepnum = 0;

        public GeneralHook(ITestOutputHelper output)
        {
            this.output = output;
        }

        [AfterScenario]
        public void AfterScenario() {
            var featureTitle = FeatureContext.Current.FeatureInfo.Title;
            var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            var scenarioTag = ScenarioContext.Current.ScenarioInfo.Tags;
            //var stepInfo = ScenarioContext.Current.StepContext.StepInfo.Text; // not available before/after feature/scenario

            output.WriteLine($"FeatureTitle : {featureTitle} and ScenarioTitle = {scenarioTitle} with scenario tag: {String.Join(", ",scenarioTag)}");
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepInfo = ScenarioContext.Current.StepContext.StepInfo.Text; // not available before/after feature/scenario

            output.WriteLine($"Step info({stepnum++}): {stepInfo}");
        }
    }
}
