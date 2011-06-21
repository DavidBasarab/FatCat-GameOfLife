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
    }
}