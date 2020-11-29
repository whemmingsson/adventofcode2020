using AdventOfCode2020.Business;
using System;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2019/day/1
    /// </summary>
    internal class Day0 : CodePuzzleSolution<int>
    {
        public Day0(bool autoSolve = true) : base(1, new LineParser<int>(), autoSolve) {}

        public override void Solve()
        {
            if (!SolveNow || Data == null || !Data.Any())
                return;

            Console.WriteLine("# Day 1 #");
            Console.WriteLine($"Part A: {SolvePartA()}");
            Console.WriteLine($"Part B: {SolvePartB()}");
            Console.WriteLine("");
        }

        public int SolvePartA()
        {
            return Data.Sum(i => CalcCost(i));
        }

        public int SolvePartB()
        {
            return Data.Sum(i => Reduce(i));
        }  

        private int Reduce(int c)
        {
            var s = CalcCost(c);
            return s > 0 ? s + Reduce(s) : 0;
        }

        private int CalcCost(int c) => c / 3 - 2;
    }
}
