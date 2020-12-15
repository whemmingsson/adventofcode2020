using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2012/day/2
    /// </summary>
    internal class Day3 : CodePuzzleSolution<string>
    {
        private const char TREE_CHAR = '#';
        private int _slopeX;
        private int _slopeY;

        public Day3(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) {}

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 3: Toboggan Trajectory ---");

            _slopeX = 3;
            _slopeY = 1;

            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        private int SolvePart1()
        {
            var patternLength = Data[0].Trim().Length;   
            var numTrees = 0;
            var x = 0;

            for (var y = 0; y < Data.Count; y += _slopeY)
            {
                if (Data[y][x % patternLength] == TREE_CHAR)
                    numTrees++;

                x += _slopeX;            
            }

            return numTrees;
        }

        private int SolvePart2()
        {
            var treeProduct = 1;
            foreach(var slope in new List<(int, int)>() { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) })
            {
                _slopeX = slope.Item1;
                _slopeY = slope.Item2;
                treeProduct *= SolvePart1();
            }
            return treeProduct;
        }  
    }
}