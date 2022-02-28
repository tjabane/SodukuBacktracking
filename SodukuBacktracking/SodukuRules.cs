using SodukuBacktracking.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking
{
    public class SodukuRules
    {
        public static bool IsRowValid(int[,] grid, int row)
        {
            var nonZero = grid.GetRow(row).Where(num => num != 0);
            return nonZero.Distinct().Count() == nonZero.Count();
        }

        public static bool IsColomnValid(int[,] grid, int colomn)
        {
            var nonZero = grid.GetColomn(colomn).Where(num => num != 0);
            return nonZero.Distinct().Count() == nonZero.Count();
        }

        public static bool Is3X3GridValid(int[,] grid, int row, int colomn)
        {
            var subgrid = GetSubGrid(grid, row, colomn);
            Console.WriteLine(string.Join( ",", subgrid));
            var nonZero = subgrid.Where(num => num != 0);
            return nonZero.Distinct().Count() == nonZero.Count();
        }

        private static int[] GetSubGrid(int[,] grid, int row, int colomn)
        {
            var collector = new List<int>();
            var gridPosition = GetGridCornerPosition(row, colomn);
            var x = gridPosition.Item1;
            var y = gridPosition.Item2;
            Console.WriteLine($"({x} , {y})");
            for (int i = x; i < x + 3; i++)
                for (int j = y; j < y + 3; j++)
                    collector.Add(grid[i, j]);
            return collector.ToArray();
        }

        private static (int,int) GetGridCornerPosition(int row, int colomn)
        {
            int x = GetIndexPosition(row) * 3;
            int y = GetIndexPosition(colomn) * 3;
            return (x, y);
        }

        private static int GetIndexPosition(int index) => (int)(Math.Floor(index / 3.0));
    }
}
