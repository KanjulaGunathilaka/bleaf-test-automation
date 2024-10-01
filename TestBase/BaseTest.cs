using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using bleaf_test_automation.Utils;
using Drivers;

namespace bleaf_test_automation.TestBase
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        public void Setup()
        {
            try
            {
                Console.WriteLine("Initializing WebDriver...");
                Driver = BleafWebDriverManager.GetDriver();
                Driver.Manage().Window.Maximize();

                // Retrieve the URL from the configuration
                string url = ConfigManager.GetConfigValue("ApplicationUrl");
                Console.WriteLine($"Retrieved URL from config: {url}");

                // Navigate to the URL
                Console.WriteLine($"Navigating to URL: {url}");
                Driver.Navigate().GoToUrl(url);

                // Wait for the page to load completely
                WaitForPageLoadComplete();
                Console.WriteLine("Page loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during setup: {ex.Message}");
                throw;
            }
        }

        public void TearDown()
        {
            try
            {
                if (ScenarioContext.Current.TestError != null)
                {
                    ScreenshotHelper.TakeScreenshot(Driver, ScenarioContext.Current.ScenarioInfo.Title);
                }
            }
            finally
            {
                BleafWebDriverManager.QuitDriver();
            }
        }

        private void WaitForPageLoadComplete(int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}