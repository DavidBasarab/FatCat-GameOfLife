using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FatCat.GameOfLife.Logic.ViewModels
{
    public class BoardManagement : BaseModel
    {
        private string _welcomeMessage;

        public BoardManagement()
        {
            _welcomeMessage = IsInDesignMode ? "This is in another library" : "Hook'em Horns";
            TestMessage = IsInDesignMode ? "Time to sleep" : "Change to Texas Fight";

            SimpleCommand = new RelayCommand(ChangeWelcomeMessage);
        }

        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set
            {
                if (_welcomeMessage == value)
                {
                    return;
                }

                _welcomeMessage = value;

                PropertyHasChanged();
            }
        }

        public string TestMessage { get; set; }

        public RelayCommand SimpleCommand { get; private set; }

        private void ChangeWelcomeMessage()
        {
            WelcomeMessage = "TEXAS FIGHT!!!!!!!!";
        }
    }
}