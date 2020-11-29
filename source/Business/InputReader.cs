using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Business
{
    internal class InputReader: IO
    {       
        public static IEnumerable<T> GetInputFromFile<T>(int day, InputParser<T> parser)
        {
            return parser.Parse(File.ReadAllText(GetPath(day, INPUT_FORMAT)));
        }
    }
}
