using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutoTest1
{
    internal class _1Paskaita
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
        
        [Test]
        public static void TestForTwoFieldForm1() // 1. Tikrinamas ar 2 + 2 = 4?
        {
           
            string a = "2";
            string b = "2";
            string sumAB = "4";
            IWebElement inputFieldA = driver.FindElement(By.Id("sum1"));
            inputFieldA.Clear();
            inputFieldA.SendKeys(a);
            IWebElement inputFieldB = driver.FindElement(By.Id("sum2"));
            inputFieldB.Clear();
            inputFieldB.SendKeys(b);
            IWebElement GetTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotalButton.Click();
            IWebElement Result = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sumAB, Result.Text, "Error.Sum of 2 + 2 is not equal 4.");
        }
        [Test]
        public static void TestForTwoFieldForm2() // 2. Tikrinamas ar a + b = -2?
        {
            string a = "-5";
            string b = "3";
            string sumAB = "-2";
            IWebElement inputFieldA = driver.FindElement(By.Id("sum1"));
            inputFieldA.Clear();
            inputFieldA.SendKeys(a);
            IWebElement inputFieldB = driver.FindElement(By.Id("sum2"));
            inputFieldB.Clear();
            inputFieldB.SendKeys(b);
            IWebElement GetTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotalButton.Click();
            IWebElement Result = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sumAB, Result.Text, "Error.Sum of -5 and 3 is not equal -2.");

        }
        [Test]
        public static void TestForTwoFieldForm3() // 3. Tikrinamas, koks rezultas i laukelius ivedus raides: a + b?
        {
            string a = "a";
            string b = "b";
            string sumAB = "NaN"; // NaN - not a number klaida;
            IWebElement inputFieldA = driver.FindElement(By.Id("sum1"));
            inputFieldA.Clear();
            inputFieldA.SendKeys(a);
            IWebElement inputFieldB = driver.FindElement(By.Id("sum2"));
            inputFieldB.Clear();
            inputFieldB.SendKeys(b);
            IWebElement GetTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotalButton.Click();
            IWebElement Result = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sumAB, Result.Text, "Error. Wrong format and no error message given");
        }
        
    }
}
