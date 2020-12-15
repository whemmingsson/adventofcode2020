using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode2020.Business.Day12.Ferry;

namespace AdventOfCode2020.Solutions
{
    internal partial class Day13 : CodePuzzleSolution<string>
    {

        public Day13(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 13: Shuttle Search ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            var target = int.Parse(Data[0]);
            var busIds = Data[1].Split(',').Where(c => c != "x").Select(n => int.Parse(n));

            var minWaitTime = int.MaxValue;
            var targetBusId = -1;
            foreach(var busId in busIds)
            {
                var waitTime = busId - (target % busId);
                if (waitTime < minWaitTime) { 
                    minWaitTime = waitTime;
                    targetBusId = busId;
                }
            }

            return minWaitTime*targetBusId;
        }

        public int SolvePart2()
        {
            return -1;
        }
    }

}
