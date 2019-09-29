using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper for then block
    /// </summary>
    public static class ThenHelper
    {
        #region then

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, object> Then<TInput, TOutput>(this When<TInput, TOutput> when, string discription, Action thenBlock)
        {
            return new Then<object, object>
            {
                CodeBlock = _ =>
                {
                    thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput, object> Then<TInput, TOutput>(this When<TInput, TOutput> when, string discription, Action<TOutput> thenBlock)
        {
            return new Then<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, TOutput2> Then<TInput, TOutput1, TOutput2>(this When<TInput, TOutput1> when, string discription, Func<TOutput2> thenBlock)
        {
            return new Then<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// when
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput1, TOutput2> Then<TInput, TOutput1, TOutput2>(this When<TInput, TOutput1> when, string discription, Func<TOutput1, TOutput2> thenBlock)
        {
            return new Then<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, object> Then<TInput, TOutput>(this WhenAsync<TInput, TOutput> when, string discription, Action thenBlock)
        {
            return new Then<object, object>
            {
                CodeBlock = _ =>
                {
                    thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput, object> Then<TInput, TOutput>(this WhenAsync<TInput, TOutput> when, string discription, Action<TOutput> thenBlock)
        {
            return new Then<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, TOutput2> Then<TInput, TOutput1, TOutput2>(this WhenAsync<TInput, TOutput1> when, string discription, Func<TOutput2> thenBlock)
        {
            return new Then<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// when
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput1, TOutput2> Then<TInput, TOutput1, TOutput2>(this WhenAsync<TInput, TOutput1> when, string discription, Func<TOutput1, TOutput2> thenBlock)
        {
            return new Then<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, object> ThenAsync<TInput, TOutput>(this When<TInput, TOutput> when, string discription, Func<ValueTask> thenBlock)
        {
            return new ThenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput, object> ThenAsync<TInput, TOutput>(this When<TInput, TOutput> when, string discription, Func<TOutput, ValueTask> thenBlock)
        {
            return new ThenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, TOutput2> ThenAsync<TInput, TOutput1, TOutput2>(this When<TInput, TOutput1> when, string discription, Func<ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// when
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput1, TOutput2> ThenAsync<TInput, TOutput1, TOutput2>(this When<TInput, TOutput1> when, string discription, Func<TOutput1, ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, object> ThenAsync<TInput, TOutput>(this WhenAsync<TInput, TOutput> when, string discription, Func<ValueTask> thenBlock)
        {
            return new ThenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput, object> ThenAsync<TInput, TOutput>(this WhenAsync<TInput, TOutput> when, string discription, Func<TOutput, ValueTask> thenBlock)
        {
            return new ThenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, TOutput2> ThenAsync<TInput, TOutput1, TOutput2>(this WhenAsync<TInput, TOutput1> when, string discription, Func<ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// when
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput1, TOutput2> ThenAsync<TInput, TOutput1, TOutput2>(this WhenAsync<TInput, TOutput1> when, string discription, Func<TOutput1, ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = when,
            };
        }

        #endregion

        #region and then

        /// <summary>
        /// And then
        /// </summary>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, object> And<TInput, TOutput>(this Then<TInput, TOutput> then, string discription, Action thenBlock)
        {
            return new Then<object, object>
            {
                CodeBlock = _ =>
                {
                    thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput, object> And<TInput, TOutput>(this Then<TInput, TOutput> then, string discription, Action<TOutput> thenBlock)
        {
            return new Then<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, TOutput2> And<TInput, TOutput1, TOutput2>(this Then<TInput, TOutput1> then, string discription, Func<TOutput2> thenBlock)
        {
            return new Then<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput1, TOutput2> And<TInput, TOutput1, TOutput2>(this Then<TInput, TOutput1> then, string discription, Func<TOutput1, TOutput2> thenBlock)
        {
            return new Then<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, object> And<TInput, TOutput>(this ThenAsync<TInput, TOutput> then, string discription, Action thenBlock)
        {
            return new Then<object, object>
            {
                CodeBlock = _ =>
                {
                    thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput, object> And<TInput, TOutput>(this ThenAsync<TInput, TOutput> then, string discription, Action<TOutput> thenBlock)
        {
            return new Then<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<object, TOutput2> And<TInput, TOutput1, TOutput2>(this ThenAsync<TInput, TOutput1> then, string discription, Func<TOutput2> thenBlock)
        {
            return new Then<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// And then
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="then"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static Then<TOutput1, TOutput2> And<TInput, TOutput1, TOutput2>(this ThenAsync<TInput, TOutput1> then, string discription, Func<TOutput1, TOutput2> thenBlock)
        {
            return new Then<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = then,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, object> AndAsync<TInput, TOutput>(this Then<TInput, TOutput> when, string discription, Func<ValueTask> thenBlock)
        {
            return new ThenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput, object> AndAsync<TInput, TOutput>(this Then<TInput, TOutput> when, string discription, Func<TOutput, ValueTask> thenBlock)
        {
            return new ThenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this Then<TInput, TOutput1> when, string discription, Func<ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// when
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput1, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this Then<TInput, TOutput1> when, string discription, Func<TOutput1, ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, object> AndAsync<TInput, TOutput>(this ThenAsync<TInput, TOutput> when, string discription, Func<ValueTask> thenBlock)
        {
            return new ThenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput, object> AndAsync<TInput, TOutput>(this ThenAsync<TInput, TOutput> when, string discription, Func<TOutput, ValueTask> thenBlock)
        {
            return new ThenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// then
        /// </summary>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<object, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this ThenAsync<TInput, TOutput1> when, string discription, Func<ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<object, TOutput2>
            {
                CodeBlock = _ => thenBlock(),
                Discription = discription,
                PreviousBlock = when,
            };
        }

        /// <summary>
        /// when
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="when"></param>
        /// <param name="discription"></param>
        /// <param name="thenBlock"></param>
        /// <returns></returns>
        public static ThenAsync<TOutput1, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this ThenAsync<TInput, TOutput1> when, string discription, Func<TOutput1, ValueTask<TOutput2>> thenBlock)
        {
            return new ThenAsync<TOutput1, TOutput2>
            {
                CodeBlock = thenBlock,
                Discription = discription,
                PreviousBlock = when,
            };
        }

        #endregion
    }
}
