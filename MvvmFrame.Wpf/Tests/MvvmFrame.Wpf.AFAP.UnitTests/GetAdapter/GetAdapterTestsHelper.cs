using MvvmFrame.Wpf.AFAP.UnitTests.GetAdapter.Env;
using MvvmFrame.Wpf.UnitTests.Common;

namespace MvvmFrame.Wpf.AFAP.UnitTests.GetAdapter
{
    public static class GetAdapterTestsHelper
    {
        public static GetAdapterViewModel CheckCreateObject(this GetAdapterViewModel viewModel, int expectedCountCallCreateObject)
        {
            TestHelper.AssertCounter(expectedCountCallCreateObject, viewModel.CreateObjectCallCounter, "CreateObject");
            return viewModel;
        }
    }
}
