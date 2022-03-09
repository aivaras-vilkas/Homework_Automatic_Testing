using NUnit.Framework;
using OpenQA.Selenium;

namespace A.Vilkas.Knygoslt.Page
{
    public class KnygosltLogInPage : BasePage
    {
        IWebElement EmailInputField => Driver.FindElement(By.Name("user_login"));
        IWebElement PasswordInputField => Driver.FindElement(By.Name("user_password"));
        IWebElement LogInButton => Driver.FindElement(By.Name("form_submit"));
        IWebElement ErrorMessage => Driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div/div/div/div"));

        public KnygosltLogInPage(IWebDriver webdriver) : base(webdriver) { }

        public void InputEmail(string email) 
        {
            EmailInputField.Clear();
            EmailInputField.SendKeys(email);
        }
        public void InputPassword(string password)
        {
            PasswordInputField.Clear();
            PasswordInputField.SendKeys(password);
        }

        public void PressLogInButton() 
        {
            LogInButton.Click();
        }

        public void ErrorMessageChecked() 
        {
            Assert.IsTrue(ErrorMessage.Text.Equals("Klaidingi duomenys."), "Wrong error message");
        }
    }
}
