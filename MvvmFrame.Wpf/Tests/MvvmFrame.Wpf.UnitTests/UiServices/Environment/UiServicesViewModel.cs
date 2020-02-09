using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System;
using System.Threading.Tasks;

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

        protected override void Initialize()
        {

        }

        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            return default;
        }

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            return default;
        }

        protected override ValueTask OnLoadPageAsync()
        {
            return default;
        }
    }
}
