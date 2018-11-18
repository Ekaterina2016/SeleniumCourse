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

            CheckAllButtonsAreClicableAndH1AttributeInLeftMenu();
        }


        private void CheckAllButtonsAreClicableAndH1AttributeInLeftMenu()
        {
            chrome.FindElement(By.CssSelector(appearanceHref)).Click();
            chrome.FindElement(By.CssSelector(appearanceHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(appearanceTemplateHref)).Click();
            chrome.FindElement(By.CssSelector(appearanceLogotypeHref)).Click();

            chrome.FindElement(By.CssSelector(catalogHref)).Click();
            chrome.FindElement(By.CssSelector(catalogHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(catalogCatalogHref)).Click();
            chrome.FindElement(By.CssSelector(catalogProductGroupsHref)).Click();
            chrome.FindElement(By.CssSelector(catalogOptionGroupsHref)).Click();
            chrome.FindElement(By.CssSelector(catalogManufacturersHref)).Click();
            chrome.FindElement(By.CssSelector(catalogSuppliersHref)).Click();
            chrome.FindElement(By.CssSelector(catalogDeliveryStatusesHref)).Click();
            chrome.FindElement(By.CssSelector(catalogSoldOutStatusesHref)).Click();
            chrome.FindElement(By.CssSelector(catalogQuantityUnitsHref)).Click();
            chrome.FindElement(By.CssSelector(catalogCsvHref)).Click();

            chrome.FindElement(By.CssSelector(countriesHref)).Click();
            chrome.FindElement(By.CssSelector(countriesHref)).GetAttribute("h1");

            chrome.FindElement(By.CssSelector(currenciesHref)).Click();
            chrome.FindElement(By.CssSelector(currenciesHref)).GetAttribute("h1");

            chrome.FindElement(By.CssSelector(customersHref)).Click();
            chrome.FindElement(By.CssSelector(customersHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(customersCustomersHref)).Click();
            chrome.FindElement(By.CssSelector(customersCsvHref)).Click();
            chrome.FindElement(By.CssSelector(customersNewsletterHref)).Click();

            chrome.FindElement(By.CssSelector(geoZonesHref)).Click();
            chrome.FindElement(By.CssSelector(geoZonesHref)).GetAttribute("h1");

            chrome.FindElement(By.CssSelector(languagesHref)).Click();
            chrome.FindElement(By.CssSelector(languagesHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(languagesLanguagesHref)).Click();
            chrome.FindElement(By.CssSelector(languagesStorageEncodingHref)).Click();

            chrome.FindElement(By.CssSelector(modulesHref)).Click();
            chrome.FindElement(By.CssSelector(modulesHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(modulesBackgroundJobsHref)).Click();
            chrome.FindElement(By.CssSelector(modulesCustomerHref)).Click();
            chrome.FindElement(By.CssSelector(modulesShippingHref)).Click();
            chrome.FindElement(By.CssSelector(modulesPaymentHref)).Click();
            chrome.FindElement(By.CssSelector(modulesOrderTotalHref)).Click();
            chrome.FindElement(By.CssSelector(modulesOrderSuccessHref)).Click();
            chrome.FindElement(By.CssSelector(modulesOrderActionHref)).Click();

            chrome.FindElement(By.CssSelector(ordersHref)).Click();
            chrome.FindElement(By.CssSelector(ordersHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(ordersOrdersHref)).Click();
            chrome.FindElement(By.CssSelector(ordersOrderStatusesHref)).Click();

            chrome.FindElement(By.CssSelector(pagesHref)).Click();
            chrome.FindElement(By.CssSelector(pagesHref)).GetAttribute("h1");

            chrome.FindElement(By.CssSelector(reportsHref)).Click();
            chrome.FindElement(By.CssSelector(reportsHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(reportsMonthlySalesHref)).Click();
            chrome.FindElement(By.CssSelector(reportsMostSoldProductsHref)).Click();
            chrome.FindElement(By.CssSelector(reportsMostShoppingCustomersHref)).Click();

            chrome.FindElement(By.CssSelector(settingsHref)).Click();
            chrome.FindElement(By.CssSelector(settingsHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(settingsStoreInfoHref)).Click();
            chrome.FindElement(By.CssSelector(settingsDefaultsHref)).Click();
            chrome.FindElement(By.CssSelector(settingsGeneralHref)).Click();
            chrome.FindElement(By.CssSelector(settingsListingsHref)).Click();
            chrome.FindElement(By.CssSelector(settingsImagesHref)).Click();
            chrome.FindElement(By.CssSelector(settingsCheckoutHref)).Click();
            chrome.FindElement(By.CssSelector(settingsAdvancedHref)).Click();
            chrome.FindElement(By.CssSelector(settingsSecurityHref)).Click();

            chrome.FindElement(By.CssSelector(slidesHref)).Click();
            chrome.FindElement(By.CssSelector(slidesHref)).GetAttribute("h1");

            chrome.FindElement(By.CssSelector(taxHref)).Click();
            chrome.FindElement(By.CssSelector(taxHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(taxClassesHref)).Click();
            chrome.FindElement(By.CssSelector(taxRatesHref)).Click();

            chrome.FindElement(By.CssSelector(translationsHref)).Click();
            chrome.FindElement(By.CssSelector(translationsHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(translationsScanFilesHref)).Click();
            chrome.FindElement(By.CssSelector(translationsCsvHref)).Click();

            chrome.FindElement(By.CssSelector(usersHref)).Click();
            chrome.FindElement(By.CssSelector(usersHref)).GetAttribute("h1");
            chrome.FindElement(By.CssSelector(vQmodsHref)).Click();
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

        #region ссылки бокового меню

        private readonly string appearanceHref =
            "[href*='http://localhost:8080/litecart/admin/?app=appearance&doc=template']";

        private readonly string appearanceTemplateHref =
            "[href*='http://localhost:8080/litecart/admin/?app=appearance&doc=template']";

        private readonly string appearanceLogotypeHref =
            "[href*='http://localhost:8080/litecart/admin/?app=appearance&doc=logotype']";

        private readonly string catalogHref = "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=catalog']";

        private readonly string catalogCatalogHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=catalog']";

        private readonly string catalogProductGroupsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=product_groups']";

        private readonly string catalogOptionGroupsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=option_groups']";

        private readonly string catalogManufacturersHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=manufacturers']";

        private readonly string catalogSuppliersHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=suppliers']";

        private readonly string catalogDeliveryStatusesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=delivery_statuses']";

        private readonly string catalogSoldOutStatusesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=sold_out_statuses']";

        private readonly string catalogQuantityUnitsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=quantity_units']";

        private readonly string catalogCsvHref = "[href*='http://localhost:8080/litecart/admin/?app=catalog&doc=csv']";

        private readonly string countriesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=countries&doc=countries']";

        private readonly string currenciesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=currencies&doc=currencies']";

        private readonly string customersHref =
            "[href*='http://localhost:8080/litecart/admin/?app=customers&doc=customers']";

        private readonly string customersCustomersHref =
            "[href*='http://localhost:8080/litecart/admin/?app=customers&doc=customers']";

        private readonly string customersCsvHref =
            "[href*='http://localhost:8080/litecart/admin/?app=customers&doc=csv']";

        private readonly string customersNewsletterHref =
            "[href*='http://localhost:8080/litecart/admin/?app=customers&doc=newsletter']";

        private readonly string geoZonesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=geo_zones&doc=geo_zones']";

        private readonly string languagesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=languages&doc=languages']";

        private readonly string languagesLanguagesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=languages&doc=languages']";

        private readonly string languagesStorageEncodingHref =
            "[href*='http://localhost:8080/litecart/admin/?app=languages&doc=storage_encoding']";

        private readonly string modulesHref = "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=jobs']";

        private readonly string modulesBackgroundJobsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=jobs']";

        private readonly string modulesCustomerHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=customer']";

        private readonly string modulesShippingHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=shipping']";

        private readonly string modulesPaymentHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=payment']";

        private readonly string modulesOrderTotalHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=order_total']";

        private readonly string modulesOrderSuccessHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=order_success']";

        private readonly string modulesOrderActionHref =
            "[href*='http://localhost:8080/litecart/admin/?app=modules&doc=order_action']";

        private readonly string ordersHref = "[href*='http://localhost:8080/litecart/admin/?app=orders&doc=orders']";

        private readonly string ordersOrdersHref =
            "[href*='http://localhost:8080/litecart/admin/?app=orders&doc=orders']";

        private readonly string ordersOrderStatusesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=orders&doc=order_statuses']";

        private readonly string pagesHref = "[href*='http://localhost:8080/litecart/admin/?app=pages&doc=pages']";

        private readonly string reportsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=reports&doc=monthly_sales']";

        private readonly string reportsMonthlySalesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=reports&doc=monthly_sales']";

        private readonly string reportsMostSoldProductsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=reports&doc=most_sold_products']";

        private readonly string reportsMostShoppingCustomersHref =
            "[href*='http://localhost:8080/litecart/admin/?app=reports&doc=most_shopping_customers']";

        private readonly string settingsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=store_info']";

        private readonly string settingsStoreInfoHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=store_info']";

        private readonly string settingsDefaultsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=default']";

        private readonly string settingsGeneralHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=general']";

        private readonly string settingsListingsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=listings']";

        private readonly string settingsImagesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=images']";

        private readonly string settingsCheckoutHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=checkout']";

        private readonly string settingsAdvancedHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=advanced']";

        private readonly string settingsSecurityHref =
            "[href*='http://localhost:8080/litecart/admin/?app=settings&doc=security']";

        private readonly string slidesHref = "[href*='http://localhost:8080/litecart/admin/?app=slides&doc=slides']";

        private readonly string taxHref = "[href*='http://localhost:8080/litecart/admin/?app=tax&doc=tax_classes']";

        private readonly string taxClassesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=tax&doc=tax_classes']";

        private readonly string taxRatesHref = "[href*='http://localhost:8080/litecart/admin/?app=tax&doc=tax_rates']";

        private readonly string translationsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=translations&doc=search']";

        private readonly string translationsSearchTranslationsHref =
            "[href*='http://localhost:8080/litecart/admin/?app=translations&doc=search']";

        private readonly string translationsScanFilesHref =
            "[href*='http://localhost:8080/litecart/admin/?app=translations&doc=scan']";

        private readonly string translationsCsvHref =
            "[href*='http://localhost:8080/litecart/admin/?app=translations&doc=csv']";


        private readonly string usersHref = "[href*='http://localhost:8080/litecart/admin/?app=users&doc=users']";

        private readonly string vQmodsHref = "[href*='http://localhost:8080/litecart/admin/?app=vqmods&doc=vqmods']";

        #endregion


        private readonly string serverName = "http://localhost:8080/litecart/admin/login.php";
        private IWebDriver chrome;
    }
}