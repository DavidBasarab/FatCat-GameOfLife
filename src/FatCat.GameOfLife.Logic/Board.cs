using System.Collections.Generic;
using System.Linq;

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

        private void InitializeCells()
        {
            _cells = new List<Cell>();

            AddRows();
        }

        private void AddRows()
        {
            for (var row = 0; row < Size; row++)
            {
                AddColumns(row);
            }
        }

        private void AddColumns(int row)
        {
            for (var column = 0; column < Size; column++)
            {
                _cells.Add(new Cell(Coordinate.Create(row, column)));
            }
        }

        public CellState GetCellState(Coordinate coordinate)
        {
            return Cells
                .Where(i => i.Coordinate == coordinate)
                .FirstOrDefault()
                .State;
        }
    }
}