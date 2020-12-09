using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Day8;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/9
    /// </summary>
    internal class Day9 : CodePuzzleSolution<long>
    {
        private const int PREAMBLE_LENGTH = 25;

        private HashSet<long> sums = new HashSet<long>();

        public Day9(bool autoSolve = true, bool time = false) : base(9, new LineParser<long>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 9: Encoding Error ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public long SolvePart1()
        {
            for(var i = PREAMBLE_LENGTH; i < Data.Count; i++)
            {
                UpdateSums(i - PREAMBLE_LENGTH);

                if (!sums.Contains(Data[i]))
                    return Data[i];             
            }

            return -1;
        }

        private void UpdateSums(int startingIndex)
        {
            sums.Clear();
            for (var i = startingIndex; i < PREAMBLE_LENGTH + startingIndex; i++)
            {
                for (var j = i + 1; j < PREAMBLE_LENGTH + startingIndex; j++)
                {
                    long sum = Data[i] + Data[j];
                    if (!sums.Contains(sum))
                        sums.Add(sum);
                }
            }
        }

        public int SolvePart2()
        {
            var target = SolvePart1();



            return -1;

        }
    }
}
