using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmFrame.Wpf.EventArgs;
using MvvmFrame.Wpf.Models;

namespace MvvmFrame.Wpf.UnitTests.Navigation
{
    public sealed class NavigationViewModel:ViewModelBase
    {
        public List<string> MethodCallLog { get; } = new List<string>();

        public bool IsLeaved { get; private set; } = false;
        public bool IsLoaded { get; private set; } = false;
        public bool IsNavigated { get; private set; } = false;

        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            IsNavigated = true;
            IsLeaved = false;
            MethodCallLog.Add(nameof(OnGoPageAsync));
            return base.OnGoPageAsync(navigateParam);
        }

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            IsLeaved = true;
            IsNavigated = false;
            IsLoaded = false;
            MethodCallLog.Add(nameof(OnLeavePageAsync));
            return base.OnLeavePageAsync(args);
        }

        protected override ValueTask OnLoadPageAsync()
        {
            IsLoaded = true;
            MethodCallLog.Add(nameof(OnLoadPageAsync));
            return base.OnLoadPageAsync();
        }
    }
}
