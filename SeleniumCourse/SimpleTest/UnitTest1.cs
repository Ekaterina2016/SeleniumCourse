using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        [TestMethod]
        public void Task9()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(serverName);
            Login();
            chrome.FindElement(
                By.CssSelector("[href*='http://localhost:8080/litecart/admin/?app=countries&doc=countries']")).Click();
            var countries = chrome.FindElements(By.CssSelector("tr.row a:not([title=Edit])"));
            for (var i = 0; i < countries.Count - 1; i++)
            {
                Assert.IsTrue(string.CompareOrdinal(countries[i].Text, countries[i + 1].Text) <= 0,
                    "Страны не в алфавитном порядке");
            }


            var zonesInCountries = chrome
                .FindElements(By.XPath("//tr[contains(@class,'row')]//td[6][not(contains(.,0))]/../*/a[@title='Edit']"))
                .Select(e => e.GetAttribute("href")).ToList();
            foreach (var e in zonesInCountries)
            {
                chrome.Navigate().GoToUrl(e);
                var zones = chrome.FindElements(
                    By.XPath("//*[@id='table-zones']//input[contains(@name,'name') and not(@value='')]/.."));
                for (var i = 0; i < zones.Count - 1; i++)
                {
                    Assert.IsTrue(string.CompareOrdinal(zones[i].Text, zones[i + 1].Text) <= 0,
                        "Зоны не в алфавитном порядке");
                }
            }
        }

        [TestMethod]
        public void Task10()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(shopAddress);

            var duckOntheMainPage = chrome.FindElement(By.CssSelector(
                "[href*='http://localhost:8080/litecart/en/rubber-ducks-c-1/subcategory-c-2/yellow-duck-p-1']"));

            var productNameMainPage = duckOntheMainPage.FindElement(By.ClassName("name")).Text;
            var productRegularPriceMainPage = duckOntheMainPage.FindElement(By.ClassName("regular-price")).Text;
            var productDiscountPriceMainPage = duckOntheMainPage.FindElement(By.ClassName("campaign-price")).Text;
            var regularPriceColorMainPage = duckOntheMainPage.FindElement(By.ClassName("regular-price"))
                .GetCssValue("color").Replace("rgba(", "").Replace(")", "").Replace(" ", "").Split(',');
            var regularPriceSizeMainPage = duckOntheMainPage.FindElement(By.ClassName("regular-price")).Size.Height;
            var discountPriceColorMainPage = duckOntheMainPage.FindElement(By.ClassName("campaign-price"))
                .GetCssValue("color").Replace("rgba(", "").Replace(")", "").Replace(" ", "").Split(',');
            var discountPriceSizeMainPage = duckOntheMainPage.FindElement(By.ClassName("campaign-price")).Size.Height;

            duckOntheMainPage.Click();

            var duckOnProductPage = chrome.FindElement(By.Id("box-product"));

            var productNameProductPage = duckOnProductPage.FindElement(By.ClassName("title")).Text;
            var productRegularPriceProductPage = duckOnProductPage.FindElement(By.ClassName("regular-price")).Text;
            var productDiscountPriceProductPage = duckOnProductPage.FindElement(By.ClassName("campaign-price")).Text;
            var regularPriceColorProductPage =
                duckOnProductPage.FindElement(By.ClassName("regular-price")).GetCssValue("color").Replace("rgba(", "")
                    .Replace(")", "").Replace(" ", "").Split(',');
            var regularPriceSizeProductPage = duckOnProductPage.FindElement(By.ClassName("regular-price")).Size.Height;
            var discountPriceColorProductPage =
                duckOnProductPage.FindElement(By.ClassName("campaign-price")).GetCssValue("color").Replace("rgba(", "")
                    .Replace(")", "").Replace(" ", "").Split(',');
            var discountPriceSizeProductPage =
                duckOnProductPage.FindElement(By.ClassName("campaign-price")).Size.Height;

            Assert.AreEqual(productNameMainPage, productNameProductPage);
            Assert.AreEqual(productRegularPriceMainPage, productRegularPriceProductPage);
            Assert.AreEqual(productDiscountPriceMainPage, productDiscountPriceProductPage);
            Assert.IsTrue(discountPriceColorProductPage[1] == "0" && discountPriceColorProductPage[2] == "0" &&
                          discountPriceColorProductPage[0] != "0");
            Assert.IsTrue(discountPriceColorProductPage[1] == "0" && discountPriceColorMainPage[2] == "0" &&
                          discountPriceColorMainPage[0] != "0");
            Assert.IsTrue(regularPriceColorProductPage[0].Equals(regularPriceColorProductPage[1]) &&
                          regularPriceColorProductPage[1].Equals(regularPriceColorProductPage[2]));
            Assert.IsTrue(regularPriceColorMainPage[0].Equals(regularPriceColorMainPage[1]) &&
                          regularPriceColorMainPage[1].Equals(regularPriceColorMainPage[2]));

            Assert.IsTrue(discountPriceSizeProductPage - regularPriceSizeProductPage > 0);
            Assert.IsTrue(discountPriceSizeMainPage - regularPriceSizeMainPage > 0);
        }

        [TestMethod]
        public void Task11()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl(shopAddress);

            chrome.FindElement(By.CssSelector("[href*='http://localhost:8080/litecart/en/create_account']")).Click();

            var email = $"{Guid.NewGuid()}@qwerty.com";
            chrome.FindElement(By.Name("firstname")).SendKeys("firstname");
            chrome.FindElement(By.Name("lastname")).SendKeys("lastname");
            chrome.FindElement(By.Name("address1")).SendKeys("address");
            chrome.FindElement(By.Name("postcode")).SendKeys("12345");
            chrome.FindElement(By.Name("city")).SendKeys("city");
            new SelectElement(chrome.FindElement(By.Name("country_code"))).SelectByText("United States");
            chrome.FindElement(By.Name("phone")).SendKeys("+19999999999");
            chrome.FindElement(By.Name("email")).SendKeys(email);
            chrome.FindElement(By.Name("password")).SendKeys("12345");
            chrome.FindElement(By.Name("confirmed_password")).SendKeys("12345");
            chrome.FindElement(By.Name("create_account")).Click();

            Thread.Sleep(1000);
            var logout = chrome.FindElement(By.CssSelector("[href*='http://localhost:8080/litecart/en/logout']"));
            logout.Click();

            chrome.FindElement(By.Name("email")).SendKeys(email);
            chrome.FindElement(By.Name("password")).SendKeys("12345");
            chrome.FindElement(By.Name("login")).Click();

            logout.Click();
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