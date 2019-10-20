using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.AFAP.UnitTests.GetAdapter.Env
{
    public sealed class GetAdapterViewModel: ViewModelBase
    {
        public int GetAdapterCallCounter { get; private set; } = 0;
        public int CreateObjectCallCounter { get; private set; } = 0;

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
