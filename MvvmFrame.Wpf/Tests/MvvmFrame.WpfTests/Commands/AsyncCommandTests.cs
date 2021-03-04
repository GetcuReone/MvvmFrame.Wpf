using GetcuReone.MvvmFrame.Wpf.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestsCommon;
using System;
using System.Threading.Tasks;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using GetcuReone.GetcuTestAdapter;

namespace MvvmFrame.Wpf.Tests.Commands
{
    [TestClass]
    public class AsyncCommandTests : UiTestBase<CommandViewModel>
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Command), TestCategory(TC.Async), TestCategory(TC.UI)]
        [Description("Run async command.")]
        [Timeout(Timeouts.Second.Ten)]
        public void AsyncCommand_RunCommandTestCase()
        {
            object commandComlited = null;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    commandComlited = false;
                    viewModel.AsyncCommand = new AsyncCommand(async _ =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        commandComlited = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommand.OnClick();
                    await Task.Delay(Timeouts.Millisecond.Hundred);
                })
                .Then("Check run command", () => Assert.IsTrue(Convert.ToBoolean(commandComlited), "Command not runed"))
                .RunWindow(Timeouts.Second.Ten);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Command), TestCategory(TC.Async), TestCategory(TC.UI)]
        [Description("Run async command with finish operation.")]
        [Timeout(Timeouts.Second.Five)]
        public void AsyncCommand_RunFinishOperationTestCase()
        {
            object finishComlited = null;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommand = new AsyncCommand(async e =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        e.AddFinalOperation(() => finishComlited = new object());
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommand.OnClick();
                    await Task.Delay(Timeouts.Second.One);
                })
                .Then("Check run command", () => Assert.IsNotNull(finishComlited, "Finis operation not runed"))
                .RunWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Command), TestCategory(TC.Async), TestCategory(TC.UI)]
        [Description("Run async command with compansate.")]
        [Timeout(Timeouts.Second.Twenty)]
        public void AsyncCommand_RunCompensationOperationTestCase()
        {
            object compensationComlited = false;
            object finishCommand = false;
            object finishOperationCoplited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommand = new AsyncCommand(async e =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
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
                    await Task.Delay(Timeouts.Millisecond.Hundred);
                })
                .Then("Check run command", () =>
                {
                    Assert.IsTrue(Convert.ToBoolean(compensationComlited), $"compensation operation not runed. Value: {compensationComlited}");
                    Assert.IsFalse(Convert.ToBoolean(finishCommand), "finishCommand is false");
                    Assert.IsTrue(Convert.ToBoolean(finishOperationCoplited), "Finis operation not runed");
                })
                .RunWindow(Timeouts.Second.Twenty);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Command), TestCategory(TC.Async), TestCategory(TC.UI)]
        [Description("Run async command with param.")]
        [Timeout(Timeouts.Second.Ten)]
        public void AsyncCommand_P_RunCommandTestCase()
        {
            object commandComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommandWithParam = new AsyncCommand<CommandViewModel>(async e =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        commandComlited = true;
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommandParam.OnClick();
                    await Task.Delay(Timeouts.Millisecond.Hundred);
                })
                .Then("Check run command", () => Assert.IsTrue(Convert.ToBoolean(commandComlited), "Command not runed"))
                .RunWindow(Timeouts.Second.Ten);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Command), TestCategory(TC.Async), TestCategory(TC.UI)]
        [Description("Run async command with param and finsh operation.")]
        [Timeout(Timeouts.Second.Five)]
        public void AsyncCommand_P_RunFinishOperationTestCase()
        {
            object finishComlited = false;

            GivenInitViewModel()
                .And("Init command", viewModel =>
                {
                    viewModel.AsyncCommandWithParam = new AsyncCommand<CommandViewModel>(async e =>
                    {
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                        Assert.AreEqual(viewModel, e.CommandParam, "CommandParam must be view-model");
                        e.AddFinalOperation(() => finishComlited = true);
                    });
                    return viewModel;
                })
                .AndAsync("Navigate", viewModel => NavigateAndWaitLoadPageAsync<CommandPage, CommandViewModel>(viewModel))
                .WhenAsync("Click button", async page =>
                {
                    page.btnAsyncCommandParam.OnClick();
                    await Task.Delay(Timeouts.Second.One);
                })
                .Then("Check run command", () => Assert.IsTrue(Convert.ToBoolean(finishComlited), "Finis operation not runed"))
                .RunWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Command), TestCategory(TC.Async), TestCategory(TC.UI)]
        [Description("Run command with param and compensate.")]
        [Timeout(Timeouts.Second.Five)]
        public void AsyncCommand_P_RunCompensationOperationTestCase()
        {
            object compensationComlited = false;
            object finishCommand = false;
            object finishOperationCoplited = false;

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
                    await Task.Delay(Timeouts.Millisecond.Hundred);
                })
                .Then("Check run command", () =>
                {
                    Assert.IsTrue(Convert.ToBoolean(compensationComlited), "compensation operation not runed");
                    Assert.IsFalse(Convert.ToBoolean(finishCommand), "finishCommand is false");
                    Assert.IsTrue(Convert.ToBoolean(finishOperationCoplited), "Finis operation not runed");
                })
                .RunWindow(Timeouts.Second.Five);
        }
    }
}
