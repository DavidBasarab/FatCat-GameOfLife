using System;

namespace FatCat.GameOfLife.Logic
{
    public class Cell
    {
        public Cell(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public CellState State { get; set; }

        public Coordinate Coordinate { get; set; }

        public void SwitchState()
        {
            State = State == CellState.Alive ? CellState.Dead : CellState.Alive;
        }
    }
}