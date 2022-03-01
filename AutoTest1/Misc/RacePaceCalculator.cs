using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest1
{
    internal class RacePaceCalculator
    {
        [Test]
        public static void RacePaceCalc() 
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.active.com/fitness/calculators/pace";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement PopUp = driver.FindElement(By.ClassName("icon-awesome-close-btn"));
            PopUp.Click();
            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("#google_ads_iframe_\/21719121593\/ACT\/Calculators_7__container__ > span")).Displayed);
            driver.FindElement(By.CssSelector("#google_ads_iframe_\/21719121593\/ACT\/Calculators_7__container__ > span")).Click();*/

            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("#google_ads_iframe_\/21719121593\/ACT\/Calculators_7__container__ > span")).Displayed);
            driver.FindElement(By.Id("#google_ads_iframe_\/21719121593\/ACT\/Calculators_7__container__ > span")).Click();*/

            IWebElement chooseDistance = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span"));
           

            chooseDistance.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var selectDistance = new SelectElement(chooseDistance);
            selectDistance.SelectByValue("Kilometers");

        }
    }
}
