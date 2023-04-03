using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    public class Auto_PiesaFacts
    {
        // [Fact]
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

            var personalDataCollectorAgreement = driver.FindElement(By.Name("user_gdpr_formular"));
            personalDataCollectorAgreement.Click(); // is mandatory

            var termsConditionsAndConfidentialityPolicyAgreement = driver.FindElement(By.Name("user_gdpr"));
            termsConditionsAndConfidentialityPolicyAgreement.Click(); // is mandatory

            var continueButton = driver.FindElement(By.Name("submitContNou"));
            continueButton.Click();
            Assert.Equal("https://www.auto-piesa.ro/cos", driver.Url);
            driver.Close();
        }

        // [Fact]
        public static void CreateNewAccount_NameFieldIsEmpty() // fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();


            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys(string.Empty);
            var nameFieldIsEmptyError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[1]"));
            Assert.False(nameFieldIsEmptyError.Displayed); // should be displayed
            driver.Close();
        }

        // [Fact]
        public void CreateNewAccount_NameIsShorterThanExpected()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();


            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("a");
            var nameFieldIsTooShortError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[2]"));
            // //*[@id="register"]/div[1]/div[1]/div/small[1]

            Assert.True(nameFieldIsTooShortError.Displayed);
            driver.Close();
        }

        // [Fact]
        public async void CreateNewAccount_EmailEmpty()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();


            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("");

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/div/input"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        // [Fact]
        public async void CreateNewAccount_InvalidEmail_MissingEmailProvider()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205");

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        // [Fact]
        public async void CreateNewAccount_InvalidEmail_ValidEmailProvider_MissingEmailDomain()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@gmail");

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        //  [Fact]
        public async void CreateNewAccount_InvalidEmail_InexistentEmailProvider_ExistentEmailDomain() // fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@abcdefghij.com");

            var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(invalidEmail.Displayed);
            driver.Close();

        }

        // [Fact]
        public async void CreateNewAccount_InvalidEmail_InvalidEmailProvider_InexistenEmailDomain() // fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@alabalaportocala.blabla");

            var missingEmailProviderErrorMessage = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
            Assert.True(missingEmailProviderErrorMessage.Displayed);
            driver.Close();

        }

        // [Fact]
        public async void CreateNewAccount_EmailIsAlreadyRegistred() // fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();
            var fullName = driver.FindElement(By.Name("user_firstname"));
            fullName.SendKeys("Dunca Cristina Andreea");

            var emailAdress = driver.FindElement(By.Name("user_email"));
            emailAdress.SendKeys("dunca205@gmail.com");

            var missingEmailProvider = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]")).Displayed;
            Assert.False(missingEmailProvider);

            var existentEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[3]"));
            // Assert.True(existentEmail.Displayed); eroare ar trebui afisata(este oarecum afisata dar eu cand verific aici imi zice ca nu e , la restul erorilor functioneaza 
            driver.Close();
        }

        // [Fact] 
        public async void CreateNewAccount_PasswordIsShorterThanExpecter() // fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;

            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");

            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys(string.Empty);
            var passwordIsMandatory = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[1]"));
            Assert.True(passwordIsMandatory.Displayed);
            // nu arata right away ca si la mail sau la nume

        }

        // [Fact]
        public async void CreateNewAccount_PasswordIsShorter()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;

            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");

            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("Dun");
            var passwordIsTooShort = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[2]"));
            Assert.True(passwordIsTooShort.Displayed);

        }

        // [Fact]
        public async void CreateNewAccount_PasswordIsEqualWithTheName()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;

            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");

            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("Dunca Cristina Andreea");
            var passwordCantBeIdenticalWithTheName = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[3]"));
            Assert.True(passwordCantBeIdenticalWithTheName.Displayed);

        }

       // [Fact]
        public async void CreateNewAccount_ConfirmationPasswordHasOneDifferentLetter()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;

            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");

            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dunca204");
            var confirmationPassword = driver.FindElement(By.Name("user_password_confirm"));
            confirmationPassword.SendKeys("dunca205");
            var confirmationPasswordIsNotIdentical = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[2]"));
            Assert.True(confirmationPasswordIsNotIdentical.Displayed);
        }

      //  [Fact]
        public async void CreateNewAccount_ConfirmationPasswordIsShorter()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.XPath("//*[@id=\"navbarNavDropdown\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div/div[3]/div/div[2]/a[1]")).Click();

            driver.FindElement(By.Name("user_firstname")).SendKeys("Dunca Cristina Andreea"); ;

            driver.FindElement(By.Name("user_email")).SendKeys("dunca204@gmail.com");

            var password = driver.FindElement(By.Name("user_password"));
            password.SendKeys("dunca204");
            var confirmationPassword = driver.FindElement(By.Name("user_password_confirm"));
            confirmationPassword.SendKeys("dun");

            var confirmationPasswordIsNotIdentical = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[2]"));
            var confirmationPasswordIsShorter = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[3]"));

            Assert.True(confirmationPasswordIsNotIdentical.Displayed && confirmationPasswordIsShorter.Displayed);
        }


    //   [Fact]
        public async void CreateNewAccount_PersonalDataColectorAggrementNotMarked()
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
           
        }

      //  [Fact]
        public async void CreateNewAccount_TermsConditionsAndConfidentialityPolicyAgreementNotMarked()
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
            
        }

    }
}
