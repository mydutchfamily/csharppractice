using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace UnitTestProject2
{
    [Binding]
    public class SpecFlowHooks
    {
        private readonly ITestOutputHelper output;

        public SpecFlowHooks(ITestOutputHelper output)
        {
            this.output = output;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("~~~~~~~ calling BeforeFeature");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Debug.WriteLine("~~~~~~~ calling AfterFeature");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            output.WriteLine("~~~~~~~ calling BeforeScenario");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            output.WriteLine("~~~~~~~ calling AfterScenario");
        }
    }
}