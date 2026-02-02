using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;
using System.Threading;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class AlertsTests : TestBase
    {
        [Test]
        [Property("TestName", "TC004_1 - Alerts - Verification of the Alerts page")]
        public void TC004_1_VerifyAlertsPage()
        {
            var page = new AlertsPage(driver!);
            page.Open();
            Assert.That(page.AreElementsDisplayed(), Is.True,
                "Alert, Confirm and Prompt buttons should be displayed");
        }

        [Test]
        [Property("TestName", "TC004_2 - Alerts - Verification of the Alert text")]
        public void TC004_2_AlertText()
        {
            var page = new AlertsPage(driver!);
            page.Open();
            page.TriggerAlert();
            string text = page.HandleAlert(true).Replace("\r\n", " ").Replace("\n", " ");
            Assert.That(text, Is.EqualTo("Today is a working day. Or less likely a holiday.").IgnoreCase);
        }

        [Test]
        [Property("TestName", "TC004_3 - Alerts - Verification of the Alert text depending on the first alert")]
        public void TC004_3_ConfirmAlert_Accept()
        {
            var page = new AlertsPage(driver!);
            page.Open();

            page.TriggerConfirm();
            string confirmText = page.HandleAlert(true);
            Assert.That(confirmText, Does.Contain("Friday").IgnoreCase,
                "First alert should ask about Friday");

            Thread.Sleep(500);

            string secondAlertText = page.GetSecondaryAlertText();
            Assert.That(secondAlertText, Is.EqualTo("Yes"),
                "Second alert should show 'Yes' when first alert is accepted");
            page.HandleAlert(true);
        }

        [Test]
        [Property("TestName", "TC004_3 - Alerts - Verification of the Alert text depending on the first alert (Decline)")]
        public void TC004_3_ConfirmAlert_Decline()
        {
            var page = new AlertsPage(driver!);
            page.Open();

            page.TriggerConfirm();
            page.HandleAlert(false);

            Thread.Sleep(500);

            string secondAlertText = page.GetSecondaryAlertText();
            Assert.That(secondAlertText, Is.EqualTo("No"),
                "Second alert should show 'No' when first alert is declined");
            page.HandleAlert(true);
        }

        [Test]
        [Property("TestName", "TC004_4 - Alerts - Verification of the Alert prompt")]
        public void TC004_4_PromptInput()
        {
            var page = new AlertsPage(driver!);
            page.Open();

            page.TriggerPrompt();
            page.HandleAlert(true, "AutomationUser");
            Thread.Sleep(500);
            Assert.That(page.GetSecondaryAlertText(), Is.EqualTo("User value: AutomationUser"));
            page.HandleAlert(true);
        }

        [Test]
        [Property("TestName", "TC004_4 - Alerts - Verification of the Alert prompt (Decline)")]
        public void TC004_4_PromptInput_Decline()
        {
            var page = new AlertsPage(driver!);
            page.Open();

            page.TriggerPrompt();
            page.HandleAlert(false, "TestInput");

            Thread.Sleep(500);

            string secondAlertText = page.GetSecondaryAlertText();
            Assert.That(secondAlertText, Is.EqualTo("User value: no answer"),
                "Second alert should show 'User value: no answer' when prompt is declined");
            page.HandleAlert(true);
        }
    }
}