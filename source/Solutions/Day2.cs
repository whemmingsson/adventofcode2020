using AdventOfCode2020.Business;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/2
    /// </summary>
    internal class Day2 : CodePuzzleSolution<string>
    {
        public Day2(bool autoSolve = true, bool time = false) : base(2, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!SolveNow || Data == null || !Data.Any())
                return;

            Console.WriteLine("# Day 2 #");
            Console.WriteLine($"Part A: {SolveWithFun(SolvePartA)}");
            Console.WriteLine($"Part B: {SolveWithFun(SolvePartB)}");
            Console.WriteLine("");
        }

        private int SolvePartA()
        {
            return Data.Count(line =>
            {
                var input = new Input(line);
                var numMatches = input.Password.Count(pwc => pwc == input.SearchCharacter);
                return numMatches >= input.Param1 && numMatches <= input.Param2;
            });
        }

        private int SolvePartB()
        {
            return Data.Count(line =>
            {
                var input = new Input(line);
                return input.Password[input.Param1 - 1] == input.SearchCharacter ^ input.Password[input.Param2 - 1] == input.SearchCharacter;
            });
        }

        private class Input
        {
            private static readonly Regex regex = new Regex("([\\d]+)-([\\d]+) ([a-z]): ([a-z]+)");

            public int Param1 { get; set; }
            public int Param2 { get; set; }
            public string Password { get; set; }
            public char SearchCharacter { get; set; }
            public Input(string line)
            {
                var groups = regex.Match(line).Groups;

                Param1 = int.Parse(groups[1].Value);
                Param2 = int.Parse(groups[2].Value);
                SearchCharacter = char.Parse(groups[3].Value);
                Password = groups[4].Value;
            }
        }
    }
}

