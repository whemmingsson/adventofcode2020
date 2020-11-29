using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Business
{
    public class CommaParser<T> : InputParser<T>
    {
        public override IEnumerable<T> Parse(string s)
        {
            foreach (var line in s.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                yield return GetValue(line);
            }
        }
    }
}
