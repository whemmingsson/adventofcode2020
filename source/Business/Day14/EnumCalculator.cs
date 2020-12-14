using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Business.Day14
{
    public static class EnumCalculator
    {
        public static List<string> GetEnumerations(int length)
        {
            return EnumerateAux(length-1).Where(v => v.Length == length).ToList();
        }

        private static List<string> EnumerateAux(int count, string value = "")
        {
            var result = new List<string>
            {
                value + "0",
                value + "1"
            };

            if (count == 0)
                return result;

            result.AddRange(EnumerateAux(count - 1, value + "0"));
            result.AddRange(EnumerateAux(count - 1, value + "1"));

            return result;

        }
    }
}
