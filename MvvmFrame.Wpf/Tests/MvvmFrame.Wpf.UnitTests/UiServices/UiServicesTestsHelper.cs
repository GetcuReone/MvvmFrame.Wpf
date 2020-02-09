using GetcuReone.MvvmFrame.Wpf.UnitTests.Common;
using GetcuReone.MvvmFrame.Wpf.UnitTests.UiServices.Environment;

namespace MvvmFrame.Wpf.UnitTests.UiServices
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
