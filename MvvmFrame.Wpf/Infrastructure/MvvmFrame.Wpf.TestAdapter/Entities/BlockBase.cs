using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Code block
    /// </summary>
    public abstract class BlockBase
    {
        /// <summary>
        /// Block name
        /// </summary>
        public abstract string NameBlock { get; }
        internal BlockBase PreviousBlock { get; set; }

        /// <summary>
        /// Discription
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// Is async code block
        /// </summary>
        public virtual bool IsAsync => false;

        /// <summary>
        /// execute
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        internal abstract ValueTask<object> ExecuteAsync(object param);

        internal abstract object Execute(object param);
    }

    /// <summary>
    /// Code block
    /// </summary>
    public abstract class BlockBase<TInput, TOutput>: BlockBase
    {
        /// <summary>
        /// Code block
        /// </summary>
        public Func<TInput, TOutput> CodeBlock { get; set; }

        internal override ValueTask<object> ExecuteAsync(object param) => throw new NotImplementedException();

        internal override object Execute(object param)
        {
            if (param is TInput input)
                return CodeBlock(input);
            else if (typeof(TInput).IsAssignableFrom(typeof(object)) && CodeBlock is Func<object, TOutput> newCodeBlock)
                return newCodeBlock(param);

            throw new ArgumentException($"Code block '{Discription}' expected input {nameof(param)} different type");
        }
    }
}
