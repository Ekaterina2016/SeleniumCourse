using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimpleTest
{
    [TestClass]
    public class UnitTest1
    {
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
            Login();
        }

        [TestMethod]
        public void Task7()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(serverName);
            Login();
            Thread.Sleep(1000);

            var element = chrome.FindElement(By.Id("box-apps-menu"));
            var elements = element.FindElements(By.TagName("li")).Count;
            for (var i = 0; i < elements; i++)
            {
                var page = chrome.FindElements(By.XPath("//*[@id='app-']"));
                page[i].GetAttribute("h1");
                page[i].Click();

                var subElements = chrome.FindElements(By.XPath("//*[@id='app-']//li")).Count;
                for (var j = 0; j < subElements; j++)
                {
                    var subPage = chrome.FindElements(By.XPath("//*[@id='app-']//li"));
                    subPage[j].GetAttribute("h1");
                    subPage[j].Click();
                }
            }
        }

        [TestMethod]
        public void Task8()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(shopAddress);

            var products = chrome.FindElements(By.CssSelector("li.product"));
            foreach (var product in products)
            {
                var stickers = product.FindElements(By.ClassName("sticker")).Count;
                Assert.AreEqual(1, stickers);
            }
        }


        private void Login()
        {
            var username = chrome.FindElement(By.Name("username"));
            username.SendKeys("admin");
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


        private readonly string serverName = "http://localhost:8080/litecart/admin/login.php";
        private readonly string shopAddress = "http://localhost:8080/litecart/en/";
        private IWebDriver chrome;
    }
}