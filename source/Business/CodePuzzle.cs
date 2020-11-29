using AdventOfCode2020.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2020.Business
{
    public abstract class CodePuzzleSolution<T> : ISolvable
    {
        public bool SolveNow { get; set;}
        public List<T> Data { get; set; }

        public Bitmap ImageData { get; set; }
        public CodePuzzleSolution(int day, InputParser<T> parser, bool autoSolve = true)
        {
            SolveNow = autoSolve;

            if (!SolveNow || day == Constants.CUSTOM_DATA)
                return;

            try 
            { 
                Data = InputReader.GetInputFromFile(day, parser).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }

        public abstract void Solve();
    }
}
