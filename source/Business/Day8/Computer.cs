using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2020.Business.Day8
{
    internal class Computer
    {
        private Hashtable executedInstructions;
        private int pointer;
        private Dictionary<string, Action<int>> operations;

        public enum ExitCode
        {
            Success = 0, InfiniteLoop = 1
        }

        public int Accumulator { get; set; }

        public Computer() { }

        public ExitCode Run(List<string> instructions)
        {
            Reset();

            while(true)
            {
                if (pointer >= instructions.Count)
                    return ExitCode.Success;

                if (executedInstructions.ContainsKey(pointer))
                    return ExitCode.InfiniteLoop;

                ExecuteInstruction(ParseInstruction(instructions[pointer]));             
            } 

            void ExecuteInstruction((string op, int value) instruction)
            {
                executedInstructions.Add(pointer, true);
                operations[instruction.op](instruction.value);               
            }
        }

        private void Reset()
        {
            Accumulator = 0;
            executedInstructions = new Hashtable();
            pointer = 0;

            operations = new Dictionary<string, Action<int>> 
            {
                { "acc", v => { Accumulator += v; pointer++; } },
                { "jmp", v => pointer += v },
                { "nop", v => pointer++ }
            };
        }

        public static string GetOperation(string instruction)
        {
            return ParseInstruction(instruction).op;
        }

        private static (string op, int value) ParseInstruction(string instruction)
        {
            var instructionParts = instruction.Split(" ");
            return (instructionParts[0], int.Parse(instructionParts[1]));
        }
    }
}
