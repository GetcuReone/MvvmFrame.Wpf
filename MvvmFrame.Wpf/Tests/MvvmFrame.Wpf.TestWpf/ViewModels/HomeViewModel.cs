using MvvmFrame.Wpf.Commands;
using MvvmFrame.Wpf.EventArgs;
using MvvmFrame.Wpf.Models;
using MvvmFrame.Wpf.TestWpf.Pages;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestWpf.ViewModels
{
    public sealed class HomeViewModel: ViewModelBase
    {
        public ButtonModel GoBack_ButtonModel { get; private set; }

        public ButtonModel GoForward_ButtonModel { get; private set; }

        public ButtonModel Navigate_ButtonModel { get; private set; }

        public ButtonModel Refresh_ButtonModel { get; private set; }

        public ButtonModel Delay_ButtonModel { get; private set; }

        public string AsyncText { get => _asyncText; set => SetPropertyValue(ref _asyncText, value); }
        private string _asyncText;

        protected override void Initialize()
        {
            GoBack_ButtonModel = GetModel<ButtonModel>();
            GoBack_ButtonModel.Command = new Command(GoBack);

            GoForward_ButtonModel = GetModel<ButtonModel>();
            GoForward_ButtonModel.Command = new Command(GoForward);

            Navigate_ButtonModel = GetModel<ButtonModel>();
            Navigate_ButtonModel.Command = new AsyncCommand(Navigate);

            Refresh_ButtonModel = GetModel<ButtonModel>();
            Refresh_ButtonModel.Command = new Command(Refresh);

            Delay_ButtonModel = GetModel<ButtonModel>();
            Delay_ButtonModel.Command = new AsyncCommand(DelayAsync);
        }

        private void GoBack(CommandArgs e) => NavigationManager.GoBack();

        private void GoForward(CommandArgs e) => NavigationManager.GoForward();

        private void Refresh(CommandArgs e) => NavigationManager.Refresh();

        private async ValueTask Navigate(AsyncCommandArgs e)
        {
            var result = Navigate<MainPage, MainViewModel>("Hi, main");
            await NavigationManager.WaitLeaveViewModelAsync(result.ViewModel, new TimeSpan(0, 5, 0));
        }

        private async ValueTask DelayAsync(AsyncCommandArgs e)
        {
            Delay_ButtonModel.IsEnabled = false;
            e.AddFinalOperation(() => Delay_ButtonModel.IsEnabled = true);
            AsyncText = "";
            for (int i = 0; i < 3; i++)
            {
                AsyncText += i + 1;
                await Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(2000);
                    AsyncText += "[async]";
                });
                AsyncText += "[sync]"; 
            }
        }

        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            return default;
        }

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            return default;
        }

        protected override ValueTask OnLoadPageAsync()
        {
            return default;
        }
    }
}
