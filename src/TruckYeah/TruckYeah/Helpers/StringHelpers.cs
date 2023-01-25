namespace TruckYeah.Helpers
{
    public static class StringHelpers
    {
        public static bool IsLengthEven(this string inputString)
        {
            return inputString?.Length % 2 == 0;
        }

        public static int GetVowelCount(this string inputString)
        {
            var count = 0;
            foreach (var character in inputString)
            {
                if (character is 'a' or 'A' or 'e' or 'E' or 'i' or 'I' or 'o' or 'O' or 'u' or 'U')
                {
                    count++;
                }
            }

            return count;
        }

        public static int GetConsonantCount(this string inputString)
        {
            return inputString.Length - inputString.GetVowelCount();
        }
    }
}