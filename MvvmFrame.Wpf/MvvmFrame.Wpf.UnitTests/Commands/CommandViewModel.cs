using MvvmFrame.Wpf.Commands;

namespace MvvmFrame.Wpf.UnitTests.Commands
{
    public sealed class CommandViewModel: ViewModelBase
    {
        public Command Command { get; set; }

        public Command<CommandViewModel> CommandWithParam { get; set; }

        public AsyncCommand AsyncCommand { get; set; }

        public AsyncCommand<CommandViewModel> AsyncCommandWithParam { get; set; }
    }
}
