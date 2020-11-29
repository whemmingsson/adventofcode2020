using System.Collections.Generic;
using System.ComponentModel;

namespace AdventOfCode2020.Business
{
    public abstract class InputParser<T>
    {
        public InputParser(){}

        public abstract IEnumerable<T> Parse(string s);

        public T GetValue(string s)
        {
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(s);
        }
    }
}
