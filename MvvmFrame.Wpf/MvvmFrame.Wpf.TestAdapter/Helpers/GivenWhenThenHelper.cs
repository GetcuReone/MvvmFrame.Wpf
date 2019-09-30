using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class GivenWhenThenHelper
    {
        private static async ValueTask RunCodeBlockAndCloseWindow(Stack<BlockBase> blocksStack, TestWindow window)
        {
            object param = window.mainFrame;

            while (blocksStack.Count > 0)
            {
                BlockBase currentBlock = blocksStack.Pop();

                string startMessage = $"[{DateTime.Now}][{currentBlock.NameBlock}] start '{currentBlock.Discription}'";
                Console.WriteLine(startMessage);
                Debug.WriteLine(startMessage);

                param = currentBlock.IsAsync
                    ? await currentBlock.ExecuteAsync(param)
                    : currentBlock.Execute(param);

                string endMessage = $"[{DateTime.Now}][{currentBlock.NameBlock}] end '{currentBlock.Discription}'\n";
                Console.WriteLine(endMessage);
                Debug.WriteLine(endMessage);
            }

            window.Dispatcher.Invoke(window.Close);
        }

        /// <summary>
        /// run given-block-then
        /// </summary>
        /// <param name="then"></param>
        public static void Run(this BlockBase then)
        {
            Stack<BlockBase> blocksStack = new Stack<BlockBase>();
            BlockBase block = then;

            while (true)
            {
                blocksStack.Push(block);

                if (block.PreviousBlock == null)
                    break;
                else
                    block = block.PreviousBlock;
            }

            TestWindow window = new TestWindow();

            window.Loaded += async (sender, e) => await RunCodeBlockAndCloseWindow(blocksStack, window);

            window.ShowDialog();
        }
    }
}
