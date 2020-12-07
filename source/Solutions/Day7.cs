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
        private Dictionary<string, List<string>> bagDict;

        private const string BAG_COLOR = "shiny gold";

        public Day7(bool autoSolve = true, bool time = false) : base(7, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("Day 7");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            var sum = 0;
            bagDict = new Dictionary<string, List<string>>();

            var r = new Regex("([\\d])+ ([\\w ]+)");

            foreach (var line in Data)
            {
                var trimmedLine = line.Trim();
                var parts = trimmedLine.Split(" bags contain ");

                var color = parts[0];

                var bagList = GetBagList(color);

                if (trimmedLine.Contains("no other bags"))
                    continue;
             
                var contains = Regex.Replace(parts[1], " bags?\\.?", "").Split(", ");

                foreach (var subBag in contains)
                {
                    var groups = r.Match(subBag).Groups;
                    var count = int.Parse(groups[1].Value);
                    var subBagColor = groups[2].Value;
                    bagList.Add(subBagColor);
                
                }    
            }

            foreach (var color in bagDict.Keys)
            {
                if (CanContainSantasBag(color))
                    sum++;               
            }

            return sum;
        }

        public List<string> GetBagList(string color)
        {         
            if (bagDict.ContainsKey(color))
                return bagDict[color];

            List<string> bagList = new List<string>();

            bagDict.Add(color, bagList);

            return bagList;
        }
     
        public bool CanContainSantasBag(string color)
        {
            foreach (var bagColor in bagDict[color])
            {
                if (bagColor.Equals(BAG_COLOR))
                    return true;

                if (CanContainSantasBag(bagColor))
                    return true;
            }

            return false;
        }

        public int SolvePart2()
        {
            var sum = 0;

            for (int i = 0; i < Data.Count; i++)
            {

            }

            return sum;
        }
   }
}
