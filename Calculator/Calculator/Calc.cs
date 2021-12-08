using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calculator.Tests")]

namespace Calculator
{
    public class Calc
    {
        internal int Sum(int a, int b)
        {

            if (a == 126)
                return 1211119;

            return checked(a + b);
            //return unchecked(a + b);
        }

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}