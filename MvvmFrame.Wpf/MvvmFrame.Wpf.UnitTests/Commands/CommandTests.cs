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

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][command] run command")]
        [TestMethod]
        public void Command_RunFinishOperationTestCase()
        {
            bool finishComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.Command = new Command(e =>
                    {
                        e.AddFinalOperation(() => finishComlited = true);
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .When("Click button", page => page.btnCommand.OnClick())
                .Then("Check run command", () => Assert.IsTrue(finishComlited, "Finis operation not runed"))
                .RunWindow();
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][command] run command")]
        [TestMethod]
        public void Command_RunCompensationOperationTestCase()
        {
            bool compensationComlited = false;
            bool finishCommand = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.Command = new Command(e =>
                    {
                        e.AddCompensation(() => compensationComlited = true);
                        e.Cancel();

                        if (e.IsCancel)
                            return;

                        finishCommand = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .When("Click button", page => page.btnCommand.OnClick())
                .Then("Check run command", () => 
                {
                    Assert.IsTrue(compensationComlited, "compensation operation not runed");
                    Assert.IsFalse(finishCommand, "finishCommand is false");
                })
                .RunWindow();
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][command] run command")]
        [TestMethod]
        public void Command_P_RunCommandTestCase()
        {
            bool commandComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.CommandWithParam = new Command<CommandViewModel>(e =>
                    {
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        commandComlited = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .When("Click button", page => page.btnCommandParam.OnClick())
                .Then("Check run command", () => Assert.IsTrue(commandComlited, "Command not runed"))
                .RunWindow();
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][command] run command")]
        [TestMethod]
        public void Command_P_RunFinishOperationTestCase()
        {
            bool finishComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.CommandWithParam = new Command<CommandViewModel>(e =>
                    {
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        e.AddFinalOperation(() => finishComlited = true);
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .When("Click button", page => page.btnCommandParam.OnClick())
                .Then("Check run command", () => Assert.IsTrue(finishComlited, "Finis operation not runed"))
                .RunWindow();
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][command] run command")]
        [TestMethod]
        public void Command_P_RunCompensationOperationTestCase()
        {
            bool compensationComlited = false;
            bool finishCommand = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.CommandWithParam = new Command<CommandViewModel>(e =>
                    {
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        e.AddCompensation(() => compensationComlited = true);
                        e.Cancel();

                        if (e.IsCancel)
                            return;

                        finishCommand = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .When("Click button", page => page.btnCommandParam.OnClick())
                .Then("Check run command", () =>
                {
                    Assert.IsTrue(compensationComlited, "compensation operation not runed");
                    Assert.IsFalse(finishCommand, "finishCommand is false");
                })
                .RunWindow();
        }
    }
}
