using AdventOfCode2020.Business.Day14;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.TestingGround
{
    public static class Test
    {
        public static void Run()
        {
            var enumerations = EnumCalculator.GetEnumerations(4);
            foreach(var e in enumerations)
            {
                Console.Write(e + ",");
            }
        }
    }

  
}
