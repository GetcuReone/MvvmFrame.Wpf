using MvvmFrame.Wpf.Tests.UiServices.Env;
using MvvmFrame.Wpf.TestsCommon;

namespace MvvmFrame.Wpf.Tests.UiServices
{
    public static class UiServicesTestsHelper
    {
        public static UiServicesViewModel CheckCreateObject(this UiServicesViewModel viewModel, int expectedCountCallCreateObject)
        {
            TestHelper.AssertCounter(expectedCountCallCreateObject, viewModel.CreateObjectCallCounter, "CreateObject");
            return viewModel;
        }
    }
}
