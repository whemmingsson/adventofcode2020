using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/7
    /// </summary>
    internal class Day7 : CodePuzzleSolution<string>
    {
        private readonly List<Bag> bags = new List<Bag>();
        int counter = 0;
        private Dictionary<string, Bag> bagDict;

        private const string BAG_COLOR = "shiny gold";

        public Day7(bool autoSolve = true, bool time = false) : base(7, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("Day 7");
            Console.WriteLine($"Part 1: {SolvePart1()}");
            Console.WriteLine($"Part 2: {SolvePart2()}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            var sum = 0;
            bagDict = new Dictionary<string, Bag>();

            foreach (var line in Data)
            {
                var parts = line.Split("bags contain");

                var color = parts[0].Replace("bags", "").Trim();

                if (color == "other")
                    continue;

                var bag = GetBag(color);

                var contains = ParseLine(parts).Split(",");

                foreach (var subBag in contains)
                {
                   
                    var firstSpace = subBag.Trim().IndexOf(" ");
                    //var count = int.Parse(subBag.Trim().Substring(0, firstSpace));
                    var subBagColor = subBag.Trim()[firstSpace..].Trim();

                    if (subBagColor == "other")
                        continue;

                    var bagBag = GetBag(subBagColor);
                    bag.AddBag(bagBag);
                }

                if(!bagDict.ContainsKey(color))
                {
                    bagDict.Add(color, bag);
                    bags.Add(bag);
                }
             
            }

            foreach (var b in bags)
            {
                if (CanContainsSantasBag(b))
                    sum++;
            }

            return sum;
        }

        private static string ParseLine(string[] parts)
        {
            return parts[1].Trim().Replace("bags", "").Replace("bag", "").Replace(".", "").Trim();
        }

        public Bag GetBag(string color)
        {
            var bag = bags.FirstOrDefault(b => b.Color.Equals(color));

             if (bag != null)
                 return bag;

            bag = FindBag(color, bags);

            if (bag != null)
                return bag;

            // New bag
            bag = new Bag() { Color = color };

            return bag;
        }

        public Bag FindBag(string color, List<Bag> bags)
        {
            foreach (var b in bags)
            {
                if (b.Color.Equals(color))
                    return b;
            }

            foreach (var b in bags)
            {
                if (b.Bags.Count > 0)
                    return FindBag(color, b.Bags);
            }

            return null;
        }

        public bool CanContainsSantasBag(Bag bag)
        {
            foreach (var b in bag.Bags)
            {
                if (b.Color == BAG_COLOR)
                {
                    return true;
                }

                if (b.Bags.Count > 0)
                {
                    return CanContainsSantasBag(b);
                }
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

        public class Bag
        {
            public Bag()
            {
                Bags = new List<Bag>();
            }

            public string Color { get; set; }
            public List<Bag> Bags { get; set; }

            public void AddBag(Bag bag)
            {
                if (!Bags.Any(b => b.Color == bag.Color))
                {
                    Bags.Add(bag);
                }
            }
        }


    }
}
