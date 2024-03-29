﻿using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class Auto_PiesaFacts
    {
      //  [Fact]////#1
        public void CreateNewAccount_ValidData()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");

            driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
            Assert.Equal("https://www.auto-piesa.ro/login", driver.Url);

            driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();
            Assert.Equal("https://www.auto-piesa.ro/cont-nou", driver.Url);

            var fullName = driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]"));
            fullName.SendKeys("Dunca Cristina Andreea");
            var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
            emailAdress.SendKeys("dunca205@gmail.com");
            var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
            password.SendKeys("dunca205");
            var passwordConfirm = driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\""));
            passwordConfirm.SendKeys("dunca205");

            driver.FindElement(By.Id("user_gdpr_formular")).Click();
            driver.FindElement(By.Id("user_gdpr")).Click();



            driver.FindElement(By.Id("submitContNou")).Click();
          //  driver.Close();

        }

        [Fact]////#2 can t find the right selector for the error message
        public static void CreateNewAccount_NameFieldIsEmpty()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
            driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();


            var fullName = driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]"));
            fullName.SendKeys(string.Empty);
            var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
            emailAdress.SendKeys("dunca205@gmail.com");
            var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
            password.SendKeys("dunca205");
            var passwordConfirm = driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\""));
            passwordConfirm.SendKeys("dunca205");
            driver.FindElement(By.Id("user_gdpr_formular")).Click();
            driver.FindElement(By.Id("user_gdpr")).Click();

            By emptyName = By.CssSelector("small[data-bv-for=\"user_firstname\"][data-bv-validator=\"notEmpty\"]");
            By nameLength = By.CssSelector("small[data-bv-for=\"user_firstname\"][data-bv-validator=\"stringLength\"]");
            driver.FindElement(By.Id("submitContNou")).Click();

            ////  var wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(5));
            ////  var nameFieldIsEmptyError = wait.Until(element=>fullName.FindElement(By.CssSelector(".help-block[data-bv-for=\"user_firstname\"][data-bv-result=\"INVALID\"]")));
            //var nameFieldIsEmptyError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[1]"));

            //Assert.True(nameFieldIsEmptyError.Displayed);
            //driver.Close();
        }

        //   [Fact] ////#2*
        public static void CreateNewAccount_NameIsWhiteSpace()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
            driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

            var fullName = driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]"));
            fullName.SendKeys("      ");
            driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca205@gmail.com");
            driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
            driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
            driver.FindElement(By.Id("user_gdpr_formular")).Click();
            driver.FindElement(By.Id("user_gdpr")).Click();
            driver.FindElement(By.Id("submitContNou")).Click();

            var nameFieldIsEmptyError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[1]"));
            Assert.True(nameFieldIsEmptyError.Displayed);
            driver.Close();

        }


        ///  [Fact] ////#2**

        public static void CreateNewAccount_NameIsOnlySynbolsAndNoLetter() //fail
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
            driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
            driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

            var fullName = driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]"));
            fullName.SendKeys("\")@#$&*");
            driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca203@gmail.com");
            driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
            driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
            driver.FindElement(By.Id("user_gdpr_formular")).Click();
            driver.FindElement(By.Id("user_gdpr")).Click();
            driver.FindElement(By.Id("submitContNou")).Click();

            var nameFieldIsEmptyError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[1]"));
            Assert.True(nameFieldIsEmptyError.Displayed);
            driver.Close();

        }

        //[Fact]////#3
        //public void CreateNewAccount_NameIsShorterThanExpected()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();


        //    var fullName = driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]"));
        //    fullName.SendKeys("a");
        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("dunca205@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("dunca205");
        //    var passwordConfirm = driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\""));
        //    passwordConfirm.SendKeys("dunca205");

        //    var personalDataCollectorAgreement = driver.FindElement(By.Id("user_gdpr_formular"));
        //    personalDataCollectorAgreement.Click();
        //    var termsConditionsAndConfidentialityPolicyAgreement = driver.FindElement(By.Id("user_gdpr"));
        //    termsConditionsAndConfidentialityPolicyAgreement.Click();

        //    var continueButton = driver.FindElement(By.Id("submitContNou"));
        //    continueButton.Click();

        //    // var nameFieldIsTooShortError = driver.FindElement(By.CssSelector("small[data-bv-for=\"user_firstname\"]"));
        //    var nameFieldIsTooShortError = fullName.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[1]/div/small[2]"));

        //    Assert.True(nameFieldIsTooShortError.Displayed);
        //    driver.Close();
        //}

        //[Fact]////#4
        //public void CreateNewAccount_EmailEmpty()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();


        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");

        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("");

        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/div/input"));
        //    Assert.True(invalidEmail.Displayed);
        //    driver.Close();

        //}

        //[Fact] ////#5
        //public void CreateNewAccount_InvalidEmail_MissingEmailProvider()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");

        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(invalidEmail.Displayed);
        //    driver.Close();

        //}

        //[Fact] ////#6
        //public void CreateNewAccount_InvalidEmail_ValidEmailProvider_MissingEmailDomain()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");

        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("dunca204@gmail");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(invalidEmail.Displayed);
        //    driver.Close();

        //}


        //[Fact] ////#7

        //public void CreateNewAccount_ValidEmailHavingExtraWhiteSpaceAtTheEnd()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");
        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("dunca205@gmail.com ");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(invalidEmail.Displayed);
        //    driver.Close();

        //}

        ////[Fact]//// #8
        //public void CreateNewAccount_InvalidEmail_InexistentEmailProvider_ExistentEmailDomain() //// fail
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("#register > div:nth-child(2) > div:nth-child(1) > div > div > input  ")).SendKeys("Dunca Cristina Andreea");
        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("dunca205@abcdefghij.com");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var invalidEmail = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(invalidEmail.Displayed);
        //    driver.Close();

        //}

        ////  [Fact] ////#9
        //public void CreateNewAccount_InvalidEmail_InvalidEmailProvider_InexistenEmailDomain() //// fail
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");

        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("dunca205@alabalaportocala.blabla");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();


        //    var missingEmailProviderErrorMessage = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(missingEmailProviderErrorMessage.Displayed);
        //    driver.Close();

        //}

        ////  [Fact] //#9*
        //public void CreateNewAccount_UsingAVeryLongEmailAdress() // fail, it works
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");

        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina@gmail.com");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();


        //    var missingEmailProviderErrorMessage = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(missingEmailProviderErrorMessage.Displayed);
        //    driver.Close();

        //}


        //[Fact] //#9**

        //public void CreateNewAccount_EmailAdressContainsOnlySymbols()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");

        //    var emailAdress = driver.FindElement(By.CssSelector("input[name=\"user_email\"]"));
        //    emailAdress.SendKeys("!@#$%^&*(@gmail.com");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();


        //    var invalidEmailAdressMessage = emailAdress.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[2]"));
        //    Assert.True(invalidEmailAdressMessage.Displayed);
        //    driver.Close();

        //}


        ////[Fact] ////#10 fail
        //public void CreateNewAccount_EmailIsAlreadyRegistred()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea");
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca205@gmail.com"); // Already Registred Email

        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca205");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var existentEmail = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[1]/div[2]/div/small[3]"));
        //    Assert.True(existentEmail.Displayed);
        //    driver.Close();
        //}

        //[Fact]  ////#11
        //public void CreateNewAccount_PasswordInEmpty()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys(string.Empty);
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys(string.Empty);
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var passwordIsMandatory = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[1]"));
        //    Assert.True(passwordIsMandatory.Displayed);
        //    driver.Close();
        //}

        //[Fact] //// #12
        //public void CreateNewAccount_PasswordIsShorter()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("dun");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dun");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var passwordIsTooShort = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[2]"));
        //    Assert.True(passwordIsTooShort.Displayed);
        //    driver.Close();

        //}

        //[Fact] //// #13
        //public void CreateNewAccount_PasswordIsWhitespace()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("      ");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("      ");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();

        //    var passwordCantBeWhiteSpace = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[1]"));
        //    Assert.True(passwordCantBeWhiteSpace.Displayed);
        //    driver.Close();
        //}

        //[Fact] ////#14
        //public void CreateNewAccount_PasswordIsEqualWithTheName()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("Dunca Cristina");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("Dunca Cristina");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    var passwordCantBeIdenticalWithTheName = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[3]"));
        //    Assert.True(passwordCantBeIdenticalWithTheName.Displayed);
        //    driver.Close();
        //}

        ////  [Fact] ////14*
        //public void CreateNewAccount_PasswordAndNameHasSameContentButDifferentCases() ////fail, it works
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("DUNCA CRISTINA"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("dunca cristina");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca cristina");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    var passwordCantBeIdenticalWithTheName = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[3]"));
        //    Assert.True(passwordCantBeIdenticalWithTheName.Displayed);
        //    driver.Close();
        //}

        //////  [Fact] //////#14** fail it works
        //public void CreateNewAccount_PasswordAndConfirmationPasswordLengthIsLargerThan1000Characters()
        //{
        //    var passwordContent = "duncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristinaduncacristina";
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("DUNCA CRISTINA"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca203@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys(passwordContent);
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys(passwordContent);
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    var passwordCantBeIdenticalWithTheName = password.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[1]/div/small[3]"));
        //    Assert.True(passwordCantBeIdenticalWithTheName.Displayed);
        //    driver.Close();
        //}


        ////[Fact] ////#15

        //public void CreateNewAccount_PasswordHasOneDifferentLetterFromTheName() //// fail, it works
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("Dunca Cristin");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("Dunca Cristin");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    var passwordCantBeSimilar = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[2]"));
        //    Assert.True(passwordCantBeSimilar.Displayed);
        //    driver.Close();
        //}

        //[Fact] ////#16
        //public void CreateNewAccount_ConfirmationPasswordHasOneDifferentLetterFromPassword()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    var password = driver.FindElement(By.CssSelector("input[name=\"user_password\""));
        //    password.SendKeys("DuncaCristina");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("DuncaCristin");
        //    driver.FindElement(By.Id("user_gdpr_formular")).Click();
        //    driver.FindElement(By.Id("user_gdpr")).Click();
        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    var confirmationPasswordIsNotIdenticalWithThePassword = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[2]/div[2]/div/small[2]"));
        //    Assert.True(confirmationPasswordIsNotIdenticalWithThePassword.Displayed);
        //    driver.Close();
        //}

        //[Fact] ////#17
        //public void CreateNewAccount_PersonalDataColectorAggrementNotMarked()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca204");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca204");

        //    var termsConditionsAndConfidentialityPolicyAgreement = driver.FindElement(By.Id("user_gdpr"));
        //    termsConditionsAndConfidentialityPolicyAgreement.Click(); // is mandatory

        //    var mandatoryFieldNotMaked = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[3]/div/div/small")); //personalDataCollectorAgreement

        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    Assert.True(mandatoryFieldNotMaked.Displayed);
        //    driver.Close();
        //}

        //[Fact] //#18
        //public void CreateNewAccount_TermsConditionsAndConfidentialityPolicyAgreementNotMarked()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"cont-nou\"]")).Click();

        //    driver.FindElement(By.CssSelector("input[name=\"user_firstname\"]")).SendKeys("Dunca Cristina Andreea"); ;
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca204@gmail.com");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca204");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password_confirm\"")).SendKeys("dunca204");

        //    var personalDataCollectorAgreement = driver.FindElement(By.Id("user_gdpr_formular"));
        //    personalDataCollectorAgreement.Click();

        //    var mandatoryFieldNotMaked = driver.FindElement(By.XPath("//*[@id=\"register\"]/div[4]/div/div/small")); //TermsConditionsAndConfidentialityPolicy

        //    driver.FindElement(By.Id("submitContNou")).Click();
        //    Assert.True(mandatoryFieldNotMaked.Displayed);
        //    driver.Close();
        //}

        //[Fact]
        //public void DeleteAccount()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://www.auto-piesa.ro/");
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click();
        //    driver.FindElement(By.CssSelector("input[name=\"user_email\"]")).SendKeys("dunca205@gmail.com");
        //    driver.FindElement(By.CssSelector("input[name=\"user_password\"")).SendKeys("dunca205");
        //    driver.FindElement(By.XPath("//*[@id=\"login\"]/div[3]/button")).Click();
        //    driver.FindElement(By.CssSelector("a[href=\"contul-meu\"]")).Click(); ////deletion 
        //    driver.FindElement(By.Name("sterge_dp")).Click();
        //    var alert = driver.SwitchTo().Alert();
        //    alert.Accept();
        //    driver.Close();
        //}
    }
}
