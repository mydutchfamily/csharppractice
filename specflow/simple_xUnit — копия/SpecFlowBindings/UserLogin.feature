Feature: UserLogin
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@user
Scenario: Login for user portal
	Given I have opened the application
	And I login to application
	Then I see user portal

@user
Scenario: Login for user portal menu
	Given I have opened the application
	And I login to application as admin
	Then I see last date logged in data is 5 days from current date

@user
Scenario: Login for user portal menu using Dynamic Table conversion # need to install assist.dynamic v 1.3.1
	Given I have opened the application
	And I login to application as admin
	Then I see last date logged in data is 5 days from current date
	And I see the menu like
		| Menu_1 | Menu_2   | Menu_3 | Menu_4   |
		| Login0  | Settings0 | Logout0 | Advanced0 |
	And I see the menus like
		| Menu_1 | Menu_2   | Menu_3 | Menu_4   |
		| Login1  | Settings1 | Logout1 | Advanced1 |
		| Login2  | Settings2 | Logout2 | Advanced2 |
	And I see the menus like with transformation
		| Menu_1 | Menu_2   | Menu_3 | Menu_4   |
		| Login3  | Settings3 | Logout3 | Advanced3 |
		| Login4  | Settings4 | Logout4 | Advanced4 |