using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/10
    /// </summary>
    internal class Day10 : CodePuzzleSolution<long>
    {
        public Day10(bool autoSolve = true, bool time = false) : base(10, new LineParser<long>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 10: Adapter Array ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public long SolvePart1()
        {

            var oneJoltDifference = 1;
            var twoJoltDifference = 0; // Used for part two
            var threeJoltDifference = 1;


            var adapterListOrdered = Data.OrderBy(v => v).ToList();

            for(var i = 0; i < adapterListOrdered.Count - 1; i++)
            {
                var difference = adapterListOrdered[i + 1] - adapterListOrdered[i];

                if (difference == 1)
                    oneJoltDifference++;
                else if (difference == 2)
                    twoJoltDifference++;
                else if (difference == 3)
                    threeJoltDifference++;
            }

            return oneJoltDifference * threeJoltDifference;
        }

   
        public long SolvePart2()
        {
            return -1;
        }
    }
}
