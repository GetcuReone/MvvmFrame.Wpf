using ComboPatterns.AFAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.Entities;

namespace MvvmFrame.Wpf.UnitTests.Common.Asserts
{
    public static class AssertUiService
    {
        public static void NullAndType<TUiService>(object service)
        {
            Assert.IsNotNull(service, "service should not be null");
            Assert.IsTrue(service is TUiService, "service must be other type");

            Assert.IsTrue(service is FactoryBase, "service must implement FactoryBase");
            Assert.IsTrue(service is UiServiceBase, "service must implement UiServiceBase");
        }
    }
}
