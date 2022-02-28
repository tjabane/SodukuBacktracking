using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking.Extensions
{
    public static class ArrayExt
    {
        public static int[] GetRow(this int[,] nestedArray, int rowNum )
        {
            var columnSize = nestedArray.GetLength(1);
            return Enumerable.Range(0, columnSize).Select(index => nestedArray[rowNum, index])
                                                  .ToArray();
        }

        public static int[] GetColomn(this int[,] nestedArray, int columnNum)
        {
            var rowsNum = nestedArray.GetLength(0);
            return Enumerable.Range(0, rowsNum).Select(index => nestedArray[index, columnNum])
                                                .ToArray();
        }
    }

}
