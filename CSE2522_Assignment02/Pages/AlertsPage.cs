using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CSE2522_Assignment02.Pages
{
    public class AlertsPage
    {
        private readonly IWebDriver driver;

        public AlertsPage(IWebDriver driver) => this.driver = driver;

        private IWebElement AlertButton => driver.FindElement(By.Id("alertButton"));
        private IWebElement ConfirmButton => driver.FindElement(By.Id("confirmButton"));
        private IWebElement PromptButton => driver.FindElement(By.Id("promptButton"));

        public void Open() => driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");

        public bool AreElementsDisplayed() =>
            AlertButton.Displayed && ConfirmButton.Displayed && PromptButton.Displayed;

        public void TriggerAlert() => AlertButton.Click();

        public void TriggerConfirm() => ConfirmButton.Click();

        public void TriggerPrompt() => PromptButton.Click();

        public string HandleAlert(bool accept, string? inputText = null)
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;

            if (inputText != null)
            {
                alert.SendKeys(inputText);
            }

            if (accept)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

            return alertText;
        }

        public string GetSecondaryAlertText()
        {
            // Wait for the second alert to appear
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => IsAlertPresent());

            IAlert alert = driver.SwitchTo().Alert();
            return alert.Text;
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
    }
}