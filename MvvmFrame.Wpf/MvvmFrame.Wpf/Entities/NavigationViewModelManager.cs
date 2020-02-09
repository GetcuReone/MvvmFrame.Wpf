using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MvvmFrame.Wpf.Entities
{
    /// <summary>
    /// Navigation view-model manager
    /// </summary>
    public sealed class NavigationViewModelManager : IDisposable, INotifyPropertyChanged
    {
        private readonly List<ViewModelBase> _linkViewModels = new List<ViewModelBase>();
        private readonly NavigationViewModelCompensation _navigationCompensation = new NavigationViewModelCompensation();

        private NavigationService _navigationService;

        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Can GoBack
        /// </summary>
        public bool CanGoBack => _navigationService.CanGoBack;
        /// <summary>
        /// Can GoForward
        /// </summary>
        public bool CanGoForward => _navigationService.CanGoForward;

        internal NavigationViewModelManager(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigating += OnNavigating;
            _navigationService.Navigated += OnNavigated;
            _navigationService.NavigationFailed += OnNavigationFailed;
            _navigationService.NavigationStopped += OnNavigationStopped;
        }

        private void OnGoPropertyChanged()
        {
            OnPropertyChanged(nameof(CanGoBack));
            OnPropertyChanged(nameof(CanGoForward));
        }
        private async void OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Refresh)
                return;

            ViewModelBase previous = (_navigationService.Content as Page)?.DataContext as ViewModelBase;
            if (previous == null)
                return;

            ViewModelBase viewModel = (e.Content as Page)?.DataContext as ViewModelBase;
            if (viewModel == null)
                return;

            var args = new NavigatingEventArgs(viewModel, e.ExtraData);
            await previous.InnerOnLeavePageAsync(args);

            if (args.IsCancel)
            {
                e.Cancel = true;
                _navigationCompensation.Compensate();
            }
        }
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e) => _navigationCompensation.Compensate();
        private void OnNavigationStopped(object sender, NavigationEventArgs e) => _navigationCompensation.Compensate();
        private async void OnNavigated(object sender, NavigationEventArgs e)
        {
            ViewModelBase current = (_navigationService.Content as Page)?.DataContext as ViewModelBase;
            if (current == null)
                return;

            await current.InnerOnGoPageAsync(e.ExtraData);
            OnGoPropertyChanged();
        }

        internal void LinkAdd(ViewModelBase viewModel)
        {
            if (_linkViewModels.IndexOf(viewModel) == -1)
                _linkViewModels.Add(viewModel);
        }

        internal void LinkRemove(ViewModelBase viewModel)
        {
            if (_linkViewModels.IndexOf(viewModel) != -1)
                _linkViewModels.Remove(viewModel);
        }

        /// <summary>
        /// Run navigate
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="navigateParam">navigation parametrs</param>
        /// <returns></returns>
        internal NavigateResult<TViewModel> Navigate<TPage, TViewModel>(TViewModel viewModel, object navigateParam)
            where TPage : Page, IPage, new()
            where TViewModel : ViewModelBase
        {
            viewModel.InnerInitialaze();
            TPage page = new TPage();
            page.InitializePageComponent(viewModel);
            page.Loaded += viewModel.OnLoadPage;

            _navigationCompensation.AddCompensation(() => page.Loaded -= viewModel.OnLoadPage);

            var result = new NavigateResult<TViewModel>(
                _navigationService.Navigate(page, navigateParam),
                viewModel);

            if (!result.IsNavigate)
                _navigationCompensation.Compensate();

            return result;
        }

        /// <summary>
        /// Navigation back
        /// </summary>
        public void GoBack() => _navigationService.GoBack();
        /// <summary>
        /// Navigation forward
        /// </summary>
        public void GoForward() => _navigationService.GoForward();
        /// <summary>
        /// Reload page
        /// </summary>
        public void Refresh() => _navigationService.Refresh();

        /// <summary>
        /// 10 minutes wait for navigation view-model
        /// </summary>
        /// <typeparam name="TViewModel">Type view-model</typeparam>
        /// <param name="viewModel">await view-model</param>
        /// <returns></returns>
        public ValueTask<bool> WaitNavigationAsync<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
            => WaitNavigationAsync(viewModel, new TimeSpan(0, 10, 0));

        /// <summary>
        /// wait for navigation
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="timeSpan">waiting time</param>
        /// <returns></returns>
        public async ValueTask<bool> WaitNavigationAsync<TViewModel>(TViewModel viewModel, TimeSpan timeSpan) where TViewModel: ViewModelBase
        {
            bool isNavigated = false;
            DateTime oparationDate = DateTime.Now;
            NavigatedEventHandler hendleNavigated = (sender, e) =>
            {
                if (_navigationService.Content is Page page)
                    if (page != null && page.DataContext is TViewModel viewModelCompare)
                        isNavigated = viewModelCompare == viewModel;
            };

            _navigationService.Navigated += hendleNavigated;

            while (DateTime.Now - oparationDate < timeSpan)
            {
                if (isNavigated)
                    break;
                await Task.Delay(100);
            }

            _navigationService.Navigated -= hendleNavigated;

            return isNavigated;
        }

        /// <summary>
        /// 10 minutes waiting for leaving of the view-model
        /// </summary>
        /// <typeparam name="TViewModel">Type view-model</typeparam>
        /// <param name="viewModel">await view-model</param>
        /// <returns></returns>
        public ValueTask<bool> WaitLeaveViewModelAsync<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
            => WaitLeaveViewModelAsync(viewModel, new TimeSpan(0, 10, 0));

        /// <summary>
        /// Wait for leaving view-model. Will return the false if the model does not wait for the allotted time <paramref name="timeSpan"/>
        /// </summary>
        /// <typeparam name="TViewModel">Type view-model</typeparam>
        /// <param name="viewModel">await view-model</param>
        /// <param name="timeSpan">waiting period</param>
        /// <returns></returns>
        public async ValueTask<bool> WaitLeaveViewModelAsync<TViewModel>(TViewModel viewModel, TimeSpan timeSpan)
            where TViewModel: ViewModelBase
        {
            bool isLeave = false;
            DateTime oparationDate = DateTime.Now;
            NavigatingCancelEventHandler hendleLeave = (sender, e) =>
            {
                if (e.NavigationMode == NavigationMode.Refresh)
                    return;

                if (_navigationService.Content is Page page)
                    if (page != null && page.DataContext is TViewModel viewModelCompare)
                        isLeave = viewModelCompare == viewModel;
            };

            _navigationService.Navigating += hendleLeave;

            while(DateTime.Now - oparationDate < timeSpan)
            {
                if (isLeave)
                    break;
                await Task.Delay(100);
            }

            _navigationService.Navigating -= hendleLeave;

            return isLeave;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_linkViewModels.Count == 0)
            {
                _navigationService.Navigated -= OnNavigated;
                _navigationService.Navigating -= OnNavigating;
                _navigationService.NavigationFailed -= OnNavigationFailed;
                _navigationService.NavigationStopped -= OnNavigationStopped;
            }
        }

        /// <summary>
        /// Handler changed proprty
        /// </summary>
        /// <param name="propertyName">property name</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
