using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/15
    /// </summary>
    internal class Day15 : CodePuzzleSolution<string>
    {
        private int targetNumber = 0;
        private List<int> allNumbers;
        public Day15(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 15: Rambunctious Recitation ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        private int GetLastSpokenNumber()
        {
            var seedingNumbers = Data[0].Split(",").Select(n => int.Parse(n)).ToList();
            allNumbers = new List<int>();
            var spokenNumbers = new Dictionary<int, int>();

            for (var i = 0; i < seedingNumbers.Count; i++)
            {
                var seed = seedingNumbers[i];
                spokenNumbers[seed] = i;
                SpeakOut(i, seed);
            }

            for (var i = seedingNumbers.Count; i < targetNumber; i++)
            {
                var prevNumberPos = i - 1;
                var prevNumber = allNumbers[prevNumberPos];

                if (!spokenNumbers.ContainsKey(prevNumber))
                {
                    spokenNumbers[prevNumber] = prevNumberPos;
                    SpeakOut(i, 0);
                }
                else
                {
                    var previousMention = spokenNumbers[prevNumber];

                    if (i - 1 == previousMention)
                    {
                        SpeakOut(i, 0);
                    }
                    else
                    {
                        var dist = prevNumberPos - previousMention;
                        SpeakOut(i, dist);
                    }

                    spokenNumbers[prevNumber] = prevNumberPos;
                }
            }
            return allNumbers.Last();
        }

        private int SolvePart1()
        {
            targetNumber = 2020;
            return GetLastSpokenNumber();
        }

        private int SolvePart2()
        {
            targetNumber = 30000000;
            return GetLastSpokenNumber();
        }

        private void SpeakOut(int pos, int number)
        {
            allNumbers.Add(number);
            //Console.WriteLine((pos+1) + ": " + number + " ");
        }
    }
}
