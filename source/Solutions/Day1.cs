﻿using AdventOfCode2020.Business;
using System;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/1
    /// </summary>
    internal class Day1 : CodePuzzleSolution<int>
    {
        public Day1(bool autoSolve = true, bool time = false) : base(new LineParser<int>(), autoSolve, time) {}

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("# Day 1 #");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        private int SolvePart1()
        {
            for(var i = 0; i < Data.Count; i++)
            {
                for (var j = i+1; j < Data.Count; j++)
                {
                    if(Data[i] + Data[j] == 2020)
                    {
                        return Data[i] * Data[j];
                    }
                }
            }

            return -1;
        }

        private int SolvePart2()
        {
            for (var i = 0; i < Data.Count; i++)
            {
                for (var j = i + 1; j < Data.Count; j++)
                {
                    if (Data[i] + Data[j] >= 2020) // To speed up performance somewhat
                        continue;

                    for (var k = j + 1; k < Data.Count; k++)
                    {
                        if (Data[i] + Data[j] + Data[k] == 2020)
                        {
                            return Data[i] * Data[j] * Data[k];
                        }
                    }
                }
            }

            return -1;
        }  

    }
}
