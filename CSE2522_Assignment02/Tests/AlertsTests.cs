using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class AlertsTests : TestBase
    {
        [Test]
        [Property("TestName", "TC004_2 - Alerts - Verification of the Alert text")]
        public void TC004_2_AlertText()
        {
            var page = new AlertsPage(driver!);
            page.Open();
            page.TriggerAlert();
            string text = page.HandleAlert(true).Replace("\r\n", " ").Replace("\n", " "); ;
            Assert.That(text, Is.EqualTo("Today is a working day or less likely a holiday")); 
        }

        [Test]
        [Property("TestName", "TC004_4 - Alerts - Verification of the Alert prompt")]
        public void TC004_4_PromptInput()
        {
            var page = new AlertsPage(driver!);
            page.Open();

            // Scenario: User enters text
            page.TriggerPrompt();
            page.HandleAlert(true, "AutomationUser");
            Assert.That(page.GetSecondaryAlertText(), Is.EqualTo("user value AutomationUser"));
            page.HandleAlert(true); // Close the resulting confirm alert
        }
    }
}
