using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using SodukuBacktracking;

namespace SodukuBacktrackingTests
{
    public class BackTrackingTests
    {
        [Test]
        public void ShouldSolveSodukuWhenGridSolvable()
        {
            var problem = GetSolvableSoduku();
            var backTracking = new BackTracking(problem);

            var results = backTracking.Solve(problem);
            var isSolved = SodukuRules.IsSodukuSolved(results);

            isSolved.ShouldBeTrue();
        }

        private static int[,] GetSolvableSoduku()
        {
            int[,] grid =  { { 3, 0, 6, 5, 0, 8, 4, 0, 0}, 
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

    }
}
