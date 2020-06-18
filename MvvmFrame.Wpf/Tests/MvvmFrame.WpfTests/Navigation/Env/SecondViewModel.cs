using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.Tests.Navigation.Env
{
    public sealed class SecondViewModel : ViewModelBase
    {

        protected override void Initialize()
        {

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
