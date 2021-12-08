using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Calc_Sum_2_and_3_results_5()
        {
            //arrange
            var calc = new Calc();

            //act
            int result = calc.Sum(2, 3);

            //assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calc_Sum_0_and_0_results_0()
        {
            //arrange
            var calc = new Calc();

            //act
            int result = calc.Sum(0, 0);

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(1000, 4567, 5567)]
        [InlineData(-1, 1, 0)]
        [InlineData(-1, -1, -2)]
        [InlineData(-100, -12, -112)]
        public void Calc_Sum(int a, int b, int expected)
        {
            var calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MaxValue - 1, 2)]
        [InlineData(int.MinValue, -1)]
        public void Calc_Sum_throws_OverflowException(int a, int b)
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }

    }
}
