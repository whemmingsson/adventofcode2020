using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Business
{
    internal enum Source
    {
        AdventOfCode
    }

    internal class Output
    {
        private Source m_source;
        public Output(int[] values, Source source, int day)
        {
            Day = day;
            Values = values;
            m_source = source;
        }

        public int[] Values { get; set; }
        public int Day { get; set; }
        public string Source => m_source.ToString();
    }

    internal class OutputWriter : IO
    {
        public static void WriteToFile(int day, Source source, params int[] values)
        {
            var output = new Output(values, source, day);

            var path = string.Format(OUTPUT_FORMAT, day);

            var fullPath = GetBasePath() + path;

            if (File.Exists(fullPath))
            {
                var fileContents = File.ReadAllText(fullPath);
                var fileOutput = JsonConvert.DeserializeObject<Output>(fileContents);

                if (!fileOutput.Values.All(output.Values.Contains))
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(output, Formatting.Indented));
                }
            }
            else
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(output, Formatting.Indented));
            }
        }
    }
}

