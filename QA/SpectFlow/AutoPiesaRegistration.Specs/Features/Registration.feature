Feature: Create new account 

#1
Scenario: User should be able to create a new account using  valid data 
 Given the name "Dunca Cristina Andreea"
	And the email adress "dunca205@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed name error should be ""

#2
Scenario: Name Field is empty
  Given the name ""
	And the email adress "dunca205@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed name error should be "Camp obligatoriu "

#2*
Scenario: Name Field is whitespace
  Given the name "  "
	And the email adress "dunca205@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed name error should be "Camp obligatoriu Numele si prenumele trebuie sa aiba cel putin 5 caractere "

#2** FAIL
#Scenario: Name Field is only symbols
#  Given the name "")@$&*"
#	And the email adress "dunca205@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	When click on Continuare

#3
Scenario: Name Field is one character
  Given the name "a"
	And the email adress "dunca205@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed name error should be "Numele si prenumele trebuie sa aiba cel putin 5 caractere "

#4

Scenario: Email Field is empty
  Given the name "Dunca Cristina"
	And the email adress ""
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed email error should be "Camp obligatoriu "

#5
Scenario: Email provider and email domain are missing
  Given the name "Dunca Cristina"
	And the email adress "dunca204"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed email error should be "Adresa de email invalida "
	

#6
Scenario: Email domain is missing
  Given the name "Dunca Cristina"
	And the email adress "dunca205@gmail"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed email error should be "Adresa de email invalida "

#7
Scenario: Email has extra space at the end
  Given the name "Dunca Cristina"
	And the email adress "dunca205@abcdefghij.com "
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed email error should be "Adresa de email invalida "


##8 FAIL
#Scenario: Email provider indexistent and email domain existent
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@abcdefghij.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare

#
##9 FAIL
#Scenario: Email provider indexistent and inexistent email domain
#  Given the name "Dunca Cristina"
#	And the email adress "dunca205@alabalaportocala.blabla"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare

##9* FAIL
#Scenario: Email is longer than 1000 characters
#  Given the name "Dunca Cristina"
#	And the email adress "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina@gmail.com"
#	And the password "dunca205"
#	And the confirmation password "dunca205"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare

#9**
Scenario: Email name is only symbols
  Given the name "Dunca Cristina"
	And the email adress "!@$%^&*(@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed email error should be "Adresa de email invalida "
#
#10
Scenario: Email adress is already regisreed
  Given the name "Dunca Cristina"
	And the email adress "dunca205@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed email error should be "Adresa de email invalida "

#11
Scenario: Password and confirmation fields are empty
  Given the name "Dunca Cristina"
	And the email adress "dunca204@gmail.com"
	And the password ""
	And the confirmation password ""
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed password error should be "Camp obligatoriu "

#12
Scenario: Password and confirmation fields are shorter than 6 characters
  Given the name "Dunca Cristina"
	And the email adress "dunca204@gmail.com"
	And the password "dun"
	And the confirmation password "dun"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed password error should be "Parola trebuie sa aiba cel putin 6 caractere "

#13
Scenario:Password and confirmation fields are whitespace
  Given the name "Dunca Cristina"
	And the email adress "dunca204@gmail.com"
	And the password "      "
	And the confirmation password "      "
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
   Then the displayed password error should be "Camp obligatoriu "

#14
Scenario:Password is equal with the name
  Given the name "Dunca Cristina"
	And the email adress "dunca204@gmail.com"
	And the password "Dunca Cristina"
	And the confirmation password "Dunca Cristina"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
   Then the displayed password error should be "Parola nu poate fi asemanatoare cu numele "

##14* FAIL
#Scenario:Password and name have the same content, password is lowercase, name is uppercase
#  Given the name "DUNCA CRISTINA"
#	And the email adress "dunca204@gmail.com"
#	And the password "dunca cristina"
#	And the confirmation password "dunca cristina"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare

##14** FAIL
#Scenario: Password and confirmation fields are longer than 1000 characters
#  Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina"
#	And the confirmation password "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare
#
##15 FAIL
#Scenario: Password has one different letter from name 
# Given the name "Dunca Cristina"
#	And the email adress "dunca204@gmail.com"
#	And the password "Dunca Cristin"
#	And the confirmation password "Dunca Cristin"
#	And agree with personal data collector true
#	And agree with conditions and confindentiality policy true
#	#When click on Continuare

#16
Scenario: Confirmation password has one different letter from password
 Given the name "Dunca Cristina Andreea "
	And the email adress "dunca204@gmail.com"
	And the password "Dunca Cristina"
	And the confirmation password "Dunca Cristin"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
    Then the displayed confirmation password error should be "Parola nu este identica "

#16*
Scenario: Confirmation password is shorted and not identical with the password
 Given the name "Dunca Cristina Andreea "
	And the email adress "dunca204@gmail.com"
	And the password "Dunca Cristina"
	And the confirmation password "cris"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy true
	When click on Continuare
   Then the displayed confirmation password error should be "Parola nu este identica Parola trebuie sa aiba cel putin 6 caractere "

#17
Scenario: User does NOT agree with Personal Data Collector
 Given the name "Dunca Cristina"
	And the email adress "dunca204@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector false
	And agree with conditions and confindentiality policy true
	When click on Continuare
	Then the displayed disagreement error should be "Camp obligatoriu "

#18
Scenario: User does NOT agree with Conditions And Confindentiality Policy
 Given the name "Dunca Cristina"
	And the email adress "dunca204@gmail.com"
	And the password "dunca205"
	And the confirmation password "dunca205"
	And agree with personal data collector true
	And agree with conditions and confindentiality policy false
	When click on Continuare
    Then the displayed disagreement error should be "Camp obligatoriu "

##19
#Scenario: User should not be able to create an account using a SQL injection
#Given the name "Dunca Cristina"
#And the email ""'OR 1=1--"@gmail.com"
#And the password "dunca205"
#And the confirmation password "dunca205"
#And agree with personal data collector true
#And agree with conditions and confindentiality policy true
#When click on Continuare