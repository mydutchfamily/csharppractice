using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit.Abstractions;

namespace SpecFlowBindings
{
    [Binding]
    public sealed class UserLoginSteps
    {

        private readonly ITestOutputHelper output;

        public UserLoginSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        //there are two feature with the same step definite in two files
        [Given(@"I login to application")]
        //[Scope(Feature = "UserLogin")]
        [Scope(Tag = "user")]
        public void GivenILoginToApplication()
        {
            output.WriteLine("I login to application - UserLoginSteps.cs");
        }

        [Given(@"I login to application as admin")]
        public void GivenILoginToApplicationAsAdmin()
        {
            output.WriteLine("logged in as admin");
        }

        [Then(@"I see last date logged in data is (.* days from current date)")]
        public void ThenISeeLastDateLoggedInDataIsDaysFromCurrentDate(DateTime correctdate)//(int p0) input without DayAdderTransformer
        {
            //var correctdate = DateTime.Today.AddDays(p0); // no need to do it , as it will be done by CustomStepTransformer.DayAdderTransformer
            output.WriteLine(correctdate.ToString());
        }

        [Then(@"I see the menu like")]
        public void ThenISeeTheMenuLike(Table menus)
        {
            //need to install assist.dynamic v 1.3.1
            dynamic menu = menus.CreateDynamicInstance();

            string menu1 = menu.Menu_1;//as variable is dynamic ALL fields name are unknown
            string menu2 = menu.Menu_2;

            output.WriteLine($"the value of Menu1 is {menu1} and Menu2 is {menu2}");
        }

        [Then(@"I see the menus like")]
        public void ThenISeeTheMenusLike(Table table)
        {
            IEnumerable<dynamic> menus = table.CreateDynamicSet();

            var menu = menus.First();

            string menu1 = menu.Menu_1;//as variable is dynamic ALL fields name are unknown
            string menu2 = menu.Menu_2;

            output.WriteLine($"one of the value of Menus1 is {menu1} and Menus2 is {menu2}");
        }

        [Then(@"I see the menus like with transformation")]
        public void ThenISeeTheMenusLikeWithTransformation(IEnumerable<dynamic> menus)//this transformation is automagical
        {
            var menu = menus.First();

            string menu1 = menu.Menu_1;//as variable is dynamic ALL fields name are unknown
            string menu2 = menu.Menu_2;

            output.WriteLine($"step transformation - one of the value of Menus1 is {menu1} and Menus2 is {menu2}");
        }


    }
}
