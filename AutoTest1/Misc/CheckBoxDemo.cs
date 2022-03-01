using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VCSdemo
{
    class CheckboxDemo
    {

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public static void Test1OneCheckbox()
        {
            IWebElement resultElement = driver.FindElement(By.Id("txtAge"));
            ClickOnCheckbox(true);
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same, actual text is {resultElement.Text}");

        }

        [Test]
        public static void Test2ManyCheckboxes()
        {
            ClickOnCheckbox(false);
            IReadOnlyCollection<IWebElement> checkboxes = driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkbox in checkboxes)
            {
                checkbox.Click();
            }
            IWebElement button = driver.FindElement(By.Id("check1"));
            //IWebElement button = driver.FindElement(By.CssSelector("#check1"));
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")), "Text is not correct");
        }

        [Test]
        public static void TestUncheckAll()
        {
            ClickOnCheckbox(false); // nuzymi single checkbox'a, nes su juo blogai veikia kiti;
            IReadOnlyCollection<IWebElement> checkboxes = driver.FindElements(By.CssSelector(".cb1-element"));
            
            IWebElement button = driver.FindElement(By.Id("check1")); // suranda ir paspaudzia mygtuka UnCheckAll
            button.Click();

            foreach (IWebElement checkbox in checkboxes) // suka foreach cickla su kiekvienu checkboxes elementu checkbox;
            {
                Assert.IsTrue(checkbox.Selected.Equals(false), $"One of the checkbox is selected"); // patikrina ar kiekvienas checkbox yra unchecked
            }
            Assert.IsTrue("Check All".Equals(button.GetAttribute("value")), "Text is not correct"); // patikrina ar pasikeite mygtuvas Uncheck All -> Check All
        }

        private static void ClickOnCheckbox(bool shouldBeCheck)
        {
            IWebElement firstCheckbox = driver.FindElement(By.Id("isAgeSelected"));
            if (firstCheckbox.Selected != shouldBeCheck)
            {
                firstCheckbox.Click();
            }
        }
    }
}