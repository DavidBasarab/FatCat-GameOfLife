using System.Windows.Media;
using FatCat.GameOfLife.Logic;
using FatCat.GameOfLife.Logic.ViewModels;
using NUnit.Framework;
using Rhino.Mocks;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class CellManagementTests
    {
        private CellManagement _cellManagement;
        private Cell _cell;

        private MockRepository Mocks { get; set; }

        [SetUp]
        public void SetUp()
        {
            Mocks = new MockRepository();

            CreateCellManagement(CellState.Dead);
        }

        [TearDown]
        public void TearDown()
        {
            Mocks.ReplayAll();
            Mocks.VerifyAll();
        }

        private void CreateCellManagement(CellState cellState)
        {
            CreateCell(cellState);

            _cellManagement = new CellManagement(_cell);
        }

        private void CreateCell(CellState cellState)
        {
            _cell = new Cell(Coordinate.Create(0, 0))
                        {
                            State = cellState
                        };
        }

        [Test]
        public void SwitchCellStateWillCauseBrushToChange()
        {
            _cellManagement.SwitchCellState();

            Assert.That(_cellManagement.BackgroundBrush, Is.EqualTo(BrushFactory.AliveBrush));

            _cellManagement.SwitchCellState();

            Assert.That(_cellManagement.BackgroundBrush, Is.EqualTo(BrushFactory.DeadBrush));
        }

        [Test]
        public void WhenACellIsAliveItWillHaveADefinedColor()
        {
            CreateCellManagement(CellState.Alive);

            Assert.That(_cellManagement.BackgroundBrush, Is.EqualTo(BrushFactory.AliveBrush));
        }

        [Test]
        public void WhenACellIsDeadItWillHaveADefinedColor()
        {
            Assert.That(_cellManagement.BackgroundBrush, Is.EqualTo(BrushFactory.DeadBrush));
        }

        [Test]
        public void WillAcceptACellAndUseItsState()
        {
            _cell = new Cell(Coordinate.Create(0, 0))
                        {
                            State = CellState.Alive
                        };

            _cellManagement = new CellManagement(_cell);

            Assert.That(_cellManagement.CellState, Is.EqualTo(CellState.Alive));
        }

        [Test]
        public void WillSwitchTheCellState()
        {
            _cellManagement.SwitchCellState();

            Assert.That(_cellManagement.CellState, Is.EqualTo(CellState.Alive));
        }

        [Test]
        public void WillSwitchTheCellStateBackToOrginalAfter2Calls()
        {
            _cellManagement.SwitchCellState();

            Assert.That(_cellManagement.CellState, Is.EqualTo(CellState.Alive));

            _cellManagement.SwitchCellState();

            Assert.That(_cellManagement.CellState, Is.EqualTo(CellState.Dead));
        }

        [Test]
        public void WhenBackgroundBrushPropertyChangesWillUseSetDataValue()
        {
            _cellManagement = Mocks.PartialMock<CellManagement>(_cell);

            Brush junkObject = new SolidColorBrush(Colors.Tomato);

            _cellManagement.Expect(v => v.SetPropteryValue<Brush>(ref junkObject, junkObject)).IgnoreArguments();

            Mocks.ReplayAll();

            _cellManagement.SwitchCellState();
        }
    }
}