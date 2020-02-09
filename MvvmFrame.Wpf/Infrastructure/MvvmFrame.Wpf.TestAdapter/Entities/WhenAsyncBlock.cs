using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'When'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class WhenAsyncBlock<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        /// <summary>
        /// Block name
        /// </summary>
        public override string NameBlock => "WhenAsync";
        internal WhenAsyncBlock() { }

        #region Then

        /// <summary>
        /// then
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<object, object> Then(string discription, Action thenBlock)
        {
            return new ThenBlock<object, object>
            {
                CodeBlock = _ =>
                {
                    thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<TOutput, object> Then(string discription, Action<TOutput> thenBlock)
        {
            return new ThenBlock<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<object, TOutput2> Then<TOutput2>(string discription, Func<TOutput2> thenBlock)
        {
            return new ThenBlock<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenBlock<TOutput, TOutput2> Then<TOutput2>(string discription, Func<TOutput, TOutput2> thenBlock)
        {
            return new ThenBlock<TOutput, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region ThenAsync

        /// <summary>
        /// then
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<object, object> ThenAsync(string discription, Func<ValueTask> thenBlock)
        {
            return new ThenAsyncBlock<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<TOutput, object> ThenAsync(string discription, Func<TOutput, ValueTask> thenBlock)
        {
            return new ThenAsyncBlock<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<object, TOutput2> ThenAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsyncBlock<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public virtual ThenAsyncBlock<TOutput, TOutput2> ThenAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsyncBlock<TOutput, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion
    }
}
