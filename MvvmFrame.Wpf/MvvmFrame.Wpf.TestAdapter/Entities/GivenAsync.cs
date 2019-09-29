namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Given code block
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public sealed class GivenAsync<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        internal GivenAsync() { }

        internal override string NameBlock => "Given";
    }
}
