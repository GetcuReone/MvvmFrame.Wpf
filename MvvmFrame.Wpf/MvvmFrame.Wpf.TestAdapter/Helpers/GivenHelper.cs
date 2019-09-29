using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper for Givan
    /// </summary>
    public static class GivenHelper
    {
        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<object, object> And<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Action givenBlock)
        {
            return new Given<object, object>
            {
                CodeBlock = _ =>
                {
                    givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<TOutput, object> And<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Action<TOutput> givenBlock)
        {
            return new Given<TOutput, object>
            {
                CodeBlock = output =>
                {
                    givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<object, TOutput2> And<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<TOutput2> givenBlock)
        {
            return new Given<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<TOutput1, TOutput2> And<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<TOutput1, TOutput2> givenBlock)
        {
            return new Given<TOutput1, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<object, object> And<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Action givenBlock)
        {
            return new Given<object, object>
            {
                CodeBlock = _ =>
                {
                    givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<TOutput, object> And<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Action<TOutput> givenBlock)
        {
            return new Given<TOutput, object>
            {
                CodeBlock = output =>
                {
                    givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<object, TOutput2> And<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<TOutput2> givenBlock)
        {
            return new Given<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static Given<TOutput1, TOutput2> And<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<TOutput1, TOutput2> givenBlock)
        {
            return new Given<TOutput1, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<object, object> AndAsync<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Func<ValueTask> givenBlock)
        {
            return new GivenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<TOutput, object> AndAsync<TInput, TOutput>(this Given<TInput, TOutput> given, string discription, Func<TOutput, ValueTask> givenBlock)
        {
            return new GivenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<object, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsync<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<TOutput1, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this Given<TInput, TOutput1> given, string discription, Func<TOutput1, ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsync<TOutput1, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<object, object> AndAsync<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Func<ValueTask> givenBlock)
        {
            return new GivenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<TOutput, object> AndAsync<TInput, TOutput>(this GivenAsync<TInput, TOutput> given, string discription, Func<TOutput, ValueTask> givenBlock)
        {
            return new GivenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<object, TOutput2> AndAsycn<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsync<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = given,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput1"></typeparam>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="given"></param>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public static GivenAsync<TOutput1, TOutput2> AndAsync<TInput, TOutput1, TOutput2>(this GivenAsync<TInput, TOutput1> given, string discription, Func<TOutput1, ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsync<TOutput1, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = given,
            };
        }
    }
}
