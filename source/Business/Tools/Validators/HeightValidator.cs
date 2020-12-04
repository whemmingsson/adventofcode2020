using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Business.Tools.Validators
{
    public static class HeightValidator
    {
        public static bool IsInRange(string value, params (string unit, (int lower, int upper) limit)[] rangeConfigs)
        {
            foreach (var (unit, limit) in rangeConfigs)
            {
                if (!value.Contains(unit))
                    continue;

                return RangeValidator.IsInRange(value[0..^unit.Length], limit.lower, limit.upper);
             }

            return false;
        }
    }
}