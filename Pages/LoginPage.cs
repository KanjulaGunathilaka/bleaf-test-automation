using OpenQA.Selenium;
using Pages;

namespace bleaf_test_automation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameField = By.Id("UserName");
        private readonly By _passwordField = By.Id("Password");
        private readonly By _loginButton = By.XPath("//*[@id='loginForm']/form/div[3]/input[1]");
        private readonly By _userDashboard = By.Id("userDashboard");

        public LoginPage() : base() { }

        public void Login(string username, string password)
        {
            InputText(_usernameField, username);
            InputText(_passwordField, password);
            ClickOnElement(_loginButton);
        }

        public bool IsUserDashboardDisplayed()
        {
            WaitForElement(_userDashboard);
            return Driver.FindElement(_userDashboard).Displayed;
        }
    }
}