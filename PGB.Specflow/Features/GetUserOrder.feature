Feature: GetUserOrder


Scenario: User can register a book order
	Given the user is not restricted
	When the user registers a book order
	Then the book order should be successfully processed