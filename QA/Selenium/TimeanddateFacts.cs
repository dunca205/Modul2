global using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class TimeanddateFacts
    {

        //  [Fact]
        public async void CreateNewAccountAccount_UsingValidData()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.timeanddate.com/");
            var acceptCookies = driver.FindElement(By.XPath("//*[@id=\"qc-cmp2-ui\"]/div[2]/div/button[2]"));
            acceptCookies.Click();
            driver.FindElement(By.XPath("//*[@id=\"site-nav\"]/li[11]/a/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"article-fixed\"]/div/section[1]/aside/p/a[1]")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var emailBox = wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"createform\"]/div[1]/div[2]/div[3]/input")));
            emailBox.SendKeys("dunca205@gmail.com");
            var passwordBox = wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"password\"]")));
            passwordBox.SendKeys("dunca205");
            var passwordConfirmBox = wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"password1\"]")));
            passwordConfirmBox.SendKeys(("dunca205"));
            driver.FindElement(By.Id("create")).Click();
            driver.FindElement(By.ClassName("close")).Click();
            driver.Close();
        }

        //   [Theory]
        [InlineData("dunca205@gmail.com", "dunca205")]
        public async void LogIn_UsingValidData(string email, string password)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.timeanddate.com/");
            var acceptCookies = driver.FindElement(By.XPath("//*[@id=\"qc-cmp2-ui\"]/div[2]/div/button[2]"));
            acceptCookies.Click();
            driver.FindElement(By.XPath("//*[@id=\"site-nav\"]/li[11]/a/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"article-fixed\"]/div/section[2]/div/p[2]/a[1]")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var emailBox = wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"email\"]")));
            emailBox.SendKeys(email);
            var passwordBox = wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"password\"]")));
            passwordBox.SendKeys(password);
            driver.FindElement(By.XPath("//*[@id=\"create\"]")).Click();
            wait.Until(element => driver.FindElement(By.XPath("//*[@id=\"article-fixed\"]/div/section[1]/div/div[1]/h3/a"))).Click();
        }
    }
}