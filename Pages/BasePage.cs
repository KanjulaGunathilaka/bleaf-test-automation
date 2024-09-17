using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Drivers;

namespace Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage()
        {
            Driver = BleafWebDriverManager.GetDriver();
        }

        protected void WaitForElement(By locator, int timeoutInSeconds = 10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(drv => drv.FindElement(locator).Displayed);
            }
        }

        protected void WaitForPageLoadComplete(int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void ClickOnElement(By locator, int timeoutInSeconds = 10)
        {
            WaitForElement(locator, timeoutInSeconds);
            Driver.FindElement(locator).Click();
        }

        protected void InputText(By locator, string text, int timeoutInSeconds = 10)
        {
            WaitForElement(locator, timeoutInSeconds);
            var element = Driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected void ClickOnElementJS(By locator, int timeoutInSeconds = 10)
        {
            WaitForElement(locator, timeoutInSeconds);
            var element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}