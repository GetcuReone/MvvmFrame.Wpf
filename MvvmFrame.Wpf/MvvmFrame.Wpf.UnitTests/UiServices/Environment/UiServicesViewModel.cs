using System;

namespace MvvmFrame.Wpf.UnitTests.UiServices.Environment
{
    public sealed class UiServicesViewModel: ViewModelBase
    {
        public int CreateObjectCallCounter { get; set; }

        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            CreateObjectCallCounter++;
            return base.CreateObject(factoryFunc, parameters);
        }
    }
}
