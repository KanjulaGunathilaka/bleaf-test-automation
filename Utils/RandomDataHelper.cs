using System;

namespace bleaf_test_automation.Utils
{
    public static class RandomDataHelper
    {
        private static readonly Random _random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public static string GenerateRandomCategoryName()
        {
            return "Category_" + GenerateRandomString(5);
        }

        public static string GenerateRandomItemName()
        {
            return "Item_" + GenerateRandomString(5);
        }

        public static string GenerateRandomDiscountCode()
        {
            return "Discount_" + GenerateRandomString(5);
        }
    }
}