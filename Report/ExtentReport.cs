
using AventStack.ExtentReports;

namespace bleaf_test_automation.Report
{
    public static class ExtentReport
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void InitReport()
        {
            var htmlReporter = new ExtentHtmlReporter("ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogInfo(string message)
        {
            _test.Log(Status.Info, message);
        }

        public static void LogError(string message)
        {
            _test.Log(Status.Error, message);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}