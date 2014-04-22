Feature: Customer Withdraws Cash
	In order to avoid waiting in line,
	As a Bank Customer,
	I should be able to withdraw cash from an ATM


Scenario: Account is in Credit
	Given the account is in credit
	And the dispenser contains cash
	When the customer requests cash
	Then ensure the account is debited
	And the cash is dispensed