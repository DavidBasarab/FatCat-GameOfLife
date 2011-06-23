using System.Windows.Media;

namespace FatCat.GameOfLife.Logic.ViewModels
{
    public static class BrushFactory
    {
        public static Brush AliveBrush = new SolidColorBrush(Colors.Green);
        public static Brush DeadBrush = new SolidColorBrush(Colors.Transparent);
    }
}