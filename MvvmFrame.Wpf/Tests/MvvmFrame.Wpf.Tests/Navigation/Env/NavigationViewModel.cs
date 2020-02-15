using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.Tests.Navigation.Env
{
    public sealed class NavigationViewModel : ViewModelBase
    {
        public List<string> MethodCallLog { get; } = new List<string>();
        public List<string> NavigationModes { get; } = new List<string>();

        public bool IsLeaved { get; private set; } = false;
        public bool IsLoaded { get; private set; } = false;
        public bool IsNavigated { get; private set; } = false;

        public int InitializeCallCounter { get; private set; } = 0;

        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            IsNavigated = true;
            IsLeaved = false;
            MethodCallLog.Add(nameof(OnGoPageAsync));
            return default;
        }

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            IsLeaved = true;
            IsNavigated = false;
            IsLoaded = false;
            NavigationModes.Add(args.NavigationMode.ToString());
            MethodCallLog.Add(nameof(OnLeavePageAsync));
            return default;
        }

        protected override ValueTask OnLoadPageAsync()
        {
            IsLoaded = true;
            MethodCallLog.Add(nameof(OnLoadPageAsync));
            return default;
        }

        protected override void Initialize()
        {
            InitializeCallCounter++;
        }
    }
}
