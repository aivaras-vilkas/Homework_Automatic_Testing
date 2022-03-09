using A.Vilkas.Knygoslt.Page;
using A.Vilkas.Knygoslt.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using A.Vilkas.Knygoslt.CustomDriver;

namespace A.Vilkas.Knygoslt.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;

        public static KnygosltFictionPage knygosltFictionPage;
        public static KnygosltLogInPage knygosltLogInPage;
        public static KnygosltCartPage knygosltCartPage;
        public static KnygosltHomePage knygosltHomePage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDrivers.GetChromeDriver();

            knygosltFictionPage = new KnygosltFictionPage(driver);
            knygosltLogInPage = new KnygosltLogInPage(driver);
            knygosltCartPage = new KnygosltCartPage(driver);
            knygosltHomePage = new KnygosltHomePage(driver);

        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
