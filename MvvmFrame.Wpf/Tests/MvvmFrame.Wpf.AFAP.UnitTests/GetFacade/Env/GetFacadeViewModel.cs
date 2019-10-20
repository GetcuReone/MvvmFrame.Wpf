using System;

namespace MvvmFrame.Wpf.AFAP.UnitTests.GetFacade.Env
{
    public sealed class GetFacadeViewModel: ViewModelBase
    {
        public int GetFacadeCallCounter { get; private set; } = 0;
        public int GetAdapterCallCounter { get; private set; } = 0;
        public int CreateObjectCallCounter { get; private set; } = 0;

        public override TFacade GetFacade<TFacade>()
        {
            GetFacadeCallCounter++;
            return base.GetFacade<TFacade>();
        }

        public override TAdapter GetAdapter<TAdapter>()
        {
            GetAdapterCallCounter++;
            return base.GetAdapter<TAdapter>();
        }

        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            CreateObjectCallCounter++;
            return base.CreateObject(factoryFunc, parameters);
        }
    }
}
