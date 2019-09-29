namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'When'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class When<TInput, TOutput> : BlockBase<TInput, TOutput>
    {
        internal override string NameBlock => "When";
        internal When() { }
    }
}
