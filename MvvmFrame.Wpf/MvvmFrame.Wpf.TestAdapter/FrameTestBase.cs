using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter
{
    /// <summary>
    /// base class for testing pages written on the MvvmFrame.Wpf
    /// </summary>
    [TestClass]
    public abstract class FrameTestBase
    {
        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected Given<Frame, TResult> Given<TResult>(string discription, Func<Frame, TResult> givenBlock)
        {
            return new Given<Frame, TResult>
            {
                Discription = discription,
                CodeBlock = givenBlock,
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected Given<Frame, object> Given(string discription, Action<Frame> givenBlock)
        {
            return new Given<Frame, object>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
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
        protected GivenAsync<Frame, TResult> GivenAsync<TResult>(string discription, Func<Frame, ValueTask<TResult>> givenBlock)
        {
            return new GivenAsync<Frame, TResult>
            {
                Discription = discription,
                CodeBlock = givenBlock,
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected GivenAsync<Frame, object> GivenAsync(string discription, Func<Frame, ValueTask> givenBlock)
        {
            return new GivenAsync<Frame, object>
            {
                Discription = discription,
                CodeBlock = async frame => 
                {
                    await givenBlock(frame);
                    return null;
                },
            };
        }
    }
}
