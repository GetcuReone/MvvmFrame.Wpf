namespace MvvmFrame.Wpf.TestAdapter.Entities
{

    /// <summary>
    /// Block 'given'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class Given<TInput, TOutput> : BlockBase<TInput, TOutput>
    {
        internal Given() { }

        internal override string NameBlock => "Given";
    }
}
