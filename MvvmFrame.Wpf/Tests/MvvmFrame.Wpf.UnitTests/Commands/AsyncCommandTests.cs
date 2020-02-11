using GetcuReone.MvvmFrame.Wpf.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.UnitTests.Common;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.Commands
{
    [TestClass]
    public class AsyncCommandTests : UiTestBase<CommandViewModel>
    {
        [Timeout(Timeuots.Second.Ten)]
        [Description("[ui][async][command] run command")]
        [TestMethod]
        public void AsyncCommand_RunCommandTestCase()
        {
            bool commandComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommand = new AsyncCommand(async _ =>
                    {
                        await Task.Delay(Timeuots.Millisecond.Hundred);
                        commandComlited = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page => 
                {
                    page.btnAsyncCommand.OnClick();
                    await Task.Delay(Timeuots.Millisecond.Hundred);
                })
                .Then("Check run command", () => Assert.IsTrue(commandComlited, "Command not runed"))
                .RunWindow(Timeuots.Second.Ten);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][async][command] run command")]
        [TestMethod]
        public void AsyncCommand_RunFinishOperationTestCase()
        {
            bool finishComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommand = new AsyncCommand(async e =>
                    {
                        await Task.Delay(Timeuots.Millisecond.Hundred);
                        e.AddFinalOperation(() => finishComlited = true);
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommand.OnClick();
                    await Task.Delay(Timeuots.Millisecond.Hundred);
                })
                .Then("Check run command", () => Assert.IsTrue(finishComlited, "Finis operation not runed"))
                .RunWindow(Timeuots.Second.Five);
        }

        [Timeout(Timeuots.Second.Twenty)]
        [Description("[ui][async][command] run command")]
        [TestMethod]
        public void AsyncCommand_RunCompensationOperationTestCase()
        {
            bool compensationComlited = false;
            bool finishCommand = false;
            bool finishOperationCoplited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommand = new AsyncCommand(async e =>
                    {
                        await Task.Delay(Timeuots.Millisecond.Hundred);
                        e.AddFinalOperation(() => finishOperationCoplited = true);
                        e.AddCompensation(() => 
                        {
                            compensationComlited = true;
                            return default;
                        });
                        e.Cancel();

                        if (e.IsCancel)
                            return;

                        finishCommand = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommand.OnClick();
                    await Task.Delay(Timeuots.Millisecond.Hundred);
                })
                .Then("Check run command", () => 
                {
                    Assert.IsTrue(compensationComlited, $"compensation operation not runed. Value: {compensationComlited}");
                    Assert.IsFalse(finishCommand, "finishCommand is false");
                    Assert.IsTrue(finishOperationCoplited, "Finis operation not runed");
                })
                .RunWindow(Timeuots.Second.Twenty);
        }

        //[Timeout(Timeuots.Second.Ten)]
        [Description("[ui][async][command] run command")]
        [TestMethod]
        public void AsyncCommand_P_RunCommandTestCase()
        {
            bool commandComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommandWithParam = new AsyncCommand<CommandViewModel>(async e =>
                    {
                        await Task.Delay(Timeuots.Millisecond.Hundred);
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        commandComlited = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommandParam.OnClick();
                    await Task.Delay(Timeuots.Millisecond.Hundred);
                })
                .Then("Check run command", () => Assert.IsTrue(commandComlited, "Command not runed"))
                .RunWindow(Timeuots.Second.Ten);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][async][command] run command")]
        [TestMethod]
        public void AsyncCommand_P_RunFinishOperationTestCase()
        {
            bool finishComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommandWithParam = new AsyncCommand<CommandViewModel>(async e =>
                    {
                        await Task.Delay(Timeuots.Millisecond.Hundred);
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        e.AddFinalOperation(() => finishComlited = true);
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommandParam.OnClick();
                    await Task.Delay(Timeuots.Second.One);
                })
                .Then("Check run command", () => Assert.IsTrue(finishComlited, "Finis operation not runed"))
                .RunWindow(Timeuots.Second.Five);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][async][command] run command")]
        [TestMethod]
        public void AsyncCommand_P_RunCompensationOperationTestCase()
        {
            bool compensationComlited = false;
            bool finishCommand = false;
            bool finishOperationCoplited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommandWithParam = new AsyncCommand<CommandViewModel>(async e =>
                    {
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        e.AddFinalOperation(() => finishOperationCoplited = true);
                        e.AddCompensation(() => 
                        {
                            compensationComlited = true;
                            return default;
                        });
                        e.Cancel();

                        if (e.IsCancel)
                            return;

                        finishCommand = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommandParam.OnClick();
                    await Task.Delay(Timeuots.Millisecond.Hundred);
                })
                .Then("Check run command", () =>
                {
                    Assert.IsTrue(compensationComlited, "compensation operation not runed");
                    Assert.IsFalse(finishCommand, "finishCommand is false");
                    Assert.IsTrue(finishOperationCoplited, "Finis operation not runed");
                })
                .RunWindow(Timeuots.Second.Five);
        }
    }
}
