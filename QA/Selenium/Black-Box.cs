global using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;

namespace Selenium
{
    public class UnitTest1
    {
        [Fact]
        public void SearchForThingsOnAmazon()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://amazon.com");
            driver.FindElement(By.XPath("//*[@id=\"twotabsearchtextbox\"]")).SendKeys("Makeup");
            driver.FindElement(By.XPath("//*[@id=\"nav-search-submit-button\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"p_89/NYX Professional Makeup\"]/span/a/div/label/i")).Click();
            driver.Navigate().Back();
            driver.Close();

        }

        [Fact]
        public void LogInOnNetflix()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://netflix.com");
            var acceptCookiesButton = driver.FindElement(By.XPath("//*[@id=\"cookie-disclosure-accept\"]"));
            acceptCookiesButton.Click();
            Assert.Equal("https://www.netflix.com/ro-en/", driver.Url);

            driver.FindElement(By.XPath("//*[@id=\"appMountPoint\"]/div/div/div/div/div/div/header/div/span[3]/a")).Click();

            Assert.Equal("https://www.netflix.com/ro-en/login", driver.Url);
            driver.FindElement(By.Id("id_userLoginId")).SendKeys("dunca205@gmail.com");
            driver.FindElement(By.Id("id_password")).SendKeys("SighetuMarmaritiei");
            driver.FindElement(By.XPath("//*[@id=\"appMountPoint\"]/div/div[3]/div/div/div[1]/form/button")).Click(); //profile
            driver.Close();
                                                                                                                   
        }
    }
}