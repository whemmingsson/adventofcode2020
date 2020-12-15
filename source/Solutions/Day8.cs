using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Day8;
using System;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/8
    /// </summary>
    internal class Day8 : CodePuzzleSolution<string>
    {
        public Day8(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

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
            var computer = new Computer();
            computer.Run(Data);
            return computer.Accumulator;
        }

        public int SolvePart2()
        {
            var computer = new Computer();

            for (var i = 0; i < Data.Count; i++)
            {
                if (!Data[i].Contains("jmp") && !Data[i].Contains("nop"))
                    continue;

                var programCode = Data.Select(l => l).ToList();

                var op = Computer.GetOperation(Data[i]);
                programCode[i] = Data[i].Replace(op, OtherInstruction(op));

                if(computer.Run(programCode) == Computer.ExitCode.Success)
                    return computer.Accumulator;
            }

            return -1;

            static string OtherInstruction(string instruction)
            {
                return instruction == "jmp" ? "nop" : "jmp";
            }
        }
    }
}
