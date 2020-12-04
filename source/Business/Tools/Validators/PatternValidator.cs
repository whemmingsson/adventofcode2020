using System.Text.RegularExpressions;

namespace AdventOfCode2020.Business.Tools.Validators
{
    public class PatternValidator
    {
        public static bool IsValid(string value, string pattern)
        {
            return new Regex(pattern).IsMatch(value);
        }
    }
}
