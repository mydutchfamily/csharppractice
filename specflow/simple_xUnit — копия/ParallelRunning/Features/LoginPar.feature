Feature: Login
	Check if login functionality works

@smoke @positive
Scenario: Login user as Administrator
	Given I have navigate to application
	And I enter UserName and Password
		| UserName | Password |
		| admin    | admin |
	Then I click login
	Then I should see user logged into application