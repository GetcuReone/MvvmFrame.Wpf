using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper for When
    /// </summary>
    public static class WhenHelper
    {
        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<object, object> When<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Action whenBlock)
        {
            return new When<object, object>
            {
                CodeBlock = _ =>
                {
                    whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<TOutput, object> When<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Action<TOutput> whenBlock)
        {
            return new When<TOutput, object>
            {
                CodeBlock = output =>
                {
                    whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<object, TOutput2> When<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<TOutput2> whenBlock)
        {
            return new When<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<TOutput1, TOutput2> When<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<TOutput1, TOutput2> whenBlock)
        {
            return new When<TOutput1, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<object, object> When<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Action whenBlock)
        {
            return new When<object, object>
            {
                CodeBlock = _ =>
                {
                    whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<TOutput, object> When<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Action<TOutput> whenBlock)
        {
            return new When<TOutput, object>
            {
                CodeBlock = output =>
                {
                    whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<object, TOutput2> When<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<TOutput2> whenBlock)
        {
            return new When<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static When<TOutput1, TOutput2> When<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<TOutput1, TOutput2> whenBlock)
        {
            return new When<TOutput1, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<object, object> WhenAsync<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Func<ValueTask> whenBlock)
        {
            return new WhenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<TOutput, object> WhenAsync<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Func<TOutput, ValueTask> whenBlock)
        {
            return new WhenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<object, TOutput2> WhenAsync<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsync<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<TOutput1, TOutput2> WhenAsync<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<TOutput1, ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsync<TOutput1, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<object, object> WhenAsync<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Func<ValueTask> whenBlock)
        {
            return new WhenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<TOutput, object> WhenAsync<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Func<TOutput, ValueTask> whenBlock)
        {
            return new WhenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<object, TOutput2> WhenAsync<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsync<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public static WhenAsync<TOutput1, TOutput2> WhenAsync<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<TOutput1, ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsync<TOutput1, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }
    }
}
