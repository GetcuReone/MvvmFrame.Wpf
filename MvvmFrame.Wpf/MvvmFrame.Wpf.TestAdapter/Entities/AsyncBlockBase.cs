using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Async code block
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public abstract class AsyncBlockBase<TInput, TOutput> : BlockBase
    {
        internal Func<TInput, ValueTask<TOutput>> CodeBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsAsync => true;

        internal override async ValueTask<object> ExecuteAsync(object param)
        {
            if (param is TInput input)
                return await CodeBlock(input);
            else if (typeof(TInput).IsAssignableFrom(typeof(object)) && CodeBlock is Func<object, ValueTask<TOutput>> newCodeBlock)
                return newCodeBlock(param);

            throw new ArgumentException($"Code block '{Discription}' expected input {nameof(param)} different type");
        }

        internal override object Execute(object param) => throw new NotImplementedException();
    }
}
