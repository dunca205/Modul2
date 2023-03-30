global using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V110.CSS;
using Amazon.DynamoDBv2;

namespace Selenium
{
    public class UnitTest1
    {

        [Fact]
        public async void CreateNewAccountAccount()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.timeanddate.com/");
            driver.Manage().Window.Maximize();
            var acceptCookies =  driver.FindElement(By.XPath("//*[@id=\"qc-cmp2-ui\"]/div[2]/div/button[2]"));
            acceptCookies.Click();
            driver.FindElement(By.XPath("//*[@id=\"site-nav\"]/li[11]/a/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"article-fixed\"]/div/section[1]/aside/p/a[1]")).Click();
            //  Assert.Equal("https://www.timeanddate.com/", driver.Url);
            //driver.Url = "https://www.timeanddate.com/";
            //driver.Manage().Window.Maximize();
            //driver.Url = "https://www.timeanddate.com/";
            //driver.FindElement(By.XPath("//*[@id=\"site-nav\"]/li[11]")).Click();


            //Assert.Equal("https://pomofocus.io/login", driver.Url);

            //driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[3]/button")).Click(); // create new account
            //Assert.Equal("https://pomofocus.io/signup", driver.Url);

            //driver.Url = "https://pomofocus.io/signup";
            //driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input")).SendKeys("dunca205@gmail.com");
            //driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/div[4]/button")).Click();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            //driver.Close();

        }
    
        //[Theory]
        //[InlineData("dunca205@gmail.com", "dunca205")]
        
        public void SuccesfullyLoginWithExistingAccount(string accountEmail, string accountPassword)
        { 
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pomofocus.io/");
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/button/div")).Click();
            driver.Url = "https://pomofocus.io/login";
            var usernameBox = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input[1]"));
            usernameBox.SendKeys(accountEmail);
            var passwordBox = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/input[2]"));
            passwordBox.SendKeys(accountPassword);
            var login = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div/div[2]/div[5]/button"));
            login.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
         
            driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/button")).Click();
            //var account = driver.FindElement(By.XPath("//*[@id=\"target\"]/div/div[1]/div[1]/div/div/span/div/button/img"));
            //account.Click();
            //driver.Close();
        }

        //[Theory]
        //[InlineData("dunca205@gmail.com", "dunca205")]
        //public void DeleteExistinAccount(string accountEmail, string accountPassword) 
        //{

        //}

    }
}