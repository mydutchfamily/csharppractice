Feature: ExternalBinding
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

# Add into App.config file: 
#  <specFlow>
#    <stepAssemblies>
#      <stepAssembly assembly="UnitTestProject2"/>  // assembly name of the project    
#    </stepAssemblies>    
#  </specFlow>
#
#
#  copy "..\solution\UnitTestProject2\bin\Debug\UnitTestProject2.dll" to "...\solution\CallDefFromOut\bin\Debug"

# except step "When I press add button" the rest will be taken from dll

@mytag
Scenario: Add two numbers externally
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add button
	Then the result should be 120 on the screen