using System.Diagnostics.CodeAnalysis;
using FatCat.GameOfLife.Logic.ViewModels;

namespace FatCat.GameOfLife.ViewModel
{
    /// <summary>
    ///     This class contains static references to all the view models in the
    ///     application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static MainViewModel _main;
        private static BoardManagement _boardManagement;
        private CellManagement _cellManagement;

        /// <summary>
        ///     Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time services and viewmodels
            ////}
            ////else
            ////{
            ////    // Create run time services and view models
            ////}

            _main = new MainViewModel();
        }

        /// <summary>
        ///     Gets the Main property which defines the main viewmodel.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get { return _main; }
        }

        public BoardManagement BoardManagement
        {
            get { return _boardManagement ?? (_boardManagement = new BoardManagement()); }
        }
    }
}