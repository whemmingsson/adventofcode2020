using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/8
    /// </summary>
    internal class Day8 : CodePuzzleSolution<string>
    {
        public Day8(bool autoSolve = true, bool time = false) : base(8, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;


            Console.WriteLine("--- Day 8:  ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            return -1;
        }

        public int SolvePart2()
        {
            return -1;
        }

    }
}
