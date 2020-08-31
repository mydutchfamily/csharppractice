Feature: Login
	Check if login functionality works

# To run only scenarios marked by specified tag in console execute:
# ...\solution_Folder\project_folder\packages\xunit.runner.console.2.4.1\tools\net452>xunit.console.exe ...\solution_Folder\project_folder\bin\Debug\projectName.dll -trait "Category=tagName"

@smoke @positive
Scenario: Login user as Administrator
	Given I have navigate to application
	And I enter UserName and Password
		| UserName | Password |
		| admin    | admin |
	Then I click login
	Then I should see user logged into application