using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Collections.Generic;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class GivenWhenThenHelper
    {
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

            window.Loaded += async (sender, e) =>
            {
                object param = window.mainFrame;

                while (blocksStack.Count > 0)
                {
                    BlockBase currentBlock = blocksStack.Pop();

                    Console.WriteLine($"[{DateTime.Now}][{currentBlock.NameBlock}] start '{currentBlock.Discription}'");

                    param = currentBlock.IsAsync
                        ? await currentBlock.ExecuteAsync(param)
                        : currentBlock.Execute(param);

                    Console.WriteLine($"[{DateTime.Now}][{currentBlock.NameBlock}] end '{currentBlock.Discription}'\n");
                }

                window.Close();
            };

            window.ShowDialog();
        }
    }
}
