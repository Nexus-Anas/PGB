Feature: GetReturnedUserBooks


Scenario: User can return the books he ordered
	Given the user is not restricted
	When the user return books
	Then the returned books operation should be successfully processed