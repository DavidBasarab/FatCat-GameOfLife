using System;
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
                SetPropteryValue(ref _welcomeMessage, value);
            }
        }

        public string TestMessage { get; set; }

        public RelayCommand SimpleCommand { get; private set; }

        private bool _isSet;

        private void ChangeWelcomeMessage()
        {
            if (_isSet)
            {
                WelcomeMessage = "HOOK'EM HORNS!!!!!!!!!";

                _isSet = false;
            }
            else
            {
                WelcomeMessage = "TEXAS FIGHT!!!!!!!!";

                _isSet = true;
            }
        }
    }
}