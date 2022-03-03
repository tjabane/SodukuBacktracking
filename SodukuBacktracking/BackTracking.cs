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

        public int[,] GetSolution(int[,] grid, List<(int, int, int)> nodes, int row, int colomn, bool backTrack)
        {
            if (grid[row, colomn] == 0)
            {
                // increment till a valid number and go forward 
                // else back track
                int newValue = GetValidNumber(grid, row, colomn,0);
                if (newValue != -1)
                {
                    (int, int, int) node = (row, colomn, newValue);
                    nodes.Add(node);
                    var nextNode = GetNextNode(row, colomn);
                    return GetSolution(grid, nodes, nextNode.Item1, nextNode.Item2, false);
                }
                else {
                    var lastNode = nodes.LastOrDefault();
                    return GetSolution(grid, nodes, lastNode.Item1, lastNode.Item2, true);
                }
            }
            else if (grid[row, colomn] != 0 && HasBeenExplored(nodes, row, colomn))
            {
                // increment till a valid number and go forward 
                // else set to zero, remove from stack and back trac
                var currentNode = nodes.LastOrDefault();
                int newValue = GetValidNumber(grid, row, colomn, currentNode.Item3);
                if (newValue != -1)
                {
                    (int, int, int) node = (row, colomn, newValue);
                    nodes.Add(node);
                    var nextNode = GetNextNode(row, colomn);
                    return GetSolution(grid, nodes, nextNode.Item1, nextNode.Item2, false);
                }
                else 
                {
                    grid[row, colomn] = 0;
                    nodes.RemoveAt(nodes.Count - 1);
                    var lastNode = nodes.LastOrDefault();
                    return GetSolution(grid, nodes, lastNode.Item1, lastNode.Item2, true);
                }
            }
            else if (grid[row, colomn] != 0 && !HasBeenExplored(nodes, row, colomn))
            {
                // skip this node to the previous one
                var nextNode = GetNextNode(row, colomn);
                return GetSolution(grid, nodes, nextNode.Item1, nextNode.Item2, false);
            }
            else 
            {
                // skip for the next node
                return grid;
            }
        }
        private int GetValidNumber(int[,] grid, int row, int colomn, int currentValue = 0)
        {
            if (currentValue == 0) return GetValidNumber(grid, row, colomn, currentValue++);
            else if (currentValue > 9) return -1;

            if (IsValidEntry(grid, row, colomn, currentValue)) return currentValue;
            else return GetValidNumber(grid, row, currentValue);
        }

        private (int, int) GetNextNode(int currentRow, int currentColomn)
        {
            if (currentColomn < 8)
                return (currentRow, currentColomn++);
            else if(currentColomn == 8 && currentRow < 8)
                return (currentRow++, 0);
            else 
                return (0, 0);
        }

        private bool IsValidEntry(int[,] grid, int row, int colomn, int currentValue)
        {
            throw new NotImplementedException();
        }

        private bool HasBeenExplored(List<(int, int, int)> nodes, int row, int colomn)
        {
            return nodes.Any(node => node.Item1 == row && node.Item2 == colomn);
        }
    }
}
