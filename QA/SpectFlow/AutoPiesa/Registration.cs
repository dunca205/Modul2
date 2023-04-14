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
        //erori 
        By  personalDataCollector = By.CssSelector("small[data-bv-for=\"user_gdpr_formular\"]");
        By ConditionsAndConfidentialityPolicy = By.CssSelector("small[data-bv-for=\"user_gdpr\"]");

        public IWebElement EmptyNameFieldError { get => driver.FindElement(emptyName); }
        public IWebElement NameIsTooShort { get => driver.FindElement(nameLength); }
        public IWebElement EmptyEmailFieldError { get => driver.FindElement(emptyEmail); }
        public IWebElement InvalidEmailFormat { get => driver.FindElement(invalidFormat); }
        public IWebElement EmailIsAlreadyRegistred { get => driver.FindElement(registredEmail); }
        public IWebElement EmptyPassowrdFieldError { get => driver.FindElement(emptyPassword); }
        public IWebElement PasswordIsTooShort { get => driver.FindElement(passwordLength); }
        public IWebElement PassowrdIsIdenticalWithTheName { get => driver.FindElement(differentFromName); }
        public IWebElement EmptyConfirmationPassword { get => driver.FindElement(emptyConfirmationPassword); }
        public IWebElement ConfirmationPasswordIsIdenticalWithTheName { get => driver.FindElement(identicalConfirmationPassword); }
        public IWebElement ConfirmationPasswordIsTooShort { get => driver.FindElement(confirmationPasswordLength); }
        public IWebElement PersonalDataCollectorAgreementError { get => driver.FindElement(personalDataCollector); }
        public IWebElement ConditionsAndConfidentialityPolicyError {  get => driver.FindElement(ConditionsAndConfidentialityPolicy); }
        public string DisplayedNameErrors()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var nameErrors = new List<IWebElement>();
            nameErrors.Add(wait.Until(error => EmptyNameFieldError));
            nameErrors.Add(wait.Until(error => NameIsTooShort));

            return nameErrors.Aggregate((""), (current, error) => error.Displayed ? current += error.Text + ' ' : current);

        }
        public string DisplayedEmailErrors()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var emailErrors = new List<IWebElement>();
            emailErrors.Add(wait.Until(error => EmptyEmailFieldError));
            emailErrors.Add(wait.Until(error => InvalidEmailFormat));
            emailErrors.Add(wait.Until(error => EmailIsAlreadyRegistred));

            return emailErrors.Aggregate((""), (current, error) => error.Displayed ? current += error.Text + ' ' : current);

        }
        public string DisplayedPasswordErrors()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var passwordErrors = new List<IWebElement>();
            passwordErrors.Add(wait.Until(error => EmptyPassowrdFieldError));
            passwordErrors.Add(wait.Until(error => PasswordIsTooShort));
            passwordErrors.Add(wait.Until(error => PassowrdIsIdenticalWithTheName));
            return passwordErrors.Aggregate((""), (current, error) => error.Displayed ? current += error.Text + ' ' : current);
        }
        public string DisplayedConfirmationPasswordErrors()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var passwordErrors = new List<IWebElement>();
            passwordErrors.Add(wait.Until(error => EmptyConfirmationPassword));
            passwordErrors.Add(wait.Until(error => ConfirmationPasswordIsIdenticalWithTheName));
            passwordErrors.Add(wait.Until(error => ConfirmationPasswordIsTooShort));
            return passwordErrors.Aggregate((""), (current, error) => error.Displayed ? current += error.Text + ' ' : current);
        }
        public string DisplayMandatoryAgreementsErrors()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var agreementsErrors = new List<IWebElement>();
            agreementsErrors.Add(wait.Until(error => PersonalDataCollectorAgreementError));
            agreementsErrors.Add(wait.Until(error => ConditionsAndConfidentialityPolicyError));
            return agreementsErrors.Aggregate("", (current, error) => error.Displayed ? current += error.Text + ' ' : current);

        }
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