namespace MvvmFrame.Wpf.AFAP.UnitTests.GetFacade.Env
{
    public sealed class GetFacadeModel: ModelBase
    {
        public int GetFacadeCallCounter { get; private set; } = 0;

        public override TFacade GetFacade<TFacade>()
        {
            GetFacadeCallCounter++;
            return base.GetFacade<TFacade>();
        }
    }
}
