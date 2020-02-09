using GetcuReone.MvvmFrame.Wpf.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.UnitTests.Common;
using System.Collections.Generic;

namespace MvvmFrame.Wpf.UnitTests.Commands
{
    [TestClass]
    [Ignore]
    public class FirstCanCommandTests
    {
        [Timeout(Timeuots.Millisecond.Twenty)]
        [TestMethod]
        [Description("[command] check 'can' for FirstCanCommand")]
        public void FirstCanCommand_CheckCanTestCase()
        {
            List<object> list = new List<object>();

            FirstCanCommand firstCanCommand = new FirstCanCommand(
                e => list.Add(new object()),
                () => false);

            for (int i = 0; i < 2; i++)
                if (firstCanCommand.CanExecute(null))
                    firstCanCommand.Execute(null);

            Assert.AreEqual(1, list.Count, "collection must have 1 element");
        }

        [Timeout(Timeuots.Millisecond.Twenty)]
        [TestMethod]
        [Description("[command] check 'can' for FirstCanCommand with param")]
        public void FirstCanCommand_P_CheckCanTestCase()
        {
            List<object> list = new List<object>();
            object obj = new object();

            FirstCanCommand<object> firstCanCommand = new FirstCanCommand<object>(
                e => list.Add(e.CommandParam),
                _ => false);

            for (int i = 0; i < 2; i++)
                if (firstCanCommand.CanExecute(obj))
                    firstCanCommand.Execute(obj);

            Assert.AreEqual(1, list.Count, "collection must have 1 element");
            Assert.AreEqual(obj, list[0], "expected other value");
        }
    }
}
