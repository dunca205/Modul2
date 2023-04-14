using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutoPiesa
{
    public class Registration
    {
        ChromeDriver driver;
        public Registration()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/cont-nou");
        }

        By fullName = By.CssSelector("input[name=\"user_firstname\"]");
        By email = By.CssSelector("input[name=\"user_email\"]");
        By password = By.CssSelector("input[name=\"user_password\"");
        By confirmationPassword = By.CssSelector("input[name=\"user_password_confirm\"");
        By personalDataCollectorAgreement = By.Id("user_gdpr_formular");
        By termsConditionsAndConfidentialityPolicyAgreement = By.Id("user_gdpr");
        By continueButton = By.CssSelector("button[name=\"submitContNou\"");

        // erori nume
        By emptyName = By.CssSelector("small[data-bv-for=\"user_firstname\"][data-bv-validator=\"notEmpty\"]");
        By nameLength = By.CssSelector("small[data-bv-for=\"user_firstname\"][data-bv-validator=\"stringLength\"]");
        //erori email
        By emptyEmail = By.CssSelector("small[data-bv-for=\"user_email\"][data-bv-validator=\"notEmpty\"]");
        By invalidFormat = By.CssSelector("small[data-bv-for=\"user_email\"][data-bv-validator=\"emailAddress\"]");
        By registredEmail = By.CssSelector("small[data-bv-for=\"user_email\"][data-bv-validator=\"remote\"]");
        //eroi parola
        By emptyPassword = By.CssSelector("small[data-bv-for=\"user_password\"][data-bv-validator=\"notEmpty\"]");
        By passwordLength = By.CssSelector("small[data-bv-for=\"user_password\"][data-bv-validator=\"stringLength\"]");
        By differentFromName = By.CssSelector("small[data-bv-for=\"user_password\"][data-bv-validator=\"different\"]");
        //erori parola confirmare 
        By emptyConfirmationPassword = By.CssSelector("small[data-bv-for=\"user_password_confirm\"][data-bv-validator=\"notEmpty\"]");
        By identicalConfirmationPassword = By.CssSelector("small[data-bv-for=\"user_password_confirm\"][data-bv-validator=\"identical\"]");
        By confirmationPasswordLength = By.CssSelector("small[data-bv-for=\"user_password_confirm\"][data-bv-validator=\"stringLength\"]");

        public string DisplayedNameErrors()
        {
            string errors = "";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var errorNameEmpty = wait.Until(error => EmptyNameFieldError);
            var errorNameIsTooShort = wait.Until(error => NameIsTooShort);
            if (errorNameEmpty.Displayed == true)
            {
                errors += errorNameEmpty.Text;
            }

            if (errorNameIsTooShort.Displayed == true)
            { 
                errors += errorNameIsTooShort.Text;
            }

            return errors;

        }
        public string DisplayedEmailErrors()
        {
            string errors = "";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var emailEmpty = wait.Until(error => EmptyEmailFieldError);
            var invalidFormat = wait.Until(error => InvalidEmailFormat);
            var emailAlreadyRegistred = wait.Until(error => EmailIsAlreadyRegistred);



            return errors;

        }
        public IWebElement EmptyNameFieldError { get => driver.FindElement(emptyName); }
        public IWebElement NameIsTooShort { get => driver.FindElement(nameLength); }
        public IWebElement EmptyEmailFieldError { get => driver.FindElement(emptyEmail); }
        public IWebElement InvalidEmailFormat { get => driver.FindElement(invalidFormat); }
        public IWebElement EmailIsAlreadyRegistred { get => driver.FindElement(registredEmail); }
        public string EmptyPassowrdFieldError { get => driver.FindElement(emptyPassword).Text; }
        public string PasswordIsTooShort { get => driver.FindElement(passwordLength).Text; }
        public string PassowrdIsIdenticalWithTheName { get => driver.FindElement(differentFromName).Text; }
        public string EmptyConfirmationPassword { get => driver.FindElement(emptyConfirmationPassword).Text; }
        public string ConfirmationPasswordIsIdenticalWithTheName { get => driver.FindElement(identicalConfirmationPassword).Text; }
        public string ConfirmationPasswordIsTooShort { get => driver.FindElement(confirmationPasswordLength).Text; }
        public void EnterFullName(string userFullName)
        {
            driver.FindElement(fullName).Clear();
            driver.FindElement(fullName).SendKeys(userFullName);
        }

        public void EnterEmail(string userEmail)
        {
            driver.FindElement(email).Clear();
            driver.FindElement(email).SendKeys(userEmail);
        }

        public void EnterPassword(string userPassword)
        {
            driver.FindElement(password).Clear();
            driver.FindElement(password).SendKeys(userPassword);
        }

        public void EnterConfirmationPasswordd(string userConfirmationPassword)
        {
            driver.FindElement(confirmationPassword).Clear();
            driver.FindElement(confirmationPassword).SendKeys(userConfirmationPassword);
        }

        public void AgreeWithPersonalDataCollector(bool agree)
        {
            if (!agree)
            {
                return;
            }

            driver.FindElement(personalDataCollectorAgreement).Click();
        }

        public void AgreeWithConditionsAndConfindentialityPolicy(bool agree)
        {
            if (!agree)
            {
                return;
            }

            driver.FindElement(termsConditionsAndConfidentialityPolicyAgreement).Click();

        }

        public void ContinueRegistration()
        {
            driver.FindElement(continueButton).Click();
        }
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}