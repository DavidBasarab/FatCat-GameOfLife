using System.Windows.Media;

namespace FatCat.GameOfLife.Logic.ViewModels
{
    public class CellManagement : BaseModel
    {
        private readonly Cell _cell;
        private Brush _backgroundBrush;

        public CellManagement(Cell cell)
        {
            _cell = cell;

            _backgroundBrush = CellState == CellState.Alive ? BrushFactory.AliveBrush : BrushFactory.DeadBrush;
        }

        public CellState CellState
        {
            get { return _cell.State; }
        }

        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set { SetPropteryValue(ref _backgroundBrush, value); }
        }

        public void SwitchCellState()
        {
            _cell.SwitchState();

            DetermineBackgroundBrush();
        }

        private void DetermineBackgroundBrush()
        {
            BackgroundBrush = CellState == CellState.Alive ? BrushFactory.AliveBrush : BrushFactory.DeadBrush;
        }
    }
}