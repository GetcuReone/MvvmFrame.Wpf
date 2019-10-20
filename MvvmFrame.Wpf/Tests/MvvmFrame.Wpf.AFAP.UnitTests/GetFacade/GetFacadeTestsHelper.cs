using MvvmFrame.Wpf.AFAP.UnitTests.GetFacade.Env;
using MvvmFrame.Wpf.UnitTests.Common;

namespace MvvmFrame.Wpf.AFAP.UnitTests.GetFacade
{
    public static class GetFacadeTestsHelper
    {
        public static GetFacadeViewModel CheckCreateObject(this GetFacadeViewModel viewModel, int expectedCountCallCreateObject)
        {
            TestHelper.AssertCounter(expectedCountCallCreateObject, viewModel.CreateObjectCallCounter, "CreateObject");
            return viewModel;
        }
    }
}
