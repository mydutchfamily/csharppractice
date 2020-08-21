Feature: SpecFlowFeature1
	Testing the multiline step reusability

@mytag
Scenario: Enter user details in userform
	Given I login to application
		| UserName | Password |
		| admin    | admin    |
	And I enter following details
		| Title | Initial | FirstName |
		| Mr.   | K       | Karthik   |

Scenario: Enter user details in UserForm in 2 lines
	Given I login and enter user details
	Then I click save button