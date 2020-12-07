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
            Console.WriteLine("ADVENT OF CODE 2020");
            Console.WriteLine("");

            m_puzzles.Add(new Day1(autoSolve: false));
            m_puzzles.Add(new Day2(autoSolve: false));
            m_puzzles.Add(new Day3(autoSolve: false));
            m_puzzles.Add(new Day4(autoSolve: false));
            m_puzzles.Add(new Day5(autoSolve: false));
            m_puzzles.Add(new Day6(autoSolve: false));
            m_puzzles.Add(new Day7(autoSolve: false));
            m_puzzles.Add(new Day8(autoSolve: true, time: true));

            m_puzzles.ForEach(p => p.Solve());
        }
    }
}
