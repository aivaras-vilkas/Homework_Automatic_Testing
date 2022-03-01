using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutoTest1
{
    internal class _1PaskaitaNdUp
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]

        [Test]
        public static void TestForTwoFieldForm1(string Firstp, string SecondP, string SumResult)
        {

            IWebElement inputFieldA = driver.FindElement(By.Id("sum1"));
            inputFieldA.Clear();
            inputFieldA.SendKeys(Firstp);
            IWebElement inputFieldB = driver.FindElement(By.Id("sum2"));
            inputFieldB.Clear();
            inputFieldB.SendKeys(SecondP);
            IWebElement GetTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotalButton.Click();
            IWebElement Result = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(SumResult, Result.Text, "Error. Expected different result");
        }
        

    }
}
