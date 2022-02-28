using NUnit.Framework;
using Shouldly;
using SodukuBacktracking;

namespace SodukuBacktrackingTests
{
    public class SodukuRulesTests
    {
        [Test]
        public void ShouldReturnTrueWhenNoRepeatingNumbersInRow()
        {
            int row = 0;
            int[,] grid = { { 3, 0, 6, 5, 0, 8, 4, 0, 0 } };

            var result = SodukuRules.IsRowValid(grid, row);

            result.ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnFalseWhenRepeatingNumbersInRow()
        {
            int row = 0;
            int[,] grid = { { 3, 0, 3, 3, 0, 8, 4, 0, 0 } };

            var result = SodukuRules.IsRowValid(grid, row);

            result.ShouldBeFalse();
        }


        [Test]
        public void ShouldReturnTrueWhenNoRepeatingNumbersInColomn()
        {
            int colomn = 0;
            int[,] grid = { {1, 2, 3 }, { 4, 5, 6 } };

            var result = SodukuRules.IsColomnValid(grid, colomn);

            result.ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnFalseWhenRepeatingNumbersInColomn()
        {
            int colomn = 0;
            int[,] grid = { { 1, 2, 3 }, { 1, 5, 6 } };

            var result = SodukuRules.IsColomnValid(grid, colomn);

            result.ShouldBeFalse();
        }

        [Test]
        public void ShouldReturnTrueWhenNoRepeatingNumbersInSubBlock()
        {
            int colomn = 1;
            int row = 6;
            int[,] grid = {{3, 0, 6, 5, 0, 8, 4, 0, 0},
                           {5, 2, 0, 0, 0, 0, 0, 0, 0},
                           {0, 8, 7, 0, 0, 0, 0, 3, 1},
                           {0, 0, 3, 0, 1, 0, 0, 8, 0},
                           {9, 0, 0, 8, 6, 3, 0, 0, 5},
                           {0, 5, 0, 0, 9, 0, 6, 0, 0},
                           {1, 3, 0, 0, 0, 0, 2, 5, 0},
                           {0, 0, 0, 0, 0, 0, 0, 7, 4},
                           {0, 0, 5, 2, 0, 6, 3, 0, 0}};

            var result = SodukuRules.Is3X3GridValid(grid, row, colomn);

            result.ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnFalseWhenRepeatingNumbersInSubBlock()
        {
            int colomn = 1;
            int row = 1;
            int[,] grid = {{3, 3, 6, 5, 0, 8, 4, 0, 0},
                           {5, 2, 0, 0, 0, 0, 0, 0, 0},
                           {0, 8, 7, 0, 0, 0, 0, 3, 1}};

            var result = SodukuRules.Is3X3GridValid(grid, row, colomn);

            result.ShouldBeFalse();
        }
    }
}
