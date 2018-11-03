using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimpleTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver chrome;

        [TestMethod]
        public void TestMethod1()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.google.com/");
        }

        [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}