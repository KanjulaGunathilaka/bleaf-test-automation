using TechTalk.SpecFlow;
using bleaf_test_automation.Utils;

namespace bleaf_test_automation.Hooks
{
    [Binding]
    public class TestHooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Logger.LogInfo("Starting scenario...");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Logger.LogInfo("Ending scenario...");
            CleanupTestData();
        }

        private void CleanupTestData()
        {
            string testDataPrefix = "test_";
            string deleteQuery = $"DELETE FROM Users WHERE Username LIKE '{testDataPrefix}%'";
            DatabaseHelper.Instance.ExecuteQuery(deleteQuery);
        }
    }
}