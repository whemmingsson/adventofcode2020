using System.Linq;

namespace AdventOfCode2020.Business.Tools.Validators
{
    public class ListValidator
    {
        public static bool IsValid(string value, params string[] items)
        {
            return items.Any(i => i.Equals(value));
        }
    }
}
