using MvvmFrame.Interfaces;

namespace MvvmFrame.Wpf.EventArgs
{
    /// <summary>
    /// Provides data for the Navigating event.
    /// </summary>
    public sealed class NavigatingEventArgs: ICancellation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigatedViewModel"></param>
        /// <param name="navigateParam"></param>
        public NavigatingEventArgs(ViewModelBase navigatedViewModel, object navigateParam)
        {
            IsCancel = false;
            NavigatedViewModel = navigatedViewModel;
            NavigateParam = navigateParam;
        }
        /// <summary>
        /// is navigation canceled
        /// </summary>
        public bool IsCancel { get; private set; }
        /// <summary>
        /// Navigated view-model
        /// </summary>
        public ViewModelBase NavigatedViewModel { get; }
        /// <summary>
        /// Nagation parameter
        /// </summary>
        public object NavigateParam { get; }

        /// <summary>
        /// Cancel navigation
        /// </summary>
        public void Cancel() => IsCancel = true;
    }
}
