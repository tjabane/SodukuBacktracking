using NUnit.Framework;
using Shouldly;
using SodukuBacktracking.Exceptions;
using SodukuBacktracking.Model;

namespace SodukuBacktrackingTests.Model
{
    public class PositionTests
    {
        [Test]
        public void ShouldThrowErrorWhenRowOutOfRange()
        {
            int invalidRow = 10;
            int colomn = 5;

            var exception = Assert.Throws<InvalidSodukuValue>(() => Position.GetPosition(invalidRow, colomn));
            exception.Message.ShouldBe("Invalid Row index");
        }

        [Test]
        public void ShouldThrowErrorWhenColomnOutOfRange()
        {
            int row = 5;
            int invaliColomn = 50;

            var exception = Assert.Throws<InvalidSodukuValue>(() => Position.GetPosition(row, invaliColomn));
            exception.Message.ShouldBe("Invalid Colomn index");
        }

        [Test]
        public void ShouldReturnPositionWhenValuesInRange()
        {
            int row = 5;
            int colomn = 5;

            var position = Position.GetPosition(row, colomn);

            position.Row.ShouldBe(row);
            position.Colomn.ShouldBe(colomn);
        }
    }
}
