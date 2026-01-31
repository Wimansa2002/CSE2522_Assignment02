using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class ClientSideDelayTests : TestBase
    {
        [Test]
        [Property("TestName", "TC003_1 - Client Side Delay - Verification of the page")]
        public void TC003_1_VerifyDelay()
        {
            var page = new ClientSideDelayPage(driver!);
            page.Open();
            page.ClickTrigger();
            Assert.That(page.IsSpinnerVisible(), Is.True); //

            string expected = "Data calculated on the client side";
            Assert.That(page.GetResultText(), Is.EqualTo(expected)); //
        }
    }
}