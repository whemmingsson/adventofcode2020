using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Day14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    internal partial class Day14 : CodePuzzleSolution<string>
    {
        private Dictionary<long, long> memory;
        public Day14(bool autoSolve = true, bool time = false) : base(14, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 14: Docking Data ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public long SolvePart1()
        {
            memory = new Dictionary<long, long>();

            var maskRegex = new Regex("[01X]+");
            var memRegex = new Regex("mem\\[(\\d+)\\] = (\\d+)");

            long zeroMask = 0, oneMask = 0;

            foreach (var line in Data)
            {
                if (line.Contains("mask"))
                {
                    var mask = maskRegex.Match(line).Value;
                    zeroMask = Convert.ToInt64(mask.Replace("X", "1"), 2);
                    oneMask = Convert.ToInt64(mask.Replace("X", "0"), 2);
                }

                if(line.Contains("mem"))
                {
                    var groups = memRegex.Match(line).Groups;
                    WriteToMemory(int.Parse(groups[2].Value) & zeroMask | oneMask, int.Parse(groups[1].Value));
                }
            }

            return SumMemory();
        }

        private void WriteToMemory(long value, long adress)
        {
            if (memory.ContainsKey(adress))
                memory[adress] = value;
            else
                memory.Add(adress, value);
        }

        private long SumMemory()
        {
            return memory.Values.Sum(v => v);
        }

        public long SolvePart2()
        {
            memory = new Dictionary<long, long>();

            var maskRegex = new Regex("[01X]+");
            var memRegex = new Regex("mem\\[(\\d+)\\] = (\\d+)");

            var mask = "";
            foreach (var line in Data)
            {
                if (line.Contains("mask"))
                {
                    mask = maskRegex.Match(line).Value.Trim();
                }

                if (line.Contains("mem"))
                {
                    var groups = memRegex.Match(line).Groups;
                    var value = int.Parse(groups[2].Value);
                    var adress = uint.Parse(groups[1].Value);

                    foreach(var a in ApplyMask(mask, adress))
                    {
                        WriteToMemory(value, a);
                    }
                }
            }

            return SumMemory();
        }

        private List<long> ApplyMask(string mask, long adress)
        {
            var numOfFloatingBits = mask.Count(m => m == 'X');

            var result = new List<long>();

            var maskedAdress = ApplyOrMask(adress, mask);
            
            foreach(var e in EnumCalculator.GetEnumerations(numOfFloatingBits))
            {
                var currentBit = 0;
                var newAdress = maskedAdress.ToCharArray();
                for(var i = 0; i < maskedAdress.Length; i++)
                {
                    if (maskedAdress[i] != 'X') continue;

                    newAdress[i] = e[currentBit];
                    currentBit++;
                }
                result.Add((Convert.ToInt64(new string(newAdress), 2)));
            }

            return result;
        }

        private string ApplyOrMask(long value, string mask)
        {
            var binaryValue = Convert.ToString(value, 2);
            var maskTrimmed = mask.Substring(mask.Length - binaryValue.Length, binaryValue.Length);

            var resultBinary = "";

            for(int i = 0; i < binaryValue.Length; i++)
            {
                var maskBit = maskTrimmed[i];
                var valueBit = binaryValue[i];

                if (maskBit == 'X')
                    resultBinary += 'X';
                else if (maskBit == '1')
                    resultBinary += '1';
                else
                    resultBinary += valueBit;             
            }

            return resultBinary;
        }
    }
}
