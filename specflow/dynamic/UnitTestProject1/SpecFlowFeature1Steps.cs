using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit.Abstractions;

namespace UnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private readonly ITestOutputHelper output;

        public SpecFlowFeature1Steps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            output.WriteLine($"entered number: {number}");
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            output.WriteLine("Add button pressed");
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int res)
        {
            if (res == 120)
                output.WriteLine("Test passed");
            else
            {
                output.WriteLine("Test failed");
                throw new Exception("Test failed");
            }
        }

        [When(@"I fill all the mandatory details in form")]
        public void WhenIFillAllTheMandatoryDetailsInForm(Table table)
        {
            EmployeeDetails empdetDetails = table.CreateInstance<EmployeeDetails>();

            output.WriteLine(empdetDetails.Age.ToString());
            output.WriteLine(empdetDetails.Email);
            output.WriteLine(empdetDetails.Name);
            output.WriteLine(empdetDetails.Phone.ToString());
        }

        [When(@"I fill all the mandatory details in form for all employees")]
        public void WhenIFillAllTheMandatoryDetailsInFormForAllEmployees(Table table)
        {
            var empdetDetails = table.CreateSet<EmployeeDetails>();

            foreach (var employee in empdetDetails)
            {
                output.WriteLine(employee.Age.ToString());
                output.WriteLine(employee.Email);
                output.WriteLine(employee.Name);
                output.WriteLine(employee.Phone.ToString());
            }
        }

        [When(@"I fill all the mandatory details in form (.*), (.*) and (.*)")]
        public void WhenIFillAllTheMandatoryDetailsInFormAnd(string name, int age, Int64 phoneNum)
        {
            output.WriteLine($"Name {name}, age {age}, phone number {phoneNum}");

            ScenarioContext.Current["InfoforNextStep"] = "Step1 Passed";
            output.WriteLine($"ScenarioContext.Current[\"InfoforNextStep\"]: {ScenarioContext.Current["InfoforNextStep"]}");

            List<EmployeeDetails> emps = new List<EmployeeDetails>()
            {
                new EmployeeDetails(){Name = "Abraham", Age = 20, Email = "Abraham@email.com", Phone = 123456},
                new EmployeeDetails(){Name = "Mike", Age =20, Email = "Mike@email.com", Phone = 654321},
                new EmployeeDetails(){Name = "Jacob", Age =33, Email = "Jacob@email.com", Phone = 123654}
            };

            //save
            ScenarioContext.Current.Add("empDetails", emps);

            //get
            var empList = ScenarioContext.Current.Get<List<EmployeeDetails>>("empDetails");

            foreach (var emp in empList)
            {
                output.WriteLine($"Name {emp.Name}, age {emp.Age}, phone number {emp.Phone} and email {emp.Email}");
            }

            output.WriteLine(ScenarioContext.Current.ScenarioInfo.Title);
            output.WriteLine(ScenarioContext.Current.CurrentScenarioBlock.ToString());

        }


    }
}
