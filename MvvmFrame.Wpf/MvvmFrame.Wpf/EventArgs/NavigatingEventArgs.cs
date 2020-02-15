using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Navigation;

namespace GetcuReone.MvvmFrame.Wpf.EventArgs
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
        /// <param name="navigationMode"></param>
        public NavigatingEventArgs(ViewModelBase navigatedViewModel, object navigateParam, NavigationMode navigationMode)
        {
            IsCancel = false;
            NavigatedViewModel = navigatedViewModel;
            NavigateParam = navigateParam;
            NavigationMode = navigationMode;
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
        /// Navigatiom mode
        /// </summary>
        public NavigationMode NavigationMode { get; }

        /// <summary>
        /// Cancel navigation
        /// </summary>
        public void Cancel() => IsCancel = true;
    }
}
