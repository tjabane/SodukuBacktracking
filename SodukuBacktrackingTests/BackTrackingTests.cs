using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using SodukuBacktracking;
using SodukuBacktracking.Exceptions;

namespace SodukuBacktrackingTests
{
    public class BackTrackingTests
    {
        [Test]
        public void ShouldSolveSodukuWhenGridSolvable()
        {
            var problem = GetSolvableSoduku();

            var results = BackTracking.Solve(problem);
            var isSolved = SodukuRules.IsSodukuSolved(results);

            isSolved.ShouldBeTrue();
        }

        [Test]
        public void ShouldThrowErrorWhenSodukuUnSolvable()
        {
            var problem = GetUnSolvableSoduku();
            var backTracking = new BackTracking();

            var exception = Assert.Throws<UnSolvableException>(() => BackTracking.Solve(problem));
            exception.Message.ShouldBe("Maximun iterations exceeded");
        }

        [Test]
        public void ShouldReturnFalseWhenSodukuInvalid()
        {
            var soduku = GetInvalidSoduku();
            var backTracking = new BackTracking();

            var exception = Assert.Throws<InvalidGridException>(() => BackTracking.Solve(soduku));
            exception.Message.ShouldBe("Soduku contains repeating numbers");
        }

        private static int[,] GetInvalidSoduku()
        {
            int[,] grid =   {{ 3, 3, 6, 5, 0, 8, 4, 0, 0},
                             { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                             { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                             { 0, 0, 3, 0, 1, 0, 0, 8, 1},
                             { 9, 0, 0, 8, 6, 3, 0, 0, 5},
                             { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                             { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                             { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                             { 0, 0, 5, 2, 0, 6, 3, 0, 2}};
            return grid;
        }



        private static int[,] GetSolvableSoduku()
        {
            int[,] grid =   {{ 3, 0, 6, 5, 0, 8, 4, 0, 0}, 
                             { 5, 2, 0, 0, 0, 0, 0, 0, 0}, 
                             { 0, 8, 7, 0, 0, 0, 0, 3, 1}, 
                             { 0, 0, 3, 0, 1, 0, 0, 8, 0}, 
                             { 9, 0, 0, 8, 6, 3, 0, 0, 5}, 
                             { 0, 5, 0, 0, 9, 0, 6, 0, 0}, 
                             { 1, 3, 0, 0, 0, 0, 2, 5, 0}, 
                             { 0, 0, 0, 0, 0, 0, 0, 7, 4}, 
                             { 0, 0, 5, 2, 0, 6, 3, 0, 0}};
            return grid;
        }

        private static int[,] GetUnSolvableSoduku()
        {
            int[,] grid =   {{ 2, 0, 0, 9, 0, 0, 0, 0, 0},
                             { 0, 0, 0, 0, 0, 0, 0, 6, 0},
                             { 0, 0, 0, 0, 0, 1, 0, 0, 0},
                             { 5, 0, 2, 6, 0, 0, 4, 0, 7},
                             { 0, 0, 0, 0, 0, 4, 1, 0, 0},
                             { 0, 0, 0, 0, 9, 8, 0, 2, 3},
                             { 0, 0, 0, 0, 0, 3, 0, 8, 0},
                             { 0, 0, 5, 0, 1, 0, 0, 0, 0},
                             { 0, 0, 7, 0, 0, 0, 0, 0, 0}};
            return grid;
        }

    }
}
