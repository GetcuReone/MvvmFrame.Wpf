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

            throw new ArgumentException($"{nameof(param)} must be of a different type");
        }

        internal override object Execute(object param) => throw new NotImplementedException();
    }
}
