using OpenQA.Selenium;
using Pages;

namespace bleaf_test_automation.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _loginButton = By.XPath("//button[@id='loginButton']");
        private readonly By _logo = By.XPath("//img[@id='logo']");
        private readonly By _searchBar = By.XPath("//input[@id='searchBar']");
        private readonly By _headerPanel = By.XPath("//div[@id='headerPanel']");

        public HomePage() : base() { }

        public void ClickLoginButton()
        {
            ClickOnElement(_loginButton);
        }

        public bool IsLogoDisplayed()
        {
            WaitForElement(_logo);
            return Driver.FindElement(_logo).Displayed;
        }

        public bool IsSearchBarDisplayed()
        {
            WaitForElement(_searchBar);
            return Driver.FindElement(_searchBar).Displayed;
        }

        public bool IsHeaderPanelDisplayed()
        {
            WaitForElement(_headerPanel);
            return Driver.FindElement(_headerPanel).Displayed;
        }
    }
}