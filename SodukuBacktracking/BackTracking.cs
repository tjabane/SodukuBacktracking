using SodukuBacktracking.Exceptions;
using SodukuBacktracking.Extensions;
using SodukuBacktracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking
{
    public class BackTracking
    {
        private static readonly int MaximumIterations = 1000000;
        public static int[,] Solve(int[,] grid)
        {
            if (SodukuRules.GridValid(grid))
                throw new InvalidGridException("Soduku contains repeating numbers");
            var nodes = new List<Node>();
            return GetLoopMethodSolution(grid, nodes);
        }

        private static int[,] GetLoopMethodSolution(int[,] grid, List<Node> nodes)
        {
            var position = new Position();
            for (int i = 0; i < MaximumIterations; i++)
            {
                var row = position.Row;
                var colomn = position.Colomn;
                if (SodukuRules.IsSodukuSolved(grid))
                    return grid;

                if (grid[row, colomn] == 0)
                {
                    int newValue = GetValidNumber(grid, row, colomn);
                    if (newValue != -1)
                    {
                        grid[row, colomn] = newValue;
                        var node = Node.CreateNode(row, colomn, newValue);
                        nodes.Add(node);
                        position = GetNextNode(row, colomn);
                    }
                    else
                        position = GetLastPosition(nodes);
                }
                else if (grid[row, colomn] != 0 && HasBeenExplored(nodes, row, colomn))
                {
                    var currentNode = nodes.Last();
                    int newValue = GetValidNumber(grid, row, colomn, currentNode.Value);
                    if (newValue != -1)
                    {
                        grid[row, colomn] = newValue;
                        nodes.Remove(currentNode);
                        var node = Node.CreateNode(row, colomn, newValue);
                        nodes.Add(node);
                        position = GetNextNode(row, colomn);
                    }
                    else
                    {
                        grid[row, colomn] = 0;
                        nodes.Remove(nodes.Last());
                        if (nodes.Count == 0)
                            throw new UnSolvableException("No solution exists");
                        position = GetLastPosition(nodes);
                    }
                }
                else
                    position = GetNextNode(row, colomn);
            }
            throw new UnSolvableException("Maximun iterations exceeded");
        }

        private static Position GetLastPosition(List<Node> nodes)
        {
            var lastNode = nodes.Last();
            return lastNode.ToPosition();
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

        private static Position GetNextNode(int currentRow, int currentColomn)
        {
            if (currentColomn < 8)
                return Position.GetPosition(currentRow, ++currentColomn);
            else if(currentColomn == 8 && currentRow < 8)
                return Position.GetPosition(++currentRow, 0);
            else 
                return Position.GetPosition(0, 0);
        }

        private static bool HasBeenExplored(List<Node> nodes, int row, int colomn)
        {
            return nodes.Any(node => node.Row == row && node.Colomn == colomn);
        }
    }
}
