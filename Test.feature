Feature: Test
	As user
	I want to be sure in correctness of search results

Background: 
	Given user navigates to test website

Scenario: Checking correct behavor on empty input
	When user searches '' information
	Then user checks his location on main page

Scenario Outline: Checking correct behavor on non-empty input
	When user searches '<Input>' information
	Then user checks successful search process
	Then user checks default position of radiobutton is 'по слову'
	Then user checks presence of '<Input>' in search title
	Then user checks correctness of sum of results in search title
	

Examples: 
	| Input |
	| 1     |
	| лист  |
	| дфс   |