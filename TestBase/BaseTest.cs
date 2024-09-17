using NUnit.Framework;
using OpenQA.Selenium;
using bleaf_test_automation.Utils;
using NUnit.Framework.Interfaces;
using Drivers;

namespace bleaf_test_automation.TestBase
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = BleafWebDriverManager.GetDriver();
            Driver.Navigate().GoToUrl(ConfigManager.GetConfigValue("ApplicationUrl"));
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
            }
            BleafWebDriverManager.QuitDriver();
        }
    }
}