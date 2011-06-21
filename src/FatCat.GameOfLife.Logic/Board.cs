using System.Collections.Generic;
using System.Linq;
using FatCat.GameOfLife.Logic.Exceptions;

namespace FatCat.GameOfLife.Logic
{
    public class Board
    {
        private IList<Cell> _cells;

        public Board(int size)
        {
            Size = size;

            InitializeCells();
        }

        public int Size { get; private set; }

        private IEnumerable<Cell> Cells
        {
            get { return _cells; }
        }

        public CellState GetCellState(Coordinate coordinate)
        {
            return GetCell(coordinate).State;
        }

        public void MakeCellAlive(Coordinate coordinate)
        {
            SetCellState(coordinate, CellState.Alive);
        }

        public void MakeCellDead(Coordinate coordinate)
        {
            SetCellState(coordinate, CellState.Dead);
        }

        private void AddColumns(int row)
        {
            for (var column = 0; column < Size; column++)
            {
                _cells.Add(new Cell(Coordinate.Create(row, column)));
            }
        }

        private void AddRows()
        {
            for (var row = 0; row < Size; row++)
            {
                AddColumns(row);
            }
        }

        private Cell GetCell(Coordinate coordinate)
        {
            var cell = Cells
                .Where(i => i.Coordinate == coordinate)
                .FirstOrDefault();

            if (cell == null)
            {
                throw new CellNotFoundException();
            }

            return cell;
        }

        private void InitializeCells()
        {
            _cells = new List<Cell>();

            AddRows();
        }

        private void SetCellState(Coordinate coordinate, CellState cellState)
        {
            GetCell(coordinate).State = cellState;
        }
    }
}