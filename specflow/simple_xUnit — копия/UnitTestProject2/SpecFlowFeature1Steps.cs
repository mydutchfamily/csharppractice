using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit.Abstractions;

namespace UnitTestProject2
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        public readonly EmployeeDetails employee;
        private readonly ITestOutputHelper output;

        //public SpecFlowFeature1Steps(ITestOutputHelper output)
        //{
        //    this.output = output;
        //}

        //public SpecFlowFeature1Steps(EmployeeDetails emp)
        //{
        //    this.employee = emp;
        //}

        // seems can combine constructors
        // one for xUnit one for emp variable
        // emp will become Global for feature and by constructor will passed to another steps definitions - SpecFlowFeature1Steps2
        public SpecFlowFeature1Steps(ITestOutputHelper output, EmployeeDetails emp)
        {
            employee = emp;
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
            var empdetDetails = table.CreateInstance<EmployeeDetails>();

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
        public void WhenIFillAllTheMandatoryDetailsInFormAnd(string name, int age, long phoneNum)
        {
            output.WriteLine($"Name {name}, age {age}, phone number {phoneNum}");

            ScenarioContext.Current["InfoforNextStep"] = "Step1 Passed";
            output.WriteLine(
                $"ScenarioContext.Current[\"InfoforNextStep\"]: {ScenarioContext.Current["InfoforNextStep"]}");

            var emps = new List<EmployeeDetails>
            {
                new EmployeeDetails {Name = "Abraham", Age = 20, Email = "Abraham@email.com", Phone = 123456},
                new EmployeeDetails {Name = "Mike", Age = 20, Email = "Mike@email.com", Phone = 654321},
                new EmployeeDetails {Name = "Jacob", Age = 33, Email = "Jacob@email.com", Phone = 123654}
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

        [When(@"I fill all the mandatory details in form for all employees with SpecFlow\.Assist\.Dynamic")]
        public void WhenIFillAllTheMandatoryDetailsInFormForAllEmployeesWithSpecFlow_Assist_Dynamic(Table table)
        {
            var details = table.CreateDynamicSet();

            foreach (var employee in details)
            {
                output.WriteLine("***********************");
                output.WriteLine(employee.Age.ToString());
                output.WriteLine(employee.Email);
                output.WriteLine(employee.Name);
                output.WriteLine(employee.Phone.ToString());
            }
        }

        [When(@"I fill all the mandatory details in form for employee")]
        public void WhenIFillAllTheMandatoryDetailsInFormForEmployee(Table table)
        {
            var details = table.CreateDynamicSet();

            foreach (var emp in details)
            {
                employee.Age = emp.Age;
                employee.Email = emp.Email;
                employee.Name = emp.Name;
                employee.Phone = (long) emp.Phone;
            }
        }
    }
}