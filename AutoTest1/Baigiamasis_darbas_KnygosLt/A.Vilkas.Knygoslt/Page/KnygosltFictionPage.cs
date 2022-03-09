using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace A.Vilkas.Knygoslt.Page
{
    public class KnygosltFictionPage : BasePage
    {
        IWebElement SortList => Driver.FindElement(By.Id("form_orderlist"));
        IWebElement CheckboxNew => Driver.FindElement(By.CssSelector("#filters-desktop > div:nth-child(1) > div:nth-child(2) > label"));
        IWebElement NewExpensiveBook => Driver.FindElement(By.CssSelector("#homepage > div.container > div.row.categories > " +
            "div.col-12.col-lg-9.products-holder-wrapper > div:nth-child(4) > div > section > div:nth-child(1)"));
        IWebElement ShopList => Driver.FindElement(By.CssSelector("#type-new-block > div.features.d-" +
            "none.d-xl-block.mb-4 > ul.shop-location-wrapper.product-page"));
        IReadOnlyCollection<IWebElement> list => ShopList.FindElements(By.ClassName("in-store-statuses-text"));


        public KnygosltFictionPage(IWebDriver webdriver) : base(webdriver) { }

        public void FilterSelectByText(string sortBy)
        {
            new SelectElement(SortList).SelectByText(sortBy);
        }

        public void ClickCheckboxNew()
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CheckboxNew));
            CheckboxNew.Click();
        }

        public void SelectNewExpensiveBook()
        {
            NewExpensiveBook.Click();
        }

        public void VerifyIfCanBuyInAnyShop()
        {
            int bookstores = 0;

            foreach (IWebElement book in list) 
            {
                bookstores += 1;
            }

            Assert.IsTrue(bookstores == 3, "Book can't be found in the all the bookstores");
        }
    }
}
