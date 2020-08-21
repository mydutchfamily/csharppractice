﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowBindings
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserLoginFeature : Xunit.IClassFixture<UserLoginFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UserLogin.feature"
#line hidden
        
        public UserLoginFeature(UserLoginFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UserLogin", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Login for user portal")]
        [Xunit.TraitAttribute("FeatureTitle", "UserLogin")]
        [Xunit.TraitAttribute("Description", "Login for user portal")]
        [Xunit.TraitAttribute("Category", "user")]
        public virtual void LoginForUserPortal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login for user portal", null, new string[] {
                        "user"});
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Given("I have opened the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I login to application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Then("I see user portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Login for user portal menu")]
        [Xunit.TraitAttribute("FeatureTitle", "UserLogin")]
        [Xunit.TraitAttribute("Description", "Login for user portal menu")]
        [Xunit.TraitAttribute("Category", "user")]
        public virtual void LoginForUserPortalMenu()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login for user portal menu", null, new string[] {
                        "user"});
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 14
 testRunner.Given("I have opened the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I login to application as admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("I see last date logged in data is 5 days from current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Login for user portal menu using Dynamic Table conversion # need to install assis" +
            "t.dynamic v 1.3.1")]
        [Xunit.TraitAttribute("FeatureTitle", "UserLogin")]
        [Xunit.TraitAttribute("Description", "Login for user portal menu using Dynamic Table conversion # need to install assis" +
            "t.dynamic v 1.3.1")]
        [Xunit.TraitAttribute("Category", "user")]
        public virtual void LoginForUserPortalMenuUsingDynamicTableConversionNeedToInstallAssist_DynamicV1_3_1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login for user portal menu using Dynamic Table conversion # need to install assis" +
                    "t.dynamic v 1.3.1", null, new string[] {
                        "user"});
#line 19
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 20
 testRunner.Given("I have opened the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("I login to application as admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("I see last date logged in data is 5 days from current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Menu_1",
                        "Menu_2",
                        "Menu_3",
                        "Menu_4"});
            table1.AddRow(new string[] {
                        "Login0",
                        "Settings0",
                        "Logout0",
                        "Advanced0"});
#line 23
 testRunner.And("I see the menu like", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Menu_1",
                        "Menu_2",
                        "Menu_3",
                        "Menu_4"});
            table2.AddRow(new string[] {
                        "Login1",
                        "Settings1",
                        "Logout1",
                        "Advanced1"});
            table2.AddRow(new string[] {
                        "Login2",
                        "Settings2",
                        "Logout2",
                        "Advanced2"});
#line 26
 testRunner.And("I see the menus like", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Menu_1",
                        "Menu_2",
                        "Menu_3",
                        "Menu_4"});
            table3.AddRow(new string[] {
                        "Login3",
                        "Settings3",
                        "Logout3",
                        "Advanced3"});
            table3.AddRow(new string[] {
                        "Login4",
                        "Settings4",
                        "Logout4",
                        "Advanced4"});
#line 30
 testRunner.And("I see the menus like with transformation", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                UserLoginFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UserLoginFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
