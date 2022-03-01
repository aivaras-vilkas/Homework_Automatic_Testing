using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest1.HomeWork
{
    internal class HomeWork2
    {
        private static IWebDriver driver;

        [TestCase("Chrome", "Chrome 98 on Windows 10", TestName = "TestChrome")]
        [TestCase("Firefox", "Firefox 97 on Windows 10", TestName = "TestFirefox")]
        public static void Browsers(string Browser, string text)
        {
            if ("Chrome".Equals(Browser))
            {
                driver = new ChromeDriver();
            }

            if ("Firefox".Equals(Browser))
            {
                driver = new FirefoxDriver();
            }


            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            IWebElement actualResult = driver.FindElement(By.CssSelector(".simple-major"));

            Assert.AreEqual(text, actualResult.Text, $"Wrong Browser");
            driver.Quit();

        }
    }
}    
