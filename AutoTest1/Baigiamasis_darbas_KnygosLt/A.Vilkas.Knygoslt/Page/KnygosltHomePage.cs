using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace A.Vilkas.Knygoslt.Page
{
    public class KnygosltHomePage : BasePage
    {
        private const string PageAddress = "https://www.knygos.lt/";
        IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector("#consent > div.cc-window.cc-banner.cc" +
            "-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow"));
        IWebElement InputSearchField => Driver.FindElement(By.CssSelector("#product-search"));
        IWebElement ButtonSearchField => Driver.FindElement(By.CssSelector("#main-search-form > button"));
        IWebElement MenuAllBooks => Driver.FindElement(By.CssSelector("#static-menu > li.menu-item.visos-knygos"));
        IWebElement FictionBooks => Driver.FindElement(By.CssSelector("#sideNav > ul > li:nth-child(13) > a"));
        IWebElement LogIn => Driver.FindElement(By.CssSelector("#hr-1 > div.col.col-md-2.col-lg-auto.col-xl-4.col" +
            "-xxl-3.order-2.order-md-3.d-flex.justify-content-end.user-menu > div > div.col.col-lg-auto.user-menu-item.profile-menu-item"));

        public KnygosltHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void AcceptCookies()
        {
            if (AcceptCookiesExists(By.CssSelector("#consent > div.cc-window.cc-banner.cc" +
            "-type-opt-in.cc-theme-custom.cc-bottom > div.cc-compliance.cc-highlight > a.cc-btn.cc-allow")))
                AcceptCookiesButton.Click();
        }

        private static bool AcceptCookiesExists(By selector)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(d =>d.FindElement(selector).Displayed);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Cookies accepted");
            }
            return false;

        }

        public void SearchByText(string text)
        {
            InputSearchField.Clear();
            InputSearchField.SendKeys(text);
            ButtonSearchField.Click();
        }

        public void ChooseFictionBooks()
        {
            GetWait().Until(d => d.FindElement(By.CssSelector("#static-menu > li.menu-item.visos-knygos")).Displayed);
            MenuAllBooks.Click();
            GetWait().Until(d => d.FindElement(By.CssSelector("#sideNav > ul > li:nth-child(13) > a")).Displayed);
            FictionBooks.Click();
        }

        public void GoToLogIn() 
        {
            LogIn.Click();
        }
    }
}
