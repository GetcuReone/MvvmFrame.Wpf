namespace MvvmFrame.Wpf.AFAP.UnitTests.GetAdapter.Env
{
    public sealed class GetAdapterModel: ModelBase
    {
        public int GetAdapterCallCounter { get; private set; } = 0;

        public override TAdapter GetAdapter<TAdapter>()
        {
            GetAdapterCallCounter++;
            return base.GetAdapter<TAdapter>();
        }
    }
}
