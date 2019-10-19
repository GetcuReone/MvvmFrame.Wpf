using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.CreateObject.Environment
{
    public sealed class CreateObjectViewModel:ViewModelBase
    {
        public int GetModelCallCounter { get; set; }
        public int GetViewModelCallCounter { get; set; }
        public int CreateObjectCallCounter { get; set; }
        public CreateObjectModel Model { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();

            Model = GetModel<CreateObjectModel>();
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
