namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'Then'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class Then<TInput, TOutput> : BlockBase<TInput, TOutput>
    {
        internal override string NameBlock => "Then";

        internal Then() { }
    }
}
