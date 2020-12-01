using AdventOfCode2020.Business;
using AdventOfCode2020.Solutions;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Program
    {
        private static readonly List<ISolvable> m_puzzles = new List<ISolvable>();

        static void Main()
        {
            Console.WriteLine("ADVENT OF CODE");
            Console.WriteLine("");

            m_puzzles.Add(new Day1(autoSolve: true, time: true));

            m_puzzles.ForEach(p => p.Solve());
        }
    }
}
