using MvvmFrame.Wpf.TestAdapter.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'Then'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class ThenBlock<TInput, TOutput> : BlockBase<TInput, TOutput>
    {
        /// <summary>
        /// Block name
        /// </summary>
        public override string NameBlock => "Then";

        internal ThenBlock() { }

        #region And Then

        /// <summary>
        /// And this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<object, object> And(string discription, Action thisBlock)
        {
            return new ThenBlock<object, object>
            {
                CodeBlock = _ =>
                {
                    thisBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<TOutput, object> And(string discription, Action<TOutput> thisBlock)
        {
            return new ThenBlock<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thisBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<object, TOutput2> And<TOutput2>(string discription, Func<TOutput2> thisBlock)
        {
            return new ThenBlock<object, TOutput2>
            {
                CodeBlock = _ => thisBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And this
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<TOutput, TOutput2> And<TOutput2>(string discription, Func<TOutput, TOutput2> thisBlock)
        {
            return new ThenBlock<TOutput, TOutput2>
            {
                CodeBlock = thisBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And ThenAsync

        /// <summary>
        /// this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<object, object> AndAsync(string discription, Func<ValueTask> thisBlock)
        {
            return new ThenAsyncBlock<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thisBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<TOutput, object> AndAsync(string discription, Func<TOutput, ValueTask> thisBlock)
        {
            return new ThenAsyncBlock<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thisBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<object, TOutput2> AndAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> thisBlock)
        {
            return new ThenAsyncBlock<object, TOutput2>
            {
                CodeBlock = _ => thisBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<TOutput, TOutput2> AndAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> thisBlock)
        {
            return new ThenAsyncBlock<TOutput, TOutput2>
            {
                CodeBlock = thisBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        /// <summary>
        /// run given-block-then
        /// </summary>
        /// <param name="getFrame"></param>
        public virtual void Run<TWindow>(Func<TWindow, Frame> getFrame)
            where TWindow : Window, new()
        {
            Stack<BlockBase> blocksStack = new Stack<BlockBase>();
            BlockBase block = this;

            while (true)
            {
                blocksStack.Push(block);

                if (block.PreviousBlock == null)
                    break;
                else
                    block = block.PreviousBlock;
            }

            TWindow window = new TWindow();

            window.Loaded += async (sender, e) => await GivenWhenThenHelper.RunCodeBlockAndCloseWindow(blocksStack, window, getFrame);

            window.ShowDialog();
        }
    }
}
