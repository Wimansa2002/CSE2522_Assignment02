using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class SampleAppTests : TestBase
    {
        [Test]
        [Property("TestName", "TC002_1 - Sample App - Verification of the sample app page")]
        public void TC002_1_VerifyPageElements()
        {
            var page = new SampleAppPage(driver!);
            page.Open();
            Assert.That(page.AreElementsDisplayed(), Is.True, "Login elements are not displayed.");
        }

        [Test]
        [Property("TestName", "TC002_2 - Sample App - Verification of a successful login")]
        public void TC002_2_SuccessfulLogin()
        {
            var page = new SampleAppPage(driver!);
            page.Open();
            page.Login("Wimansa", "pwd");
            Assert.That(page.GetStatusMessage(), Is.EqualTo("Welcome, Wimansa!"));
        }

        [Test]
        [Property("TestName", "TC002_3 - Sample App - Verification of an unsuccessful login")]
        public void TC002_3_UnsuccessfulLogin()
        {
            var page = new SampleAppPage(driver!);
            page.Open();
            page.Login("JohnDoe", "wrong_password");
            Assert.That(page.GetStatusMessage(), Is.EqualTo("Invalid username/password"));
        }
    }
}