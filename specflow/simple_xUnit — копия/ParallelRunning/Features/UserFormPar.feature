Feature: UserForm
Feature which holds all the user details entry

@mytag
Scenario: User Details form entry verification
	Given I navigate to application
	And I enter UserName and Password
		| UserName | Password |
		| admin    | admin    |
	And I click login
	And I start entering user form details like
		| Initial | FirstName | MiddleName |
		| k       | Karthik   | k          |
	And I click submit button