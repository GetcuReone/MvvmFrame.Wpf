using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.Commands;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.UnitTests.Common;

namespace MvvmFrame.Wpf.UnitTests.Commands
{
    [TestClass]
    public class CommandTests: UiTestBase<CommandViewModel>
    {
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][command] run command")]
        [TestMethod]
        public void Command_RunCommandTestCase()
        {
            bool commandComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.Command = new Command(_ =>
                    {
                        commandComlited = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .When("Click button", page => page.btnCommand.OnClick())
                .Then("Check run command", () => Assert.IsTrue(commandComlited, "Command not runed"))
                .RunWindow();
        }
    }
}
