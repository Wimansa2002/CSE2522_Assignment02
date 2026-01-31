using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSE2522_Assignment02.Pages
{
    public class AlertsPage
    {
        private readonly IWebDriver driver;
        public AlertsPage(IWebDriver driver) => this.driver = driver;

        public void Open() => driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");

        public void TriggerAlert() => driver.FindElement(By.Id("alertButton")).Click();
        public void TriggerConfirm() => driver.FindElement(By.Id("confirmButton")).Click();
        public void TriggerPrompt() => driver.FindElement(By.Id("promptButton")).Click();

        public string HandleAlert(bool accept, string? inputText = null)
        {
            // Stabilization: Wait for alert presence to avoid NoAlertPresentException
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(d => {
                try { return d.SwitchTo().Alert(); }
                catch (NoAlertPresentException) { return null; }
            })!;

            string text = alert.Text.Trim(); // Trim handles hidden character mismatches
            if (inputText != null) alert.SendKeys(inputText);

            if (accept) alert.Accept();
            else alert.Dismiss();

            return text;
        }

        public string GetSecondaryAlertText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.SwitchTo().Alert()).Text.Trim();
        }
    }
}