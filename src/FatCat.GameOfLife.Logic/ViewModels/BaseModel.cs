using System.Diagnostics;
using GalaSoft.MvvmLight;

namespace FatCat.GameOfLife.Logic.ViewModels
{
    public class BaseModel : ViewModelBase
    {
        private void PropertyHasChanged()
        {
            var frame = new StackFrame(2);

            var propertyName = frame.GetMethod().Name.Substring(4);

            RaisePropertyChanged(propertyName);
        }

        public virtual void SetPropteryValue<T>(ref T currentValue, T newValue) where T : class
        {
            if (currentValue == newValue)
            {
                return;
            }

            currentValue = newValue;

            PropertyHasChanged();
        }
    }
}