using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.CreateObject.Environment
{
    public sealed class CreateObjectViewModel : ViewModelBase
    {
        public int GetModelCallCounter { get; set; }
        public int GetViewModelCallCounter { get; set; }
        public int CreateObjectCallCounter { get; set; }
        public CreateObjectModel Model { get; private set; }

        protected override void Initialize()
        {
            Model = GetModel<CreateObjectModel>();
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

        public override TModel GetModel<TModel>()
        {
            GetModelCallCounter++;
            return base.GetModel<TModel>();
        }

        public override TViewModel GetViewModel<TViewModel>()
        {
            GetViewModelCallCounter++;
            return base.GetViewModel<TViewModel>();
        }

        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            CreateObjectCallCounter++;
            return base.CreateObject(factoryFunc, parameters);
        }
    }
}
