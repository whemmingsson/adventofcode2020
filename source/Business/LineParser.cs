using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Business
{
    public class LineParser<T> : InputParser<T>
    {
        public override IEnumerable<T> Parse(string s)
        {
            foreach (var line in s.Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                yield return GetValue(line);
            }
        }
    }
}
