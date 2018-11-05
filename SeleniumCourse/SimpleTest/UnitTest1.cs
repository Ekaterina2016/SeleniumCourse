using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimpleTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver chrome;
        private string serverName = "http://localhost:8080/litecart/en/";

        [TestMethod]
        public void TestMethod1()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.google.com/");
        }

        [TestMethod]
        public void LoginTest()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(serverName);
            var email = chrome.FindElement(By.Name("email"));
            email.SendKeys("admin");
            var password = chrome.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var loginButton = chrome.FindElement(By.Name("login"));
            loginButton.Click();
        }

        [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}