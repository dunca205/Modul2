using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    public class Auto_PiesaFacts
    {
        [Fact]////#1
        public void CreateNewAccount_ValidData()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");

            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            Assert.Equal("https://www.auto-piesa.ro/login", driver.Url);

            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();
            Assert.Equal("https://www.auto-piesa.ro/cont-nou", driver.Url);

            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");
            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dunca205");
            var passwordConfirm = driver.FindElement(By.Name("user_password_confirm"));
            passwordConfirm.SendKeys("dunca205");

            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();
            driver.Close();

        }

        [Fact]////#2
        public static void CreateNewAccount_NameFieldIsEmpty()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();


            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys(string.Empty);
            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dunca205");
            var passwordConfirm = driver.FindElement(By.Name("user_password_confirm"));
            passwordConfirm.SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var nameFieldIsEmptyError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[1]"));
            Assert.True(nameFieldIsEmptyError.Displayed);
            driver.Close();
        }

        [Fact]////#3
        public void CreateNewAccount_NameIsShorterThanExpected()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();


            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("a");
            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dunca205");
            var passwordConfirm = driver.FindElement(By.Name("user_password_confirm"));
            passwordConfirm.SendKeys("dunca205");

            var personalDataCollectorAgreement = driver.FindElement(By.Name("user_gdpr_formular"));
            personalDataCollectorAgreement.Click();
            var termsConditionsAndConfidentialityPolicyAgreement = driver.FindElement(By.Name("user_gdpr"));
            termsConditionsAndConfidentialityPolicyAgreement.Click();

            var continueButton = driver.FindElement(By.Name("submitContNou"));
            continueButton.Click();
            var nameFieldIsTooShortError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[2]"));


            Assert.True(nameFieldIsTooShortError.Displayed);
            driver.Close();
        }

        [Fact]////#4
        public void CreateNewAccount_EmailEmpty()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();


            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("");

            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/div/input"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        [Fact] ////#5
        public void CreateNewAccount_InvalidEmail_MissingEmailProvider()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        [Fact] ////#6
        public void CreateNewAccount_InvalidEmail_ValidEmailProvider_MissingEmailDomain()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca204@gmail");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        [Fact] ////#7
        public void CreateNewAccount_ValidEmailHavingExtraWhiteSpaceAtTheEnd()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");
            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@gmail.com ");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        //   [Fact]//// #8
        public void CreateNewAccount_InvalidEmail_InexistentEmailProvider_ExistentEmailDomain() //// fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");
            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@abcdefghij.com");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        //  [Fact] ////#9
        public void CreateNewAccount_InvalidEmail_InvalidEmailProvider_InexistenEmailDomain() //// fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@alabalaportocala.blabla");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();


            var missingEmailProviderErrorMessage = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(missingEmailProviderErrorMessage.Displayed);
            driver.Close();

        }

        //  [Fact] //#9*
        public void CreateNewAccount_UsingAVeryLongEmailAdress() // fail, it works
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina@gmail.com");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();


            var missingEmailProviderErrorMessage = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(missingEmailProviderErrorMessage.Displayed);
            driver.Close();

        }


        // [Fact] ////#10
        public void CreateNewAccount_EmailIsAlreadyRegistred()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea");
            driver.FindElement(By.Name("user_email")).SendKeys("dunca205@gmail.com"); // Already Registred Email

            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca205");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var existentEmail = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[3]"));
            Assert.True(existentEmail.Displayed);
            // driver.Close();
        }

        [Fact]  ////#11
        public void CreateNewAccount_PasswordInEmpty()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys(string.Empty);
            driver.FindElement(By.Name("user_password_confirm")).SendKeys(string.Empty);
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var passwordIsMandatory = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[1]"));
            Assert.True(passwordIsMandatory.Displayed);
            driver.Close();
        }

        [Fact] //// #12
        public void CreateNewAccount_PasswordIsShorter()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dun");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dun");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var passwordIsTooShort = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[2]"));
            Assert.True(passwordIsTooShort.Displayed);
            driver.Close();

        }

        [Fact] //// #13
        public void CreateNewAccount_PasswordIsWhitespace()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("      ");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("      ");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();

            var passwordCantBeWhiteSpace = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[1]"));
            Assert.True(passwordCantBeWhiteSpace.Displayed);
            driver.Close();
        }

        [Fact] ////#14
        public void CreateNewAccount_PasswordIsEqualWithTheName()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("Dunca Cristina");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("Dunca Cristina");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();
            var passwordCantBeIdenticalWithTheName = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[3]"));
            Assert.True(passwordCantBeIdenticalWithTheName.Displayed);
            driver.Close();
        }

        // [Fact] ////14*
        public void CreateNewAccount_PasswordAndNameHasSameContentButDifferentCases() ////fail, it works
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("DUNCA CRISTINA"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dunca cristina");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca cristina");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();
            var passwordCantBeIdenticalWithTheName = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[3]"));
            Assert.True(passwordCantBeIdenticalWithTheName.Displayed);
            driver.Close();
        }

        // [Fact] ////#15
        public void CreateNewAccount_PasswordHasOneDifferentLetterFromTheName() //// fail, it works
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("Dunca Cristin");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("Dunca Cristin");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();
            var passwordCantBeSimilar = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[2]"));
            Assert.True(passwordCantBeSimilar.Displayed);
            driver.Close();
        }

        [Fact] ////#16
        public void CreateNewAccount_ConfirmationPasswordHasOneDifferentLetterFromPassword()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("DuncaCristina");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("DuncaCristin");
            driver.FindElement(By.Name("user_gdpr_formular")).Click();
            driver.FindElement(By.Name("user_gdpr")).Click();
            driver.FindElement(By.Name("submitContNou")).Click();
            var confirmationPasswordIsNotIdenticalWithThePassword = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[2]"));
            Assert.True(confirmationPasswordIsNotIdenticalWithThePassword.Displayed);
            driver.Close();
        }

        [Fact] ////#17
        public void CreateNewAccount_PersonalDataColectorAggrementNotMarked()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca204");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca204");

            var termsConditionsAndConfidentialityPolicyAgreement = driver.FindElement(By.Name("user_gdpr"));
            termsConditionsAndConfidentialityPolicyAgreement.Click(); // is mandatory

            var mandatoryFieldNotMaked = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[3]/div/div/small")); //personalDataCollectorAgreement

            driver.FindElement(By.Name("submitContNou")).Click();
            Assert.True(mandatoryFieldNotMaked.Displayed);
            driver.Close();
        }

        [Fact] //#18
        public void CreateNewAccount_TermsConditionsAndConfidentialityPolicyAgreementNotMarked()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;
            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca204");
            driver.FindElement(By.Name("user_password_confirm")).SendKeys("dunca204");

            var personalDataCollectorAgreement = driver.FindElement(By.Name("user_gdpr_formular"));
            personalDataCollectorAgreement.Click();

            var mandatoryFieldNotMaked = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[4]/div/div/small")); //TermsConditionsAndConfidentialityPolicy

            driver.FindElement(By.Name("submitContNou")).Click();
            Assert.True(mandatoryFieldNotMaked.Displayed);
            driver.Close();
        }

        [Fact]
        public void DeleteAccount()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.Name("user_email")).SendKeys("dunca205@gmail.com");
            driver.FindElement(By.Name("user_password")).SendKeys("dunca205");
            driver.FindElement(By.XPath("//*[@id=\"login\"]/div[3]/button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click(); ////deletion 
            driver.FindElement(By.Name("sterge_dp")).Click();
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Close();
        }
    }
}
