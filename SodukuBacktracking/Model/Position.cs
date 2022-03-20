using SodukuBacktracking.Exceptions;

namespace SodukuBacktracking.Model
{
    public class Position
    {
        private Position(int row, int colomn)
        {
            Row = row;
            Colomn = colomn;
        }

        public static Position GetPosition(int row, int colomn)
        {
            if (IsInvalidSodukuIndex(row))
                throw new InvalidSodukuValue("Invalid Row index");
            if (IsInvalidSodukuIndex(colomn))
                throw new InvalidSodukuValue("Invalid Colomn index");
            return new Position(row, colomn);
        }

        private static bool IsInvalidSodukuIndex(int index)
        {
            return (index < 0 || index > 8);
        }

        public int Row { get; }

        public int Colomn { get; }
    }
}
