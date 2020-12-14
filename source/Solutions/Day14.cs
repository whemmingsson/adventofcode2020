using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    internal partial class Day14 : CodePuzzleSolution<string>
    {
        private Dictionary<int, long> memory;
        public Day14(bool autoSolve = true, bool time = false) : base(14, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 14: Docking Data ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public long SolvePart1()
        {
            memory = new Dictionary<int, long>();

            var maskRegex = new Regex("[01X]+");
            var memRegex = new Regex("mem\\[(\\d+)\\] = (\\d+)");

            long zeroMask = 0, oneMask = 0;

            foreach (var line in Data)
            {
                if (line.Contains("mask"))
                {
                    var mask = maskRegex.Match(line).Value;
                    zeroMask = Convert.ToInt64(mask.Replace("X", "1"), 2);
                    oneMask = Convert.ToInt64(mask.Replace("X", "0"), 2);
                }

                if(line.Contains("mem"))
                {
                    var groups = memRegex.Match(line).Groups;
                    WriteToMemory(int.Parse(groups[2].Value) & zeroMask | oneMask, int.Parse(groups[1].Value));
                }
            }

            return SumMemory();
        }

        private void WriteToMemory(long value, int adress)
        {
            if (memory.ContainsKey(adress))
                memory[adress] = value;
            else
                memory.Add(adress, value);
        }

        private long SumMemory()
        {
            return memory.Values.Sum(v => v);
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
