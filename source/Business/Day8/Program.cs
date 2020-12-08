using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2020.Business.Day8
{
    internal class Program
    {
        private Hashtable executedInstructions;
        private int currentInstruction;
        private List<string> instructions;
        private Dictionary<string, Action<int>> operations;

        enum ExitCodes
        {
            Success = 0, 
            InfiniteLoop = 1,
            Unknown = 2
        }

        public int Accumulator { get; set; }

        public Program() { }

        public Program(List<string> instructions)
        {
            this.SetInstructions(instructions);
        }

        public void SetInstructions(List<string> instructions)
        {
            this.instructions = instructions;
        }

        public int Run()
        {
            Reset();

            while(true)
            {
                if (currentInstruction >= instructions.Count)
                    return (int)ExitCodes.Success;

                if (executedInstructions.ContainsKey(currentInstruction))
                    return (int)ExitCodes.InfiniteLoop;

                executedInstructions.Add(currentInstruction, true);

                var instructionParts = instructions[currentInstruction].Split(" ");
                operations[instructionParts[0]](int.Parse(instructionParts[1]));
            } 
        }

        public void Reset()
        {
            Accumulator = 0;
            executedInstructions = new Hashtable();
            currentInstruction = 0;

            operations = new Dictionary<string, Action<int>> 
            {
                { "acc", v => { Accumulator += v; currentInstruction++; } },
                { "jmp", v => currentInstruction += v },
                { "nop", v => currentInstruction++ }
            };
        }
    }
}
