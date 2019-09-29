namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'Then'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class ThenAsync<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        internal override string NameBlock => "Then";
        internal ThenAsync() { }
    }
}
