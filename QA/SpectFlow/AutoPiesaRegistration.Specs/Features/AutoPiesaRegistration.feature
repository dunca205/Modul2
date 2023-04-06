Feature: AutoPiesaRegistration

@mytag
Scenario: Registration using valid data
	Given the name Dunca Cristina Andreea
	And the email adress dunca205@gmail.com
	And the password dunca205
	And the confirmation password dunca205
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	#Then the result should be 120