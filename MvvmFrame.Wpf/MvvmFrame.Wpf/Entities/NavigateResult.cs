namespace MvvmFrame.Wpf.Entities
{
    /// <summary>
    /// Navigate result
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public sealed class NavigateResult<TViewModel>
        where TViewModel: ViewModelBase
    {
        internal NavigateResult(bool isNavigate, TViewModel viewModel)
        {
            IsNavigate = isNavigate;
            ViewModel = viewModel;
        }

        /// <summary>
        /// result navigate operation
        /// </summary>
        public bool IsNavigate { get; }
        /// <summary>
        /// View-model
        /// </summary>
        public TViewModel ViewModel { get; }
    }
}
