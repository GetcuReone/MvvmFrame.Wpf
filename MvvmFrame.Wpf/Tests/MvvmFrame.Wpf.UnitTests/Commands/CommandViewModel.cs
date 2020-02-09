using System.Threading.Tasks;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Commands;
using GetcuReone.MvvmFrame.Wpf.EventArgs;

namespace MvvmFrame.Wpf.UnitTests.Commands
{
    public sealed class CommandViewModel: ViewModelBase
    {
        public Command Command { get; set; }

        public Command<CommandViewModel> CommandWithParam { get; set; }

        public AsyncCommand AsyncCommand { get; set; }

        public AsyncCommand<CommandViewModel> AsyncCommandWithParam { get; set; }

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
