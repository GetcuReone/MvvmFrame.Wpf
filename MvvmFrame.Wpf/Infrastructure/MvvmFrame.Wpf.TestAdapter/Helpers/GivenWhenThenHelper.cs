using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    internal static class GivenWhenThenHelper
    {
        internal static async ValueTask RunCodeBlockAndCloseWindow<TWindow>(Stack<BlockBase> blocksStack, TWindow window, Func<TWindow, Frame> getFrame)
            where TWindow : Window, new()
        {
            object param = getFrame(window);

            while (blocksStack.Count > 0)
            {
                BlockBase currentBlock = blocksStack.Pop();

                LoggingHelper.Info($"[{currentBlock.NameBlock}] start '{currentBlock.Discription}'");

                param = currentBlock.IsAsync
                    ? await currentBlock.ExecuteAsync(param)
                    : currentBlock.Execute(param);

                LoggingHelper.Info($"[{currentBlock.NameBlock}] end '{currentBlock.Discription}'\n");
            }

            window.Dispatcher.Invoke(window.Close);
        }

    }
}
