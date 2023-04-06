using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace AutoPiesa
{
    public class Registration
    {
        ChromeDriver driver;
        //https://www.auto-piesa.ro/cont-nou
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
        By continueButton = By.Id("submitContNou");

        public void EnterFullName(string userFullName)
        {
            driver.FindElement(fullName).SendKeys(userFullName);
        }

        public void EnterEmail(string userEmail)
        {
            driver.FindElement(email).SendKeys(userEmail);
        }

        public void EnterPassword(string userPassword)
        {
            driver.FindElement(password).SendKeys(userPassword);
        }

        public void EnterConfirmationPasswordd(string userConfirmationPassword)
        {
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
    }
}