using AdventOfCode2020.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/8
    /// </summary>
    internal class Day8 : CodePuzzleSolution<string>
    {
        public Day8(bool autoSolve = true, bool time = false) : base(8, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 8: Handheld Halting ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public int SolvePart1()
        {
            var program = new AdventOfCode2020.Business.Day8.Program(Data);

            program.Run();

            return program.Accumulator;
        }

        public int SolvePart2()
        {
            var program = new AdventOfCode2020.Business.Day8.Program();

            for (int i = 0; i < Data.Count; i++)
            {
                if (!Data[i].Contains("jmp") && !Data[i].Contains("nop"))
                    continue;

                var programCode = Data.Select(l => l).ToList();
         
                if (Data[i].Contains("jmp"))
                    programCode[i] = Data[i].Replace("jmp", "nop");
                else if (Data[i].Contains("nop"))
                    programCode[i] = Data[i].Replace("nop", "jmp");

                program.SetInstructions(programCode);
                
                if(program.Run() == 0)
                    return program.Accumulator;
            }

            return -1;
        }
    }
}
