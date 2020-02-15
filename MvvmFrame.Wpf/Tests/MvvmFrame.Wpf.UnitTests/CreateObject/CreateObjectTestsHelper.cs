using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestsCommon;
using MvvmFrame.Wpf.UnitTests.CreateObject.Environment;

namespace MvvmFrame.Wpf.UnitTests.CreateObject
{
    public static class CreateObjectTestsHelper
    {
        public static CreateObjectViewModel NotNull(this CreateObjectViewModel viewModel)
        {
            Assert.IsNotNull(viewModel, "view-model can not be null");
            return viewModel;
        }

        public static CreateObjectViewModel CheckCreateObject(this CreateObjectViewModel viewModel, int expectedCountCallCreateObject)
        {
            TestHelper.AssertCounter(expectedCountCallCreateObject, viewModel.CreateObjectCallCounter, "CreateObject");
            return viewModel;
        }
    }
}
