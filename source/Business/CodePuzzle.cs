using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace AdventOfCode2020.Business
{
    public abstract class CodePuzzleSolution<T> : ISolvable
    {
        private Stopwatch _watch { get; set; }
        private bool _time { get; set; }
        public bool AutoSolve { get; set; }
        public List<T> Data { get; set; }
        public Bitmap ImageData { get; set; }  
        public CodePuzzleSolution(int day, InputParser<T> parser, bool autoSolve = true, bool time = false)
        {
            AutoSolve = autoSolve;

            if (!AutoSolve || day == Constants.CUSTOM_DATA)
                return;

            try 
            { 
                Data = InputReader.GetInputFromFile(day, parser).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            _time = time;

            if(_time)
             _watch = new Stopwatch();
        }

        protected string SolveWithFun<U>(Func<U> solveFunc)
        {
            if (_time)
            {
                _watch.Reset();
                _watch.Start();
            }
               
            var res = solveFunc();


            if(_time)
                _watch.Stop();

            return res + Time();
        }

        private string Time()
        {
            if (!_time)
                return "";

            if(_watch.ElapsedMilliseconds > 0)
                return $" ({_watch.ElapsedMilliseconds} ms)";

            return $" ({_watch.ElapsedTicks} ticks)";
        }

        public abstract void Solve();
    }
}
