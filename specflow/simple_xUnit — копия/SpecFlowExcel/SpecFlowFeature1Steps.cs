using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit.Abstractions;

namespace SpecFlowExcel
{
    [Binding]
    public class SpecFlowFeature1Steps: Steps // needed to use Given();
    {

        private readonly ITestOutputHelper output;

        public SpecFlowFeature1Steps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I login to application")]
        public void GivenILoginToApplication(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            output.WriteLine($"UserName: {data.UserName}, Password: {data.Password}");

        }

        [Given(@"I enter following details")]
        public void GivenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            output.WriteLine($"Title: {data.Title}, Initial: {data.Initial}, FirstName: {data.FirstName}");
        }

        [Given(@"I login and enter user details")]
        public void GivenILoginAndEnterUserDetails()
        {
            //prepare data
            string[] colHeader = { "UserName", "Password" };
            string[] row = {"admin", "admin" };
            //create table
            var table = new Table(colHeader);
            table.AddRow(row);

            Given("I login to application", table);//call step, Step class provide this method

            string[] colHeaderUF = { "Title", "Initial", "FirstName" };
            string[] rowUF = { "MMr", "KK", "Karthik" };
            //create table
            table = new Table(colHeaderUF);
            table.AddRow(rowUF);

            Given("I enter following details", table);

        }

        [Then(@"I click save button")]
        public void ThenIClickSaveButton()
        {
            output.WriteLine("ThenIClickSaveButton");
        }

    }
}
