Feature: Login


Scenario: Valid data
	Given the email "dunca205@gmail.com"
	And password "dunca205"
	When click on Autentificare
	Then the URL should change true

Scenario: Login with unregistred email 
	Given the email "dunca200@gmail.com"
	And password "dunca205"
	When click on Autentificare
	Then the URL should change false

Scenario: Email adress in UPPER case should  be treated as valid
	Given the email "DUNCA205@gmail.com"
	And password "dunca205"
	When click on Autentificare
	Then the URL should change true

Scenario: Email adress with different domain should NOT be treated as valid
	Given the email "dunca205@gmail.ro"
	And password "dunca205"
	When click on Autentificare
	Then the URL should change false

Scenario: Email adress with different provider should NOT be treated as valid
	Given the email "dunca205@yahoo.com"
	And password "dunca205"
	When click on Autentificare
	Then the URL should change false

Scenario: Email in UPPER case and password UPPER case
     Given the email "DUNCA205@gmail.com"
	And password "DUNCA205"
	When click on Autentificare
	Then the URL should change false

Scenario: Valid email invalid password
     Given the email "dunca205@gmail.com"
	And password "cristina"
	When click on Autentificare
	Then the URL should change false

Scenario: Valid email password in Japanese
     Given the email "dunca205@gmail.com"
	And password "ドンカ"
	When click on Autentificare
	Then the URL should change false

Scenario: Valid email password has just one different letter from the valid password
     Given the email "dunca205@gmail.com"
	And password "dunca20"
	When click on Autentificare
	Then the URL should change false

Scenario: Valid email password has one extra space at the end
     Given the email "dunca205@gmail.com"
	And password "dunca205 "
	When click on Autentificare
	Then the URL should change false

Scenario: Valid email password has one letter replaced with space
     Given the email "dunca205@gmail.com"
	And password "dunc 205"
	When click on Autentificare
	Then the URL should change false
