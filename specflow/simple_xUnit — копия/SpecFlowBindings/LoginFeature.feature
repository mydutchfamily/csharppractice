Feature: LoginFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@customer
Scenario: Login for customer portal
	Given I have opened the application
	And I login to application
	Then I see customer portal

