using AdventOfCode2020.Business;
using System;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/5
    /// </summary>
    internal class Day5 : CodePuzzleSolution<string>
    {
        private const int NUM_ROWS = 128;
        private const int NUM_COLS = 8;

        public Day5(bool autoSolve = true, bool time = false) : base(5, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 5: Binary Boarding ---");
            Console.WriteLine($"Part A: {SolvePartA()}");
            Console.WriteLine($"Part B: {SolvePartB()}");
            Console.WriteLine("");
        }

        public int SolvePartA()
        {
            return Data.Max(line => GetRowNumber(line) * NUM_COLS + GetColumnNumber(line));
        }

        private static int GetRowNumber(string line)
        {
            return CalculateNumber(line.Substring(0, 7), new Range(0, NUM_ROWS - 1), 'F', 'B');
        }

        private static int GetColumnNumber(string line)
        {
            return CalculateNumber(line.Substring(7, 3), new Range(0, NUM_COLS - 1), 'L', 'R');
        }

        private static int CalculateNumber(string def, Range range, char lowerChar, char upperChar)
        {
            foreach (var c in def)
            {
                if (c == lowerChar) range.LowerHalf();
                if (c == upperChar) range.UpperHalf();
            }

            return range.GetFinalValue();
        }

        public int SolvePartB()
        {
            return -1;
        }

        private class Range
        {
            private int _lower;
            private int _upper;

            public Range(int l, int u)
            {
                _lower = l;
                _upper = u;
            }
          
            private int Length => _upper - _lower;

            public void LowerHalf()
            {
                _upper = _lower + Length / 2;
            }

            public void UpperHalf()
            {
                _lower = _upper - Length / 2;
            }

            public int GetFinalValue() => _upper;
        }
    }
}
