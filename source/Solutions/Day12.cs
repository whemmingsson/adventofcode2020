﻿using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode2020.Business.Day12.Ferry;

namespace AdventOfCode2020.Solutions
{
    internal partial class Day12 : CodePuzzleSolution<string>
    {
        private Ferry ferry;
     
        public Day12(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 12: Rain Risk ----");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            ferry = new Ferry(false);

            foreach (var ins in ParseData())
            {
                ferry.Move(ins);
            }

            return ferry.GetTravelDistance();
        }

        public int SolvePart2()
        {
            ferry = new Ferry(true);

            foreach (var ins in ParseData())
            {
                ferry.Move(ins);
            }

            return ferry.GetTravelDistance();
        }

        private IEnumerable<(Direction, int)> ParseData()
        {
            return Data.Select(line => ((Direction)(line.Substring(0, 1)[0]), int.Parse(line.Substring(1))));
        }
    }
}
