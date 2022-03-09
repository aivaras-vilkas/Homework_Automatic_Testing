using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace A.Vilkas.Knygoslt.Page
{
    public class KnygosltCartPage : BasePage
    {
        IWebElement FirstElement => Driver.FindElement(By.CssSelector("#homepage > div.container > div > div.col-12." +
            "col-lg-9.products-holder-wrapper > " +
            "section:nth-child(2) > div:nth-child(1) > div.col-12.col-md-8.col-xl-6.mb-3.mb-lg-0 > div > h2 > a"));
        IWebElement AddToCart => Driver.FindElement(By.Id("add_to_cart_single_add_to_cart_book2"));
        
        IWebElement GoToCart => Driver.FindElement(By.CssSelector("#post-add-to-cart-modal > div > div > div.modal-f" +
            "ooter.border-top-0.justify-content-center " +
            "> a.btn.btn-primary"));
        IWebElement InputBookAmount => Driver.FindElement(By.XPath("//input[@class='form-control text-center p-1 k-number-input']"));

        IWebElement PriceOneBook => Driver.FindElement(By.CssSelector("#cart-items > div.row.no-gutters.border-bottom.py-2.k-cart-item > " +
            "div.col.d-none.d-md-flex." +
            "align-self-center.text-center > div > p"));
        IWebElement PricesNBooks => Driver.FindElement(By.CssSelector("body > main > div > div:nth-child(3) > div.col." +
            "mb-3 > div > div:nth-child(1) " +
            "> div > div:nth-child(2) > div:nth-child(1) > div.col.text-right"));
        IWebElement TooManyErrorMessage => Driver.FindElement(By.CssSelector("body > main > div > div.alert.alert-danger"));
        IWebElement RemoveFromCartButton => Driver.FindElement(By.XPath("//button[@class='btn-sm btn']"));


        public KnygosltCartPage(IWebDriver webdriver) : base(webdriver) { }

        public void AddFirstSearchResultToCart()
        {
            FirstElement.Click();
            AddToCart.Click();
        }
        
        public void GoesToCart()
        {
            GetWait().Until(d => (GoToCart.Displayed));
            GoToCart.Click();
        }
        public void InputAmount(string amount)
        {
            GetWait().Until(d => (InputBookAmount.Displayed));
            InputBookAmount.Click();
            InputBookAmount.Clear();
            InputBookAmount.SendKeys(amount);
        }

        public void VerifyThePriceCalculation (string amount)
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PriceOneBook));
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PricesNBooks));
            double BookPrice = double.Parse(PriceOneBook.Text.Replace("€", "").Replace(" ", "").Replace(",", ".").Replace("d", ""));
            double BooksNPrices = double.Parse(PricesNBooks.Text.Replace("€", "").Replace(" ", "").Replace(",", ".").Replace("d", ""));
            Assert.AreEqual(Math.Round((BookPrice * Convert.ToDouble(amount)),2), Math.Round(BooksNPrices,2), 
                "Prices do not match. Price calculations is faulty");
        }
        
        public void RemoveFromCart() 
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(RemoveFromCartButton));
            RemoveFromCartButton.Click();
        }
               
        public void VerifyIfCanBuy2000Books() 
        {
            Assert.IsTrue(TooManyErrorMessage.Displayed, "No error message misssing. You can 2000 books");
        }

        public void VerifyIfCanBuyNBooksWithNEUR(double MoneyForBooks)
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PricesNBooks));
            double BooksNPrices = double.Parse(PricesNBooks.Text.Replace("€", "").Replace(" ", "").Replace(",", ".").Replace("d", ""));
            Assert.IsTrue(MoneyForBooks > BooksNPrices, "Cant buy 4 books with 80 EUR");
        }

    }
}
