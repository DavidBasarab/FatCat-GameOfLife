using GalaSoft.MvvmLight;

namespace FatCat.GameOfLife.Logic.ViewModels
{
    public class BoardManagement : ViewModelBase
    {
        public string WelcomeMessage { get; set; }

        public BoardManagement()
        {
            WelcomeMessage = IsInDesignMode ? "This is in another library" : "Hook'em Horns";
        }
    }
}