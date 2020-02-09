using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MvvmFrame.Wpf.TestAdapter
{
    /// <summary>
    /// base class for testing pages written on the MvvmFrame.Wpf
    /// </summary>
    [TestClass]
    public abstract class FrameTestBase
    {
        private Frame _frame;

        /// <summary>
        /// Check the type of the current page and return
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        protected virtual TPage CheckTypeAndGetPage<TPage>() where TPage: Page
        {
            if (_frame?.NavigationService == null)
                Assert.Fail("frame or frame.NavigationService should not be (maybe you did not use the block given)");
            else if (!(_frame.NavigationService.Content is Page))
                Assert.Fail("frame.NavigationService.Content not contains Page");
            else if (_frame.NavigationService.Content is TPage page)
                return page;

            Assert.Fail("_frame.NavigationService.Content contains other page");
            return null;

        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenBlock<Frame, TResult> Given<TResult>(string discription, Func<Frame, TResult> givenBlock)
        {
            return new GivenBlock<Frame, TResult>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
                    _frame = frame;
                    return givenBlock(frame);
                },
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenBlock<Frame, object> Given(string discription, Action<Frame> givenBlock)
        {
            return new GivenBlock<Frame, object>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
                    _frame = frame;
                    givenBlock(frame);
                    return null;
                },
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenAsyncBlock<Frame, TResult> GivenAsync<TResult>(string discription, Func<Frame, ValueTask<TResult>> givenBlock)
        {
            return new GivenAsyncBlock<Frame, TResult>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
                    _frame = frame;
                    return givenBlock(frame);
                },
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenAsyncBlock<Frame, object> GivenAsync(string discription, Func<Frame, ValueTask> givenBlock)
        {
            return new GivenAsyncBlock<Frame, object>
            {
                Discription = discription,
                CodeBlock = async frame => 
                {
                    _frame = frame;
                    await givenBlock(frame);
                    return null;
                },
            };
        }

        /// <summary>
        /// Clean up
        /// </summary>
        /// <remarks>
        /// Thank you very much https://www.meziantou.net/unit-tests-with-a-wpf-window.htm
        /// </remarks>
        [TestCleanup]
        public virtual void CleanUp()
        {
            Dispatcher.CurrentDispatcher.InvokeShutdown();
        }
    }
}
