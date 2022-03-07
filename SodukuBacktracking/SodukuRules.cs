using SodukuBacktracking.Extensions;

namespace SodukuBacktracking
{
    public class SodukuRules
    {
        public static bool IsValidEntry(int[,] grid, int row, int colomn, int number)
        {
            return IsValueValidForRow(grid, row, number) && IsValueValidForColomn(grid, colomn, number) 
                                                         && IsValueValidForSubGrid(grid, row, colomn, number);
        }

        private static bool IsValueValidForRow(int[,] grid, int row, int number)
        {
            return !grid.GetRow(row).Any(num => num == number);
        }
        private static bool IsValueValidForColomn(int[,] grid, int colomn, int number)
        {
            return !grid.GetColomn(colomn).Any(num => num == number);
        }

        private static bool IsValueValidForSubGrid(int[,] grid, int row, int colomn, int number)
        {
            var subgrid = GetSubGrid(grid, row, colomn);
            return !subgrid.Any(num => num == number);
        }

        public static bool IsSodukuSolved(int[,] grid)
        {
            var rowColCheck = Enumerable.Range(0, 9).All(n => !HasZeros(grid, n) && IsRowValid(grid, n) && IsColomnValid(grid, n));
            var subGridCheck = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Is3X3GridValid(grid, i * 3, j * 3))
                    {
                        subGridCheck = false;
                        break;
                    }
                }
            }
            return rowColCheck && subGridCheck;
        }

        private static bool IsRowValid(int[,] grid, int row)
        {
            var nonZero = grid.GetRow(row).Where(num => num != 0);
            return HasDuplicates(nonZero);
        }

        private static bool IsColomnValid(int[,] grid, int colomn)
        {
            var nonZero = grid.GetColomn(colomn).Where(num => num != 0);
            return HasDuplicates(nonZero);
        }

        private static bool Is3X3GridValid(int[,] grid, int row, int colomn)
        {
            var subgrid = GetSubGrid(grid, row, colomn);
            var nonZero = subgrid.Where(num => num != 0);
            return HasDuplicates(nonZero);
        }

        private static bool HasZeros(int[,] grid,int row)
        {
            return grid.GetRow(row).Any(num => num == 0);
        }

        private static bool HasDuplicates(IEnumerable<int> numbers) => numbers.Distinct().Count() == numbers.Count();

        private static int[] GetSubGrid(int[,] grid, int row, int colomn)
        {
            var collector = new List<int>();
            var gridPosition = GetGridCornerPosition(row, colomn);
            var x = gridPosition.Item1;
            var y = gridPosition.Item2;
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

        private static int GetIndexPosition(int index) => (int) Math.Floor(index / 3.0);

    }
}
