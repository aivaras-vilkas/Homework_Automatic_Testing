using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTest1.Misc
{
    internal class Knygos_bandymas
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://knygos.lt/";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public static void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d => d.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow")).Displayed);
            IWebElement AcceptCookies = driver.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow"));
            AcceptCookies.Click();

            IWebElement InputSearchField = driver.FindElement(By.CssSelector("#product-search"));
            InputSearchField.Click();
            InputSearchField.Clear();
            InputSearchField.SendKeys("tada pasirodei tu");//"Mirties pabaiga- Liu Cixin//Geroji sesuo
            IWebElement ButtonSearchField = driver.FindElement(By.CssSelector("#main-search-form > button"));
            ButtonSearchField.Click();

            IWebElement Element1 = driver.FindElement(By.CssSelector("#homepage > div.container > div > div.col-12.col-lg-9.products-holder-wrapper > section:nth-child(2) > div:nth-child(1) > div.col-12.col-md-8.col-xl-6.mb-3.mb-lg-0 > div > h2 > a"));// reikia pakeist i pirma elementa;
            Element1.Click();


            IWebElement AddToCart = driver.FindElement(By.Id("add_to_cart_single_add_to_cart_book2"));
            AddToCart.Click();

            wait.Until(d => d.FindElement(By.CssSelector("#product-page > div:nth-child(5) > div.row.single-product-wrapper > div.col-12.about-product-wrapper > div > div.col-12.col-xl-9.mb-3 > div > div.col-12.col-xl-8.book-descript-wrapper.pl-xl-5.order-0.order-xl-1 > div.book-title.mb-2.mb-lg-3 > h1 > span:nth-child(1)")).Displayed);
            IWebElement RealName = driver.FindElement(By.CssSelector("#product-page > div:nth-child(5) > div.row.single-product-wrapper > div.col-12.about-product-wrapper > div > div.col-12.col-xl-9.mb-3 > div > div.col-12.col-xl-8.book-descript-wrapper.pl-xl-5.order-0.order-xl-1 > div.book-title.mb-2.mb-lg-3 > h1 > span:nth-child(1)"));
            Assert.IsTrue((RealName.Text).ToLower().Contains(("Tada pasirodei tu").ToLower()), "Wrong book found");

            /*wait.Until(d => d.FindElement(By.CssSelector("#product-page > div:nth-child(5) > div.row.single-product-wrapper > div.col-12.about-product-wrapper > div > div.col-12.col-xl-9.mb-3 > div > div.col-12.col-xl-8.book-descript-wrapper.pl-xl-5.order-0.order-xl-1 > div.book-title.mb-2.mb-lg-3 > div > a > span")).Displayed);
            IWebElement AuthorName = driver.FindElement(By.CssSelector("#product-page > div:nth-child(5) > div.row.single-product-wrapper > div.col-12.about-product-wrapper > div > div.col-12.col-xl-9.mb-3 > div > div.col-12.col-xl-8.book-descript-wrapper.pl-xl-5.order-0.order-xl-1 > div.book-title.mb-2.mb-lg-3 > div > a > span"));
            Assert.IsTrue((AuthorName.Text).ToLower().Contains("ada pasirodei tu"), "Wrong author");*/

            //Assert.AreEqual("Geroji sesuo", RealName.Text, "Wrong book found");

            IWebElement GoToCart = driver.FindElement(By.CssSelector("#post-add-to-cart-modal > div > div > div.modal-footer.border-top-0.justify-content-center > a.btn.btn-primary"));
            wait.Until(d => (GoToCart).Displayed);
            GoToCart.Click();

            wait.Until(d => d.FindElement(By.XPath("/html/body/main/div/div[3]/div[1]/div/div/form/div[1]/div[2]/div[3]/div/input")).Displayed);
            IWebElement AmmountInput = driver.FindElement(By.XPath("/html/body/main/div/div[3]/div[1]/div/div/form/div[1]/div[2]/div[3]/div/input"));
            AmmountInput.Click();
            AmmountInput.Clear();
            AmmountInput.SendKeys("5");

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // after change;

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#cart-items > div.row.no-gutters.border-bottom.py-2.k-cart-item > div.col.d-none.d-md-flex.align-self-center.text-center > div > p")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > main > div > div:nth-child(3) > div.col.mb-3 > div > div:nth-child(1) > div > div:nth-child(2) > div:nth-child(1) > div.col.text-right")));

            //wait.Until(d => d.FindElement(By.CssSelector("#cart-items > div.row.no-gutters.border-bottom.py-2.k-cart-item > div.col.d-none.d-md-flex.align-self-center.text-center > div > p")).ExpectedToBeClickable());

            IWebElement Price = driver.FindElement(By.CssSelector("#cart-items > div.row.no-gutters.border-bottom.py-2.k-cart-item > div.col.d-none.d-md-flex.align-self-center.text-center > div > p"));
            double OneUnitPrice = double.Parse(Price.Text.Replace("€", "").Replace(" ", "").Replace(",", ".").Replace("d", ""));
            IWebElement Prices = driver.FindElement(By.CssSelector("body > main > div > div:nth-child(3) > div.col.mb-3 > div > div:nth-child(1) > div > div:nth-child(2) > div:nth-child(1) > div.col.text-right"));
            double ManyUnitsPrice = double.Parse(Prices.Text.Replace("€", "").Replace(" ", "").Replace(",", ".").Replace("d", ""));
            Assert.AreEqual(OneUnitPrice*4, Math.Round(ManyUnitsPrice,2), "Neatitinka kainos");



        }
        [Test]
        public static void Test2() // Error message wrong password
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(d => d.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow")).Displayed);
            IWebElement AcceptCookies = driver.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow"));
            AcceptCookies.Click();

            IWebElement LogIn = driver.FindElement(By.CssSelector("#hr-1 > div.col.col-md-2.col-lg-auto.col-xl-4.col-xxl-3.order-2.order-md-3.d-flex.justify-content-end.user-menu > div > div.col.col-lg-auto.user-menu-item.profile-menu-item"));
            LogIn.Click();

            IWebElement EmailInputField = driver.FindElement(By.Name("user_login"));
            IWebElement PasswordInputField = driver.FindElement(By.Name("user_password"));
            IWebElement LogInButton = driver.FindElement(By.Name("form_submit"));

            EmailInputField.Clear();
            EmailInputField.SendKeys("abcdefgh@email.lt");
            PasswordInputField.Clear();
            PasswordInputField.SendKeys("123456");
            LogInButton.Click();

            wait.Until(d => d.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div")).Displayed);  ///ar atsiranda klaidingi duomenys ivedus tik email
            IWebElement ErrorMessage = driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div"));
            Assert.IsTrue(ErrorMessage.Text.Equals("Klaidingi duomenys."),"Wrong Error message");
        }
        [Test]
        public static void Test3() // Error message wrong password
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(d => d.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow")).Displayed);
            IWebElement AcceptCookies = driver.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow"));
            AcceptCookies.Click();

            IWebElement InputSearchField = driver.FindElement(By.CssSelector("#product-search"));
            InputSearchField.Click();
            InputSearchField.Clear();
            InputSearchField.SendKeys("Mirties pabaiga");//"Mirties pabaiga- Liu Cixin//Geroji sesuo
            IWebElement ButtonSearchField = driver.FindElement(By.CssSelector("#main-search-form > button"));
            ButtonSearchField.Click();

           // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#homepage > div.container > div > div.col-12.col-lg-9.products-holder-wrapper > section:nth-child(2)")));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("#homepage > div.container > div > div.col-12.col-lg-9.products-holder-wrapper > section:nth-child(2)")));

            IWebElement BookList = driver.FindElement(By.CssSelector("#homepage > div.container > div > div.col-12.col-lg-9.products-holder-wrapper > section:nth-child(2)"));
            
            IReadOnlyCollection<IWebElement> list = BookList.FindElements(By.TagName("h2")); // Susikuriu komponentu rinkini ir skirstau pagal, ClassName; (taip tiksliausiai pasiekimas buvo tekstas);

            foreach (IWebElement item in list)
            {
                /*if (item.Text.Contains(""))
                {
                    item.Click();
                    break;
                }*/
                item.Click();
            }
            

        }

        [Test]
        public static void Test4() // Error message wrong password
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d => d.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow")).Displayed);
            IWebElement AcceptCookies = driver.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow"));
            AcceptCookies.Click();

            wait.Until(d => d.FindElement(By.CssSelector("#static-menu > li.menu-item.visos-knygos")).Displayed);
            IWebElement MenuAllBooks = driver.FindElement(By.CssSelector("#static-menu > li.menu-item.visos-knygos"));
            MenuAllBooks.Click();
            
            wait.Until(d => d.FindElement(By.CssSelector("#sideNav > ul > li:nth-child(13) > a")).Displayed);
            IWebElement Grozine = driver.FindElement(By.CssSelector("#sideNav > ul > li:nth-child(13) > a"));
            Grozine.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("form_orderlist")));
            new SelectElement(driver.FindElement(By.Id("form_orderlist"))).SelectByText("Brangiausios");

            wait.Until(d => d.FindElement(By.CssSelector("#filters-desktop > div:nth-child(1) > div:nth-child(2) > label")).Displayed);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#filters-desktop > div:nth-child(1) > div:nth-child(2) > label")));
            IWebElement CheckboxNew = driver.FindElement(By.CssSelector("#filters-desktop > div:nth-child(1) > div:nth-child(2) > label"));

            CheckboxNew.Click();

            IWebElement Book1 = driver.FindElement(By.CssSelector("#homepage > div.container > div.row.categories > div.col-12.col-lg-9.products-holder-wrapper > div:nth-child(4) > div > section > div:nth-child(1)"));
            Book1.Click();

            IWebElement ShopList = driver.FindElement(By.CssSelector("#type-new-block > div.features.d-none.d-xl-block.mb-4 > ul.shop-location-wrapper.product-page"));

            IReadOnlyCollection<IWebElement> list = ShopList.FindElements(By.ClassName("in-store-statuses-text"));

            foreach (IWebElement book in list) //checkinam ar sia knyga galima rasti visose parduotuvese
            {
                Assert.IsTrue(book.Text.Contains("Yra pakankama") || book.Text.Contains("Liko nedaug"), "Book can't be bought in all the bookstores");

            }
        }
    }
}

