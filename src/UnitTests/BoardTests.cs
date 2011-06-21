using FatCat.GameOfLife.Logic;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void ABoadWillBeCreatedWithASize()
        {
            var board = new Board(8);

            Assert.That(board.Size, Is.EqualTo(8));
        }

        [Test]
        public void ACellStateCanAccessedByCorrdinates()
        {
            var board = new Board(8);

            Assert.That(board.GetCellState(Coordinate.Create(1, 3)), Is.EqualTo(CellState.Dead));
        }
    }
}