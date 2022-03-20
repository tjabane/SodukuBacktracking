using SodukuBacktracking.Exceptions;

namespace SodukuBacktracking.Model
{
    public class Node
    {
        private Node(int row, int colomn, int value)
        {
            Row = row;
            Colomn = colomn;
            Value = value;
        }

        public static Node CreateNode(int row, int colomn, int value)
        {
            if(IsInvalidSodukuIndex(row))
                throw new InvalidSodukuValue("Invalid Row index");
            if(IsInvalidSodukuIndex(colomn))
                throw new InvalidSodukuValue("Invalid Colomn index");
            if(IsInvalidSodukuValue(value))
                throw new InvalidSodukuValue("Invalid Value");
            return new Node(row, colomn, value);
        }

        private static bool IsInvalidSodukuIndex(int index)
        {
            return (index < 0 || index > 8);
        }

        private static bool IsInvalidSodukuValue(int value)
        {
            return (value < 1 || value > 9);
        }

        public Position ToPosition()
        {
            return Position.GetPosition(Row, Colomn);
        }

        public int Row { get; }

        public int Colomn { get; }

        public int Value { get;}
    }
}
