using System;
using System.IO;

namespace AdventOfCode2020.Business
{
    class IO
    {
        protected const string INPUT_FORMAT = "/input/{0}.txt";
        protected const string OUTPUT_FORMAT = "/output/{0}.txt";
        public static string GetPath(int day, string format) => GetBasePath() + string.Format(format, day);
        public static string GetBasePath() => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
    }
}
