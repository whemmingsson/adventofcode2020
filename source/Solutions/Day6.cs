using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/6
    /// </summary>
    internal class Day6 : CodePuzzleSolution<string>
    {
        public Day6(bool autoSolve = true, bool time = false) : base(6, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("# Day 6 #");
            Console.WriteLine($"Part A: {SolvePartA()}");
            Console.WriteLine($"Part B: {SolvePartB()}");
            Console.WriteLine("");
        }

        public int SolvePartA()
        {
           var sum = 0;
           var group = new List<char>();
           foreach(var line in Data)
            {
                if (string.IsNullOrWhiteSpace(line)) {

                    sum += group.Distinct().Count();
                    group = new List<char>();
                    continue;
                }

                group.AddRange(line.Trim());
            }

            return sum;
        }

        public int SolvePartB()
        {
            var sum = 0;
            var group = new List<char>();
            var personsInGroup = 0;
            foreach (var line in Data)
            {
                if (string.IsNullOrWhiteSpace(line))
                {             
                    sum += group.Distinct().Count(a => group.Count(b => a == b) == personsInGroup);
                    personsInGroup = 0;
                    group = new List<char>();
                    continue;
                }

                group.AddRange(line.Trim());
                personsInGroup++;
            }

            return sum;
        }
    }
}
