using SodukuBacktracking.Exceptions;
using SodukuBacktracking.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking
{
    public class BackTracking
    {
        private static readonly int MaximumIterations = 10000000;
        public int[,] Solve(int[,] grid)
        {
            if (SodukuRules.GridValid(grid))
                throw new InvalidGridException("Soduku contains repeating numbers");
            var nodes = new List<(int, int, int)>();
            return GetLoopMethodSolution(grid, nodes);
        }

        private static int[,] GetLoopMethodSolution(int[,] grid, List<(int, int, int)> nodes)
        {
            (int, int) positionNode = (0, 0);
            for (int i = 0; i < MaximumIterations; i++)
            {
                var row = positionNode.Item1;
                var colomn = positionNode.Item2;
                if (SodukuRules.IsSodukuSolved(grid))
                    return grid;
                

                if (grid[row, colomn] == 0)
                {
                    int newValue = GetValidNumber(grid, row, colomn, 0);
                    if (newValue != -1)
                    {
                        grid[row, colomn] = newValue;
                        (int, int, int) node = (row, colomn, newValue);
                        nodes.Add(node);
                        positionNode = GetNextNode(row, colomn);
                    }
                    else
                    {
                        var lastNode = nodes.LastOrDefault();
                        positionNode = (lastNode.Item1, lastNode.Item2);
                    }
                }
                else if (grid[row, colomn] != 0 && HasBeenExplored(nodes, row, colomn))
                {
                    var currentNode = nodes.LastOrDefault();
                    int newValue = GetValidNumber(grid, row, colomn, currentNode.Item3);
                    if (newValue != -1)
                    {
                        grid[row, colomn] = newValue;
                        nodes.Remove(currentNode);
                        (int, int, int) node = (row, colomn, newValue);
                        nodes.Add(node);
                        positionNode = GetNextNode(row, colomn);
                    }
                    else
                    {
                        grid[row, colomn] = 0;
                        nodes.Remove(nodes.LastOrDefault());
                        if (nodes.Count == 0)
                            throw new UnSolvableException("No solution exists");
                        var lastNode = nodes.LastOrDefault();
                        positionNode = (lastNode.Item1, lastNode.Item2);
                    }
                }
                else if (grid[row, colomn] != 0 && !HasBeenExplored(nodes, row, colomn))
                {
                    positionNode = GetNextNode(row, colomn);
                }
            }
            throw new UnSolvableException("Maximun iterations exceeded");
        }

        private int[,] GetSolution(int[,] grid, List<(int, int, int)> nodes, int row=0, int colomn=0)
        {
            if (SodukuRules.IsSodukuSolved(grid))
                return grid;
            if (grid[row, colomn] == 0)
            {
                int newValue = GetValidNumber(grid, row, colomn, 0);
                if (newValue != -1)
                {
                    grid[row, colomn] = newValue;
                    (int, int, int) node = (row, colomn, newValue);
                    nodes.Add(node);
                    var nextNode = GetNextNode(row, colomn);
                    return GetSolution(grid, nodes, nextNode.Item1, nextNode.Item2);
                }
                else
                {
                    var lastNode = nodes.LastOrDefault();
                    return GetSolution(grid, nodes, lastNode.Item1, lastNode.Item2);
                }
            }
            else if (grid[row, colomn] != 0 && HasBeenExplored(nodes, row, colomn))
            {
                var currentNode = nodes.LastOrDefault();
                int newValue = GetValidNumber(grid, row, colomn, currentNode.Item3);
                if (newValue != -1)
                {
                    grid[row, colomn] = newValue;
                    nodes.Remove(currentNode);
                    (int, int, int) node = (row, colomn, newValue);
                    nodes.Add(node);
                    var nextNode = GetNextNode(row, colomn);
                    return GetSolution(grid, nodes, nextNode.Item1, nextNode.Item2);
                }
                else
                {

                    grid[row, colomn] = 0;
                    nodes.Remove(nodes.LastOrDefault());
                    var lastNode = nodes.LastOrDefault();
                    return GetSolution(grid, nodes, lastNode.Item1, lastNode.Item2);
                }
            }
            else if (grid[row, colomn] != 0 && !HasBeenExplored(nodes, row, colomn))
            {
                var nextNode = GetNextNode(row, colomn);
                return GetSolution(grid, nodes, nextNode.Item1, nextNode.Item2);
            }
            else if (row == 8 && colomn == 8)
            {
                return grid;
            }
            else
                return grid;

        }
        private static int GetValidNumber(int[,] grid, int row, int colomn, int currentValue = 0)
        {
            if (currentValue == 0) 
                return GetValidNumber(grid, row, colomn, ++currentValue);
            else if (currentValue > 9) 
                return -1;

            if (SodukuRules.IsValidEntry(grid, row, colomn, currentValue)) return currentValue;
            else return GetValidNumber(grid, row, colomn, ++currentValue);
        }

        private static (int, int) GetNextNode(int currentRow, int currentColomn)
        {
            if (currentColomn < 8)
                return (currentRow, ++currentColomn);
            else if(currentColomn == 8 && currentRow < 8)
                return (++currentRow, 0);
            else 
                return (0, 0);
        }

        private static bool HasBeenExplored(List<(int, int, int)> nodes, int row, int colomn)
        {
            return nodes.Any(node => node.Item1 == row && node.Item2 == colomn);
        }
    }
}
