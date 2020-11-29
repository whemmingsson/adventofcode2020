using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Business
{
    public static class Extensions
    {
        public static List<List<T>> Split<T>(this List<T> items, int sliceSize)
        {
            List<List<T>> list = new List<List<T>>();
            for (int i = 0; i < items.Count; i += sliceSize)
                list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
            return list;
        }

        public static List<List<T>> SplitInHalf<T>(this List<T> items)
        {
            return items.Split(items.Count / 2);
        }

        public static string[] SplitInHalf(this string str) 
            => 
            new string[]
            {
                str.Substring(0, (int)(str.Length / 2)), str.Substring((int)(str.Length / 2), (int)(str.Length / 2))
            };
     
    }
}
