using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSE2522_Assignment02.Pages
{
    public class ClientSideDelayPage
    {
        private readonly IWebDriver driver;
        public ClientSideDelayPage(IWebDriver driver) => this.driver = driver;

        private IWebElement TriggerButton => driver.FindElement(By.Id("ajaxButton"));
        private IWebElement Spinner => driver.FindElement(By.Id("spinner"));
        private By ResultBanner = By.CssSelector(".bg-success");

        public void Open() => driver.Navigate().GoToUrl("https://uitestingplayground.com/clientdelay");
        public void ClickTrigger() => TriggerButton.Click();
        public bool IsSpinnerVisible() => Spinner.Displayed;

        public string GetResultText()
        {
            // Requirement: Wait up to 20 seconds for logic to complete
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(d => {
                try
                {
                    var e = d.FindElement(ResultBanner);
                    return e.Displayed ? e : null;
                }
                catch (NoSuchElementException) { return null; }
            });

            // .Trim() fixes the "Expected 34 but was 35" length error
            return element!.Text.Trim();
        }
    }
}