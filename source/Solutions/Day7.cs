using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/7
    /// </summary>
    internal class Day7 : CodePuzzleSolution<string>
    {
        private Dictionary<string, List<(int count, string color)>> bagDict;

        private const string BAG_COLOR = "shiny gold";

        public Day7(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 7: Handy Haversacks ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            SetupDictionary();
            return bagDict.Keys.Sum(color => CanContainSantasBag(color) ? 1 : 0);
        }

        public int SolvePart2()
        {
            SetupDictionary();
            return CountBags(bagDict[BAG_COLOR]) - 1;
        }

        private void SetupDictionary()
        {
            bagDict = new Dictionary<string, List<(int, string)>>();

            var r = new Regex("([\\d])+ ([\\w ]+)");

            foreach (var line in Data)
            {
                var trimmedLine = line.Trim();
                var parts = trimmedLine.Split(" bags contain ");

                var bagList = GetOrCreateBagList(parts[0]);

                if (trimmedLine.Contains("no other bags"))
                    continue;

                foreach (var subBag in Regex.Replace(parts[1], " bags?\\.?", "").Split(", "))
                {
                    var groups = r.Match(subBag).Groups;
                    bagList.Add((int.Parse(groups[1].Value), groups[2].Value));
                }
            }
        }

        private List<(int, string)> GetOrCreateBagList(string color)
        {
            if(!bagDict.ContainsKey(color))
                bagDict.Add(color, new List<(int, string)>());

            return bagDict[color];
        }

        private bool CanContainSantasBag(string color)
        {
            foreach (var bag in bagDict[color])
                if (bag.color.Equals(BAG_COLOR) || CanContainSantasBag(bag.color))
                    return true;

            return false;
        }

        private int CountBags(List<(int count, string color)> bagList)
        {
            var sum = 1;

            foreach (var (count, color) in bagList)
                sum += count * CountBags(bagDict[color]);

            return sum;
        }
    }
}
