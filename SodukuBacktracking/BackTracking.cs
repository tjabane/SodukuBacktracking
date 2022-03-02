using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking
{
    public class BackTracking
    {
        private readonly int[,] Grid;
        private readonly List<Tuple<int, int, int>> nodes;
       
        public BackTracking(int[,] grid)
        {
            Grid = grid;
            nodes = new List<Tuple<int,int,int>>();
        }

        public int[,] GetSolution(int[,] grid, List<Tuple<int, int, int>> nodes, int row, int colomn, bool backTrack)
        {
            if (grid[row, colomn] == 0)
            {
                // increment till a valid number and go forward 
                // else back track
                int newValue = GetValidNumber(grid, row, colomn,0);
                if (newValue != -1)
                {
                    (int,int,int) node = (row, colomn, newValue);
                    nodes.Add(node);
                    return GetSolution()
                }
                    
            }
            else if (grid[row, colomn] != 0 && HasBeenExplored(nodes, row, colomn))
            {
                // increment till a valid number and go forward 
                // else set to zero, remove from stack and back trac
            }
            else if (backTrack)
            {
                // skip this node to the previous one
            }
            else 
            {
                // skip for the next node
            }
        }

        private int GetValidNumber(int[,] grid, int row, int colomn, int currentValue = 0)
        {
            if (currentValue == 0) return GetValidNumber(grid, row, colomn, currentValue++);
            else if (currentValue < 9) return -1;
             
            if (IsValidEntry(grid, row, colomn, currentValue)) return currentValue;
            else return GetValidNumber(grid, row, currentValue);
        }

        private bool IsValidEntry(int[,] grid, int row, int colomn, int currentValue)
        {
            throw new NotImplementedException();
        }

        private bool HasBeenExplored(List<Tuple<int, int, int>> nodes, int row, int colomn)
        {
            return nodes.Any(node => node.Item1 == row && node.Item2 == colomn);
        }
    }
}
