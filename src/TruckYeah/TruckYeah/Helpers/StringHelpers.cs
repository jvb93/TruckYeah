namespace TruckYeah.Helpers
{
    public static class StringHelpers
    {
        public static bool IsLengthEven(this string inputString)
        {
            return inputString?.Length % 2 == 0;
        }
    }
}