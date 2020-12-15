using AdventOfCode2020.Business;
using System;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/15
    /// </summary>
    internal class Day15 : CodePuzzleSolution<string>
    {
        public Day15(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 15: Rambunctious Recitation ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        private int SolvePart1()
        {
            return -1;
        }

        private int SolvePart2()
        {
            return -1;
        }

    }
}
