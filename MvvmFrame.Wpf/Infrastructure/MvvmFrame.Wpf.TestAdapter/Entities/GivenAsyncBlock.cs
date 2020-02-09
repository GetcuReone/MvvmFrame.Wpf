using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Given code block
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class GivenAsyncBlock<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        internal GivenAsyncBlock() { }

        /// <summary>
        /// Block name
        /// </summary>
        public override string NameBlock => "GivenAsync";

        #region And Given

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenBlock<object, object> And(string discription, Action givenBlock)
        {
            return new GivenBlock<object, object>
            {
                CodeBlock = _ =>
                {
                    givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenBlock<TOutput, object> And(string discription, Action<TOutput> givenBlock)
        {
            return new GivenBlock<TOutput, object>
            {
                CodeBlock = output =>
                {
                    givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenBlock<object, TOutput2> And<TOutput2>(string discription, Func<TOutput2> givenBlock)
        {
            return new GivenBlock<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenBlock<TOutput, TOutput2> And<TOutput2>(string discription, Func<TOutput, TOutput2> givenBlock)
        {
            return new GivenBlock<TOutput, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And GivenAsync

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsyncBlock<object, object> AndAsync(string discription, Func<ValueTask> givenBlock)
        {
            return new GivenAsyncBlock<object, object>
            {
                CodeBlock = async _ =>
                {
                    await givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsyncBlock<TOutput, object> AndAsync(string discription, Func<TOutput, ValueTask> givenBlock)
        {
            return new GivenAsyncBlock<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsyncBlock<object, TOutput2> AndAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsyncBlock<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsyncBlock<TOutput, TOutput2> AndAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsyncBlock<TOutput, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And When

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenBlock<object, object> When(string discription, Action whenBlock)
        {
            return new WhenBlock<object, object>
            {
                CodeBlock = _ =>
                {
                    whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenBlock<TOutput, object> When(string discription, Action<TOutput> whenBlock)
        {
            return new WhenBlock<TOutput, object>
            {
                CodeBlock = output =>
                {
                    whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenBlock<object, TOutput2> When<TOutput2>(string discription, Func<TOutput2> whenBlock)
        {
            return new WhenBlock<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenBlock<TOutput, TOutput2> When<TOutput2>(string discription, Func<TOutput, TOutput2> whenBlock)
        {
            return new WhenBlock<TOutput, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And WhenAsync

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsyncBlock<object, object> WhenAsync(string discription, Func<ValueTask> whenBlock)
        {
            return new WhenAsyncBlock<object, object>
            {
                CodeBlock = async _ =>
                {
                    await whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsyncBlock<TOutput, object> WhenAsync(string discription, Func<TOutput, ValueTask> whenBlock)
        {
            return new WhenAsyncBlock<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsyncBlock<object, TOutput2> WhenAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsyncBlock<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsyncBlock<TOutput, TOutput2> WhenAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsyncBlock<TOutput, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion
    }
}
