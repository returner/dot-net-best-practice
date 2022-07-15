using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class LengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x.Length == y.Length)
            {
                return 0;
            }

            return (x.Length > y.Length) ? 1 : -1;
        }
    }
}
