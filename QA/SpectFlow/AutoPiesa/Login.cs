using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoPiesa
{
    public class Login
    {
        ChromeDriver driver;
        public Login()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.auto-piesa.ro/login");
        }

        By email = By.CssSelector("input[name=\"user_email\"]");
        By password = By.CssSelector("input[name=\"user_password\"");
        By loginButton = By.CssSelector("button[name=\"submitLogin\"]");

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
        public string SubmitLogin()
        {
            driver.FindElement(loginButton).Click();
            return driver.Url;
        }

        public void CloseChrome()
        {
            driver.Close();
        }
    }
}
