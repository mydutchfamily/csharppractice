Feature: UserForm
Feature which holds all the user details entry

#  by default xunit already running in parallel
#  run:
#  F:\ARB\GitHub\csharppractice\specflow\simple_xUnit\UnitTestProject2\packages\xunit.runner.console.2.4.1\tools\net452>xunit.console.exe F:\ARB\GitHub\csharppractice\specflow\simple_xUnit\ParallelRunning\bin\Debug\ParallelRunning.dll
#  xUnit.net Console Runner v2.4.1 (64-bit Desktop .NET 4.5.2, runtime: 4.0.30319.42000)
#    Discovering: ParallelRunning
#    Discovered:  ParallelRunning
#    Starting:    ParallelRunning
#  -> Using app.config
#  #8: Given I have navigate to application
#  #9: Given I navigate to application
#  ...
#    Finished:    ParallelRunning
#  === TEST EXECUTION SUMMARY ===
#     ParallelRunning  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 2,755s
#  
#  numbers #8 and #9 shows the numbers of threads
#  
#  update ...\ParallelRunning\Properties\AssemblyInfo.cs with [assembly: CollectionBehavior(MaxParallelThreads = 1, DisableTestParallelization = true)]
#  and it will run tests one by one (no #numbers):
#  xUnit.net Console Runner v2.4.1 (64-bit Desktop .NET 4.5.2, runtime: 4.0.30319.42000)
#    Discovering: ParallelRunning
#    Discovered:  ParallelRunning
#    Starting:    ParallelRunning
#  -> Using app.config
#  Given I navigate to application
#  -> done: UserFormSteps.GivenINavigateToApplication() (0,4s)
#  And I enter UserName and Password
#    --- table step argument ---
#    | UserName | Password |
#    | admin    | admin    |
#  -> done: LoginSteps.GivenIEnterUserNameAndPassword(<table>) (0,3s)
#    ...
#    Finished:    ParallelRunning
#  === TEST EXECUTION SUMMARY ===
#     ParallelRunning  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 3,689s


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
	And I verify the entered user form details in the application database
		| Initial | FirstName | MiddleName |
		| k       | Karthik   | k          |