Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Enter text to Notepad
	Given Notepad application is open
	When I enter the text "Hello winium!"
	And Press close button
	And Press button close without saving
	Then Notepad application closed