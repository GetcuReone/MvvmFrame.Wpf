namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'When'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class WhenAsync<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        internal override string NameBlock => "When";
        internal WhenAsync() { }
    }
}
