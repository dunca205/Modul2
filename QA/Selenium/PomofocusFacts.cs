using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class PomofocusFacts
    {
        // [Theory]
        [InlineData("dunca205@gmail.com", "dunca205")]
        public void DeleteAccount(string accountEmail, string accountPassword)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pomofocus.io/");
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/button/div")).Click();
            var usernameBox = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input[1]"));
            usernameBox.SendKeys(accountEmail);
            var passwordBox = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input[2]"));
            passwordBox.SendKeys(accountPassword);
            var login = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/div[5]/button"));
            login.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/div[1]/img"))).Click();
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/div[2]/div[5]")).Click();

        }

        //   [Fact]
        public void CreateAccount_UsingValidData()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pomofocus.io/");
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/button/div")).Click();
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[3]/button")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input"))).SendKeys("dunca205@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/div[4]/button")).Click();
            driver.Close();

        }

        // [Theory]
        [InlineData("dunca205@gmail.com", "dunca205")]
        public void Login_UsingValidData(string accountEmail, string accountPassword)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pomofocus.io/");
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/button/div")).Click();
            var usernameBox = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input[1]"));
            usernameBox.SendKeys(accountEmail);
            var passwordBox = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input[2]"));
            passwordBox.SendKeys(accountPassword);
            var login = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/div[5]/button"));
            login.Click();

        }
    }
}
