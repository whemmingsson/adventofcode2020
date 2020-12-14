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
        private const int MASK_LENGTH = 36;

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
                else if (line.Contains("mem"))
                {
                    var groups = memRegex.Match(line).Groups;
                    var value = int.Parse(groups[2].Value);
                    var adress = uint.Parse(groups[1].Value);

                    foreach (var a in GetAllAdresses(mask, adress))
                    {
                        WriteToMemory(value, a);
                    }
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

        private IEnumerable<long> GetAllAdresses(string mask, long adress)
        {
            var maskedAdress = ApplyMask(adress, mask);
            
            foreach(var e in EnumCalculator.GetEnumerations(mask.Count(m => m == 'X')))
            {     
                yield return Convert.ToInt64(CreateAddress(maskedAdress, e), 2);
            }
        }

        private string CreateAddress(string adressTemplate, string binaryEnum)
        {
            var newAdress = adressTemplate.ToCharArray();
            var currentBitPos = 0;

            for (var i = 0; i < MASK_LENGTH; i++)
            {
                if (adressTemplate[i] != 'X') continue;

                newAdress[i] = binaryEnum[currentBitPos];
                currentBitPos++;
            }

            return new string(newAdress);
        }

        private string ApplyMask(long value, string mask)
        {       
            // Pad the value with zeros to make the replacement masking easier
            var binaryValue = GetPaddedBinary(value);

            var resultBinary = "";

            for (int i = 0; i < MASK_LENGTH; i++)
            {
                var maskBit = mask[i];
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

        private static string GetPaddedBinary(long value)
        { 
            var binaryValue = Convert.ToString(value, 2);
            var padLength = MASK_LENGTH - binaryValue.Length;

            for (var i = 0; i < padLength; i++)
            {
                binaryValue = "0" + binaryValue;
            }

            return binaryValue;
        }
    }
}
