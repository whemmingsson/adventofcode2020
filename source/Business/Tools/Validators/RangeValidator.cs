namespace AdventOfCode2020.Business.Tools.Validators
{
    public static class RangeValidator
    {
        public static bool IsInRange(string value, int lowerLimit, int upperLimit)
        {
            if (!int.TryParse(value, out int intValue)) return false;
            return IsInRange(intValue, lowerLimit, upperLimit);
        }

        private static bool IsInRange(int value, int lowerLimit, int upperLimit)
        {
            return value >= lowerLimit && value <= upperLimit;
        }
    }
}