using AutoTest1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest1.Test
{
    public class CheckBoxTest
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

        [TestCase(true, TestName = "Test1CheckSingleBox")]
        
        public static void Test1CheckSingleBox(bool shouldBeCheck) // 1 dalis. Single Box check;
        {
            CheckBoxPage page = new CheckBoxPage(driver);

            page.ClickOnCheckbox(shouldBeCheck); // pazymi Single Checkbox
            page.IfOneCheckBoxChecked(); //Patikrina ar atsirado Success uzrasas;
        }

        [TestCase(false, TestName = "Test2CheckManyCheckBoxes")]

        public static void Test2CheckManyCheckBoxes(bool shouldBeCheck) 
        {
            CheckBoxPage page = new CheckBoxPage(driver);

            page.ClickOnCheckbox(shouldBeCheck);
            page.ClickMultipleCheckboxes(); // paspaudzia/pazymi checkbox'us;
            page.CheckUnCheckAll(); // patikrina ar mygtuko uzrasas pasikeite i "UnCheckAll";

        }

        [TestCase(false, TestName = "Test3UnCheckManyCheckBoxes")]

        public static void Test3UnCheckManyCheckBoxes(bool shouldBeCheck)
        {
            CheckBoxPage page = new CheckBoxPage(driver);

            page.ClickOnCheckbox(shouldBeCheck);
            page.ClickMultipleCheckboxes(); // paspaudzia/pazymi checkbox'us;
            page.CheckCheckAll(); // patikrina ar mygtuko uzrasas pasikeite i "UnCheckAll";

        }
    }
}
