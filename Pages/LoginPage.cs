using OpenQA.Selenium;
using Pages;

namespace bleaf_test_automation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameField = By.Id("email");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.XPath("//*[@id='offcanvasLogin']/div/div/form/button");
        private readonly By _adminDashboard = By.XPath("//h1[contains(text(),'Admin Panel')]");

        public LoginPage() : base() { }

        public void Login(string username, string password)
        {
            InputText(_usernameField, username);
            InputText(_passwordField, password);
            ClickOnElement(_loginButton);
        }

        public bool IsUserDashboardDisplayed()
        {
            WaitForElement(_adminDashboard);
            return Driver.FindElement(_adminDashboard).Displayed;
        }
    }
}