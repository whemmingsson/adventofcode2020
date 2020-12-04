using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Tools.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/4
    /// </summary>
    internal partial class Day4 : CodePuzzleSolution<string>
    {
        private static readonly List<string> reqFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public Day4(bool autoSolve = true, bool time = false) : base(4, new LineParser<string>(), autoSolve, time) {}

        public override void Solve()
        {
            if (!SolveNow || Data == null || !Data.Any())
                return;

            Data = PreprocessInput();

            Console.WriteLine("--- Day 4: Passport Processing ---");

            Console.WriteLine($"Part A: {SolveWithFun(SolvePartA)}");
            Console.WriteLine($"Part B: {SolveWithFun(SolvePartB)}");
            Console.WriteLine("");
        }

        private int SolvePartA()
        {
            var count = 0;
            foreach(var line in Data)
            {
                if (reqFields.All(field => line.Contains(field)))
                    count++;
            }

            return count;
        }

        private int SolvePartB()
        {
            var validator = new PassportValidator();
            return Data.Count(l => validator.IsValid(l));
        }  

        private partial class PassportValidator
        {       
            readonly Dictionary<string, Func<string, bool>> validators;

            public PassportValidator()
            {
                validators = new Dictionary<string, Func<string, bool>>
                {
                    { "byr", v => RangeValidator.IsInRange(v, 1920, 2002) },
                    { "iyr", v => RangeValidator.IsInRange(v, 2010, 2020) },
                    { "eyr", v => RangeValidator.IsInRange(v, 2020, 2030) },
                    { "hgt", v => HeightValidator.IsInRange(v, ("cm", (150, 193)), ("in", (59, 76))) },
                    { "hcl", v => PatternValidator.IsValid(v, "#[a-f,0-9]{6}") },
                    { "ecl", v => EyeColorValidator.IsValid(v) },
                    { "pid", v => PatternValidator.IsValid(v, "[0-9]{9}") },
                    { "cid", v => true }
                };
            }

            public bool IsValid(string line)
            {
                if(!(reqFields.All(field => line.Contains(field))))
                    return false;

                var kvps = line.Split(" ");

                foreach(var kvp in kvps)
                {
                    var kvpArr = kvp.Split(":");
                    if (!validators[kvpArr[0]](kvpArr[1]))
                        return false;
                }

                return true;
            }
        }

        private List<string> PreprocessInput()
        {
            var preprocessedData = new List<string>();

            var newDataLine = "";
            foreach(var line in Data)
            {
                if(line.Trim().Length == 0)
                {
                    preprocessedData.Add(newDataLine);
                    newDataLine = "";
                    continue;
                }

                newDataLine += (string.IsNullOrWhiteSpace(newDataLine) ? "" : " ") + line.Trim();
            }

            return preprocessedData;
        }
    }
}