using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest1.Page
{
    public class CheckBoxPage
    {
        private static IWebDriver driver;

        private IWebElement resultElement => driver.FindElement(By.Id("txtAge")); // tekstas parasantis ar pavyko pazymeti checkbox'a;        
        private IWebElement firstCheckbox => driver.FindElement(By.Id("isAgeSelected")); // vieno checkbox mygtukas;
        private IReadOnlyCollection<IWebElement> checkboxes => driver.FindElements(By.CssSelector(".cb1-element")); // checkbox'u rinkinys;
        private IWebElement button => driver.FindElement(By.Id("check1")); // CheckAll/UnCheckAll mygtukas;
        
        public CheckBoxPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ClickOnCheckbox(bool shouldBeCheck) // pazymi/atzymi pirma Single Checkbox'a;
        {
            if (firstCheckbox.Selected != shouldBeCheck)
            {
                firstCheckbox.Click();
            }
        }

        public void IfOneCheckBoxChecked() 
        {
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same, actual text is {resultElement.Text}"); // patikrina ar atsiranda tekstas;
        }

        public void ClickMultipleCheckboxes()  // pazymi rinkinio checkboxus;
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                checkbox.Click();
            }
        }

        public void CheckUnCheckAll() // patikrina ar mygtuko uzrasas pasikeite i "UnCheckAll";
        {
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")), "Text is not correct");
        }

        public void PressCheckAll() // paspaudzia CheckAll mygtuka;
        {
            button.Click();
        }

        public void CheckIfUnselected() // keliauja per rinkinio checkboxus ir tikrina ar visi atzymeti;
        {
            foreach (IWebElement checkbox in checkboxes) // suka foreach cickla su kiekvienu checkboxes elementu checkbox;
            {
                Assert.IsTrue(checkbox.Selected.Equals(false), $"One of the checkbox is selected"); // patikrina ar kiekvienas checkbox yra unchecked
            }
        }

        public void CheckCheckAll() // patikrina ar mygtuko tekstas pasikeite i "CheckAll";
        {
            Assert.IsTrue("Check All".Equals(button.GetAttribute("value")), "Text is not correct"); // patikrina ar pasikeite mygtuvas Uncheck All -> Check All
        }
    }

}
