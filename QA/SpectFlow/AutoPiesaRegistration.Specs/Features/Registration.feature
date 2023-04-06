#Feature: Create new account 
#
##1
#Scenario: User should be able to create a new account using  valid data 
# Given the name "Dunca Cristina Andreea"
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#	#Then the result should be 120
#
##2
#Scenario: Name Field is empty
#  Given the name ""
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##2*
#Scenario: Name Field is whitespace
#  Given the name "      "
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##2**
#Scenario: Name Field is only symbols
#  Given the name "")@#$&*"
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##3
#Scenario: Name Field is one character
#  Given the name "a"
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##4
#
#Scenario: Email Field is empty
#  Given the name "Dunca Cristina"
#	And the email adress ""
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##5
#Scenario: Email provider and email domain are missing
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##6
#Scenario: Email domain is missing
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@gmail"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##7
#Scenario: Email has extra space at the end
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@abcdefghij.com "
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
#
##8
#Scenario: Email provider indexistent and email domain existent
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@abcdefghij.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
#
##9
#Scenario: Email provider indexistent and inexistent email domain
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@alabalaportocala.blabla"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##9*
#Scenario: Email is longer than 1000 characters
#  Given the name "Dunca Cristina"
#	And the email adress "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##9**
#Scenario: Email name is only symbols
#  Given the name "Dunca Cristina"
#	And the email adress "!@#$%^&*(@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##10
#Scenario: Email adress is already regisreed
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##11
#Scenario: Password and confirmation fields are empty
#  Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password ""
#	And the confirmation password ""
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##12
#Scenario: Password and confirmation fields are shorter than 6 characters
#  Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "dun"
#	And the confirmation password "dun"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##13
#Scenario:Password and confirmation fields are whitespace
#  Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "      "
#	And the confirmation password "      "
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##14
#Scenario:Password is equal with the name
#  Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "Dunca Cristina"
#	And the confirmation password "Dunca Cristina"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##14*
#Scenario:Password and name have the same content, password is lowercase, name is uppercase
#  Given the name "DUNCA CRISTINA"
#	And the email adress "dunca204@gmail.com"
#	And the password "dunca cristina"
#	And the confirmation password "dunca cristina"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##14**
#Scenario: Password and confirmation fields are longer than 1000 characters
#  Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina"
#	And the confirmation password "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##15
#Scenario: Password has one different letter from name 
# Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "Dunca Cristin"
#	And the confirmation password "Dunca Cristin"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##16
#Scenario: Confirmation password has one different letter from password
# Given the name "Dunca Cristina Andreea "
#	And the email adress "dunca204@gmail.com"
#	And the password "Dunca Cristina"
#	And the confirmation password "Dunca Cristin"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##17
#Scenario: User does NOT agree with Personal Data Collector
# Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector false
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
##18
#Scenario: User does NOT agree with Conditions And Confindentiality Policy
# Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy false
#	#When click on Continuar