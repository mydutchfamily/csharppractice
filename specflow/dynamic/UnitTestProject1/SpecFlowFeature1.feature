Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Create a new employee with mandatory details
	#Given I have opened my application
	#Then I should see employee details page
	When I fill all the mandatory details in form
		| Name    | Age | Phone      | Email            |
		| karthik | 28  | 9098023842 | krthik@email.com |

#And I click the save button
#Then I should see all the details saved in my application and DB

Scenario: Create several new employee with mandatory details
	#Given I have opened my application
	#Then I should see employee details page
	When I fill all the mandatory details in form for all employees
		| Name    | Age | Phone      | Email            |
		| karthik | 28  | 9098023842 | krthik@email.com |
		| John    | 30  | 2134234    | John@email.com   |
		| Sam     | 34  | 2345632    | Sam@email.com    |

   #And I click the save button
   #Then I should see all the details saved in my application and DB

Scenario Outline: Create several new employees with mandatory details
	#Given I have opened my application
	#Then I should see employee details page
	When I fill all the mandatory details in form <Name>, <Age> and <Phone>
	#And I click the save button
	#Then I should see all the details saved in my application and DB
	Examples:
		| Name    | Age | Phone      |
		| karthik | 28  | 9098023842 |
		| John    | 30  | 2134234    |
		| Sam     | 34  | 2345632    |

