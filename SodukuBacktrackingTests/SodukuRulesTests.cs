using NUnit.Framework;
using Shouldly;
using SodukuBacktracking;

namespace SodukuBacktrackingTests
{
    public class SodukuRulesTests
    {
        [Test]
        public void ShouldReturnTrueWhenNumberDoesntRepeat()
        {
            int row = 0;
            int col = 1;
            int entry = 1;
            int[,] soduku =  {{ 3, 0, 6, 5, 0, 8, 4, 0, 0},
                              { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                              { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                              { 0, 0, 3, 0, 1, 0, 0, 8, 0},
                              { 9, 0, 0, 8, 6, 3, 0, 0, 5},
                              { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                              { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                              { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                              { 0, 0, 5, 2, 0, 6, 3, 0, 0}};

            var result = SodukuRules.IsValidEntry(soduku, row, col, entry);

            result.ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnFalseWhenNumberRepeats()
        {
            int row = 0;
            int col = 1;
            int entry = 3;
            int[,] soduku =  {{ 3, 0, 6, 5, 0, 8, 4, 0, 0},
                              { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                              { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                              { 0, 0, 3, 0, 1, 0, 0, 8, 0},
                              { 9, 0, 0, 8, 6, 3, 0, 0, 5},
                              { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                              { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                              { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                              { 0, 0, 5, 2, 0, 6, 3, 0, 0}};

            var result = SodukuRules.IsValidEntry(soduku, row, col, entry);

            result.ShouldBeFalse();
        }

        [Test]
        public void ShouldReturnTrueWhenSodukuIsSolved()
        {
            int[,] solvedGrid = {{3,1,6,5,7,8,4,9,2},
                                 {5,2,9,1,3,4,7,6,8},
                                 {4,8,7,6,2,9,5,3,1},
                                 {2,6,3,4,1,5,9,8,7},
                                 {9,7,4,8,6,3,1,2,5},
                                 {8,5,1,7,9,2,6,4,3},
                                 {1,3,8,9,4,7,2,5,6},
                                 {6,9,2,3,5,1,8,7,4},
                                 {7,4,5,2,8,6,3,1,9}};

            var result = SodukuRules.IsSodukuSolved(solvedGrid);

            result.ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnFalseWhenSodukuIsIncomplete()
        {
            int[,] solvedGrid = {{3,1,6,5,7,8,4,9,2},
                                 {5,2,9,1,3,4,7,6,8},
                                 {4,8,7,6,2,9,5,3,1},
                                 {2,6,3,4,1,5,9,8,7},
                                 {9,7,4,8,6,3,1,2,5},
                                 {8,5,1,7,9,2,6,4,3},
                                 {1,3,8,9,4,7,2,5,6},
                                 {6,9,2,3,5,1,8,7,4},
                                 {7,4,5,2,8,6,3,1,0}};

            var result = SodukuRules.IsSodukuSolved(solvedGrid);

            result.ShouldBeFalse();
        }

        [Test]
        public void ShouldReturnTrueWhenSodukuHasRepeatingNumbersInRow()
        {
            int[,] soduku =  {{ 3, 3, 3, 3, 3, 3, 3, 3, 3},
                              { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                              { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                              { 0, 0, 3, 0, 1, 0, 0, 8, 0},
                              { 9, 0, 0, 8, 6, 3, 0, 0, 5},
                              { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                              { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                              { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                              { 0, 0, 5, 2, 0, 6, 3, 0, 0}};

            var result = SodukuRules.GridValid(soduku);

            result.ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnTrueWhenSodukuHasRepeatingNumbersInColomn()
        {
            int[,] soduku =  {{ 3, 0, 6, 5, 0, 8, 4, 0, 0},
                              { 5, 2, 0, 5, 0, 0, 0, 0, 0},
                              { 0, 8, 7, 5, 0, 0, 0, 3, 1},
                              { 0, 0, 3, 5, 1, 0, 0, 8, 0},
                              { 9, 0, 0, 5, 6, 3, 0, 0, 5},
                              { 0, 5, 0, 5, 9, 0, 6, 0, 0},
                              { 1, 3, 0, 5, 0, 0, 2, 5, 0},
                              { 0, 0, 0, 5, 0, 0, 0, 7, 4},
                              { 0, 0, 5, 5, 0, 6, 3, 0, 0}};

            var result = SodukuRules.GridValid(soduku);

            result.ShouldBeTrue();
        }


        [Test]
        public void ShouldReturnTrueWhenSodukuHasRepeatingNumbersInSubGrid()
        {
            int[,] soduku =  {{ 3, 0, 6, 5, 0, 8, 4, 0, 0},
                              { 5, 3, 0, 5, 0, 0, 0, 0, 0},
                              { 0, 8, 7, 5, 0, 0, 0, 3, 1},
                              { 0, 0, 3, 5, 1, 0, 0, 8, 0},
                              { 9, 0, 0, 5, 6, 3, 0, 0, 5},
                              { 0, 5, 0, 5, 9, 0, 6, 0, 0},
                              { 1, 3, 0, 5, 0, 0, 2, 5, 0},
                              { 0, 0, 0, 5, 0, 0, 0, 7, 4},
                              { 0, 0, 5, 5, 0, 6, 3, 0, 0}};

            var result = SodukuRules.GridValid(soduku);

            result.ShouldBeTrue();
        }


    }
}



