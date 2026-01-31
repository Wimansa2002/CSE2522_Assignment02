using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class SampleAppPage
    {
        private readonly IWebDriver driver;

        public SampleAppPage(IWebDriver driver) => this.driver = driver;

        private IWebElement UserNameField => driver.FindElement(By.Name("UserName"));
        private IWebElement PasswordField => driver.FindElement(By.Name("Password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login"));
        private IWebElement LoginStatus => driver.FindElement(By.Id("loginstatus"));

        public void Open() => driver.Navigate().GoToUrl("https://uitestingplayground.com/sampleapp");

        public bool AreElementsDisplayed() =>
            UserNameField.Displayed && PasswordField.Displayed && LoginButton.Displayed;

        public void Login(string username, string password)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public string GetStatusMessage() => LoginStatus.Text;
    }
}
