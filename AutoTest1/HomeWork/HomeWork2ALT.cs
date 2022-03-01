using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace AutoTest1.HomeWork
{
    internal class HomeWork2ALT
    {
        private static IWebDriver driver;

        [TestCase("Chrome", "Chrome 98", TestName = "ChromeTest")]
        [TestCase("Firefox", "Firefox 97", TestName = "FireFoxTest")]

        public static void BrowserTest(string Browser, string browserInfo)
        {
            if ("Chrome".Equals(Browser))
            {
                driver = new ChromeDriver();
            }

            if ("Firefox".Equals(Browser))
            {
                driver = new FirefoxDriver();
            }

            driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            driver.Manage().Window.Maximize();

            IWebElement listUl = driver.FindElement(By.CssSelector("#content-base > section:nth-child(2) > div > div > div.user-agent-parse-results > div.parse-elements > div.col.col-2 > div > ul"));

            IReadOnlyCollection<IWebElement> list = listUl.FindElements(By.ClassName("value")); // Susikuriu komponentu rinkini ir skirstau pagal, ClassName; (taip tiksliausiai pasiekimas buvo tekstas);

            int i = 0; // susikuriu kintamaji i indeksavimui foreach cikle;

            foreach (IWebElement li in list) // cikle keliauja per rinkini;
            {
                i++;  // tik veikia kaip indeksas;
                if (i == 1) // kai rinkinio narys pagal indeksa 1, tuomet tikrina ar teisingai mato naudojama narsykle
                    if (li.Text == browserInfo)
                        break;
                    else
                        Assert.Fail("Wrong browser"); //  nezinau ar gera praktika, bet ismeta klaida;

            }

            driver.Quit();
        }
        
    }
}


