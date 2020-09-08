using OpenQA.Selenium.Winium;
using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace WiniumSpecflow
{
    [Binding]
    public class SpecFlowFeature1Steps
    {

        DesktopOptions options = new DesktopOptions();
        WiniumDriver driver;

        private readonly ITestOutputHelper output;

        public SpecFlowFeature1Steps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"Notepad application is open")]
        public void GivenNotepadApplicationIsOpen()
        {
            options.ApplicationPath = "C:\\Windows\\System32\\notepad.exe";
            driver = new WiniumDriver(@"F:\ARB\GitHub\csharppractice\specflow\automate_win_app\winium\Winium.Desktop.Driver", options);
        }
        
        [When(@"I enter the text ""(.*)""")]
        public void WhenIEnterTheText(string txt)
        {
            driver.FindElementByClassName("Edit").SendKeys(txt);
        }
        
        [When(@"Press close button")]
        public void WhenPressCloseButton()
        {
            driver.FindElementById("Close").Click();
        }
        
        [When(@"Press button close without saving")]
        public void WhenPressButtonCloseWithoutSaving()
        {
            driver.FindElementById("CommandButton_7").Click();
        }
        
        [Then(@"Notepad application closed")]
        public void ThenNotepadApplicationClosed()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
