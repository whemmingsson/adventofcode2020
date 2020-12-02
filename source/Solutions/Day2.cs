using AdventOfCode2020.Business;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2012/day/2
    /// </summary>
    internal class Day2 : CodePuzzleSolution<string>
    {
        public Day2(bool autoSolve = true, bool time = false) : base(2, new LineParser<string>(), autoSolve, time) {}

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
            Regex r = new Regex("([\\d]+)-([\\d]+) ([a-z]): ([a-z]+)");

            var count = 0;
            foreach(var line in Data)
            {
               
                var groups = r.Match(line).Groups;

                var lowerBound = int.Parse(groups[1].Value);
                var upperBound = int.Parse(groups[2].Value);
                var searchCharacter = char.Parse(groups[3].Value);
                var password = groups[4].Value;

                var numMatches = password.Count(pwc => pwc == searchCharacter);

                if (numMatches >= lowerBound && numMatches <= upperBound)
                    count++;
            }

            return count;
        }

        private int SolvePartB()
        {
            Regex r = new Regex("([\\d]+)-([\\d]+) ([a-z]): ([a-z]+)");

            var count = 0;
            foreach (var line in Data)
            {
                var groups = r.Match(line).Groups;

                var validPos = int.Parse(groups[1].Value) - 1;
                var valisPos2 = int.Parse(groups[2].Value) - 1;
                var searchCharacter = char.Parse(groups[3].Value);
                var password = groups[4].Value;

                if ((password[validPos] == searchCharacter && password[valisPos2] != searchCharacter) ||
                    (password[validPos] != searchCharacter && password[valisPos2] == searchCharacter))
                    count++;
            }

            return count;
        }  

    }
}
