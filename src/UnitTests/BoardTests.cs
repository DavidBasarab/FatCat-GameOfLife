using FatCat.GameOfLife.Logic;
using FatCat.GameOfLife.Logic.Exceptions;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BoardTests
    {
        [SetUp]
        public void SetUp()
        {
            _board = new Board(8);
        }

        private Board _board;

        [Test]
        public void ABoadWillBeCreatedWithASize()
        {
            Assert.That(_board.Size, Is.EqualTo(8));
        }

        [Test]
        public void ACellCanBeMadeAlive()
        {
            _board.MakeCellAlive(Coordinate.Create(2, 3));

            Assert.That(_board.GetCellState(Coordinate.Create(2, 3)), Is.EqualTo(CellState.Alive));
        }

        [Test]
        public void ACellStateCanAccessedByCoordinates()
        {
            Assert.That(_board.GetCellState(Coordinate.Create(1, 3)), Is.EqualTo(CellState.Dead));
        }

        [Test]
        [ExpectedException(typeof (CellNotFoundException))]
        public void InGetCellStateIfACellIsNotFoundACellNotFoundErrorExceptionIsThrown()
        {
            _board.GetCellState(Coordinate.Create(10, 0));
        }

        [Test]
        [ExpectedException(typeof (CellNotFoundException))]
        public void InMakeCellAliveIfACellIsNotFoundACellNotFoundErrorExceptionIsThrown()
        {
            _board.MakeCellAlive(Coordinate.Create(10, 0));
        }
    }
}