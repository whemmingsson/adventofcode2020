namespace AdventOfCode2020.Business.Tools.Validators
{
    public class EyeColorValidator
    {
        public static bool IsValid(string value)
        {
            return ListValidator.IsValid(value, "amb", "blu", "brn", "gry", "grn", "hzl", "oth");
        }
    }
}
