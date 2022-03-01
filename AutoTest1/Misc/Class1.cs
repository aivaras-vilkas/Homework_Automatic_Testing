using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AutoTest1
{
    public class Class1
    {
        [Test]
        public static void FirstTest() 
        {
            int leftover = 5 % 2;
            //Assert.AreEqual(0, leftover, "5 is not even");   
            Assert.IsTrue(0 == leftover, "5 is not even");
        }
        [Test]
        public static void TestNowIs19h()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.AreEqual(19, CurrentTime.Hour, "Now is not 19h");
        }
        [Test]
        public static void Test995dalyba() 
        {
            int leftover_995 = 995 % 3;
            Assert.AreEqual(0, leftover_995, "995 nesidalija is 3");
        }
        [Test]
        public static void TestArTreciadienis()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Wednesday, CurrentTime.DayOfWeek, "Something is wrong!!!");
        }
        [Test]
        public static void TestWait()
        {
            Thread.Sleep(5000);
        }
        [Test]
        public static void TestChrome()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            chrome.Manage().Window.Maximize();
            IWebElement inputField = chrome.FindElement(By.Id("login-username"));
            IWebElement NextButton = chrome.FindElement(By.CssSelector("#login-signin"));
            inputField.SendKeys("test");
            NextButton.Click();
            //chrome.Quit();
        }




    }
}
