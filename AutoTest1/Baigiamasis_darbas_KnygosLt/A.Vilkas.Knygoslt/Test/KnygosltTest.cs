using NUnit.Framework;

namespace A.Vilkas.Knygoslt.Test
{
    public class KnygosltTest : BaseTest 
    {
        [TestCase("Mirties pabaiga","2", TestName = "TestPriceCalculation2Books")]
        [TestCase("Mirties pabaiga","5", TestName = "TestPriceCalculation5Books")]
        [TestCase("Mirties pabaiga","7", TestName = "TestPriceCalculation7Books")]

        public static void TestPriceCalculation(string text,string amount) 
        {
            knygosltHomePage.NavigateToPage();
            knygosltHomePage.AcceptCookies();   
            knygosltHomePage.SearchByText(text);
            knygosltCartPage.AddFirstSearchResultToCart();
            knygosltCartPage.GoesToCart();
            knygosltCartPage.InputAmount(amount);
            knygosltCartPage.VerifyThePriceCalculation(amount);
            knygosltCartPage.RemoveFromCart();
        }

        [Test]
        public static void VeryfyingIfCanBuy2000Books() 
        {
            knygosltHomePage.NavigateToPage();
            knygosltHomePage.AcceptCookies();
            knygosltHomePage.SearchByText("Mirties pabaiga");
            knygosltCartPage.AddFirstSearchResultToCart();
            knygosltCartPage.GoesToCart();
            knygosltCartPage.InputAmount("2000");
            knygosltCartPage.VerifyIfCanBuy2000Books();
            knygosltCartPage.RemoveFromCart();
        }

        [Test]
        public static void VeryfyingIfCanBuy4BooksWith80EUR() 
        {
            knygosltHomePage.NavigateToPage();
            knygosltHomePage.AcceptCookies();
            knygosltHomePage.SearchByText("Mirties pabaiga");
            knygosltCartPage.AddFirstSearchResultToCart();
            knygosltCartPage.GoesToCart();
            knygosltCartPage.InputAmount("4");
            knygosltCartPage.VerifyIfCanBuyNBooksWithNEUR(80);
            knygosltCartPage.RemoveFromCart();
        }

        [Test]
        public static void TestLogInErrorAppears() 
        {
            knygosltHomePage.NavigateToPage();
            knygosltHomePage.AcceptCookies();
            knygosltHomePage.GoToLogIn();
            knygosltLogInPage.InputEmail("abcdefgh@email.com");
            knygosltLogInPage.InputPassword("abcdefghi");
            knygosltLogInPage.PressLogInButton();
            knygosltLogInPage.ErrorMessageChecked();
        }

        [Test]
        public static void VerifyIfCanBuyNewExpensiveBookInAnyStore() 
        {
            knygosltHomePage.NavigateToPage();
            knygosltHomePage.AcceptCookies();
            knygosltHomePage.ChooseFictionBooks();
            knygosltFictionPage.ClickCheckboxNew();
            knygosltFictionPage.FilterSelectByText("Brangiausios");
            knygosltFictionPage.SelectNewExpensiveBook();
            knygosltFictionPage.VerifyIfCanBuyInAnyShop();

        }

    }
}
