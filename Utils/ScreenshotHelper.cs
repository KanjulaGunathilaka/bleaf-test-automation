using OpenQA.Selenium;
using System;
using System.IO;

namespace bleaf_test_automation.Utils
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots", $"{testName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}