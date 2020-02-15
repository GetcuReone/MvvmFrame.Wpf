using GetcuReone.MvvmFrame.Wpf.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestsCommon;

namespace MvvmFrame.Wpf.UnitTests.Commands
{
    [TestClass]
    public class FirstCanAsyncCommandTests
    {
        [Timeout(Timeuots.Millisecond.Twenty)]
        [TestMethod]
        [Description("[command] check 'can' for FirstCanAsyncCommand")]
        public void FirstCanAsyncCommand_CheckCanTestCase()
        {
            AsyncCommand asyncCommand = new FirstCanAsyncCommand(
                _ => default,
                () => false);

            Assert.IsTrue(asyncCommand.CanExecute(null), "first can must be true");
            Assert.IsFalse(asyncCommand.CanExecute(null), "second can must be false");
        }

        [Timeout(Timeuots.Millisecond.Twenty)]
        [TestMethod]
        [Description("[command] check 'can' for FirstCanCommand with param")]
        public void FirstCanAsyncCommand_P_CheckCanTestCase()
        {
            object obj = new object();
            int counterCalls = 0;

            AsyncCommand<object> asyncCommand = new FirstCanAsyncCommand<object>(
                _ => default,
                param => 
                {
                    counterCalls++;
                    Assert.AreEqual(obj, param, "parame must be equal obj");
                    return false;
                });

            Assert.IsTrue(asyncCommand.CanExecute(obj), "first can must be true");
            Assert.IsFalse(asyncCommand.CanExecute(obj), "second can must be false");
            Assert.AreEqual(1, counterCalls, "There had to be one method call");
        }
    }
}
