using System.Diagnostics;
using GalaSoft.MvvmLight;

namespace FatCat.GameOfLife.Logic.ViewModels
{
    public class BaseModel : ViewModelBase
    {
        protected void PropertyHasChanged()
        {
            var frame = new StackFrame(1);

            var propertyName = frame.GetMethod().Name.Substring(4);

            RaisePropertyChanged(propertyName);
        }
    }
}