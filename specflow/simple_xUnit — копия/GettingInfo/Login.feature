Feature: Login
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@smoke @positive
Scenario: Check Login with correct username and password
	Given I have navigate to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password
		| UserName | Password |
		| admin    | password |
	Then I click login button
	Then I should see the username with hello
	Then I click logout