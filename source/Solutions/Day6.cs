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
        public Day6(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 6: Custom Customs ---");
            Console.WriteLine($"Part 1: {SolvePart1()}");
            Console.WriteLine($"Part 2: {SolvePart2()}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
           var sum = 0;
           var group = new List<char>();
            for (int i = 0; i < Data.Count; i++)
            {
                group.AddRange(Data[i].Trim());

                if (IsGroupFinished(i))
                {
                    sum += group.Distinct().Count();
                    group = new List<char>();
                    i++;
                }
            }

            return sum;
        }

        public int SolvePart2()
        {
            var sum = 0;
            var group = new List<char>();
            var personsInGroup = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                group.AddRange(Data[i].Trim());
                personsInGroup++;

                if (IsGroupFinished(i))
                {
                    sum += group.Distinct().Count(a => group.Count(b => a == b) == personsInGroup);
                    personsInGroup = 0;
                    group = new List<char>();
                    i++;
                }
            }

            return sum;
        }

        private bool IsGroupFinished(int i)
        {
            return (i + 1 < Data.Count && string.IsNullOrWhiteSpace(Data[i + 1])) || i == Data.Count - 1;
        }
    }
}
