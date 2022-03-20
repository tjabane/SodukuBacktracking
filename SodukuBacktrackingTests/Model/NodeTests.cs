using NUnit.Framework;
using SodukuBacktracking.Exceptions;
using SodukuBacktracking.Model;
using Shouldly;

namespace SodukuBacktrackingTests.Model
{
    public class NodeTests
    {
        [Test]
        public void ShouldThrowErrorWhenRowOutOfRange()
        {
            int row = 10;
            int colomn = 5;
            int value = 6;

            var exception = Assert.Throws<InvalidSodukuValue>(() => Node.CreateNode(row, colomn, value));
            exception.Message.ShouldBe("Invalid Row index");
        }

        [Test]
        public void ShouldThrowErrorWhenColomnOutOfRange()
        {
            int row = 5;
            int colomn = 50;
            int value = 6;

            var exception = Assert.Throws<InvalidSodukuValue>(() => Node.CreateNode(row, colomn, value));
            exception.Message.ShouldBe("Invalid Colomn index");
        }

        [Test]
        public void ShouldThrowErrorWhenValueOutOfRange()
        {
            int row = 5;
            int colomn = 5;
            int value = 600;

            var exception = Assert.Throws<InvalidSodukuValue>(() => Node.CreateNode(row, colomn, value));
            exception.Message.ShouldBe("Invalid Value");
        }


        [Test]
        public void ShouldCreateNodeWhenValuesInRange()
        {
            int row = 5;
            int colomn = 5;
            int value = 6;

            var node = Node.CreateNode(row, colomn, value);

            node.Row.ShouldBe(row);
            node.Colomn.ShouldBe(colomn);
            node.Value.ShouldBe(value);
        }

    }
}
