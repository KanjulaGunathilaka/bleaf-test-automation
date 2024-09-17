using System;

namespace bleaf_test_automation.Utils
{
    public static class RetryHelper
    {
        public static void Retry(Action action, int retryCount = 3)
        {
            int attempts = 0;
            while (attempts < retryCount)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Attempt {attempts + 1} failed: {ex.Message}");
                    attempts++;
                    if (attempts == retryCount)
                    {
                        throw;
                    }
                }
            }
        }
    }
}