using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace bleaf_test_automation.Utils
{
    public static class WebDriverExtensions
    {
        public static void WaitForElement(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(drv => drv.FindElement(locator).Displayed);
            }
        }

        public static void WaitForPageLoadComplete(this IWebDriver driver, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void ClickOnElement(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            driver.WaitForElement(locator, timeoutInSeconds);
            driver.FindElement(locator).Click();
        }

        public static void InputText(this IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
        {
            driver.WaitForElement(locator, timeoutInSeconds);
            var element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickOnElementJS(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            driver.WaitForElement(locator, timeoutInSeconds);
            var element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}