Feature: APITests

A short summary of the feature

@tag1 @API
Scenario Outline: Check a single user
	When I request user number <usernumber>
	Then I get a 200 response code
	And the user is '<username>'

	Examples: 
	| usernum | username   |
	| 2       | Jane Smith |
	| 1       | Bob Jones  |