using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter;
using MvvmFrame.Wpf.TestAdapter.Helpers;

namespace MvvmFrame.Wpf.UnitTests.PageTests
{
    [TestClass]
    public class PageTests: FrameTestBase
    {
        [TestMethod]
        [Description("[ui] Check navigation")]
        public void TestMethod1()
        {
            Given("Initialize view-model", frame => ViewModelBase.CreateViewModel<PageViewModel>(frame))
                .When("Navigating", viewModel =>
                {
                    ViewModelBase.Navigate<Page>(viewModel);
                    return viewModel;
                })
                .ThenAsync("Check navigation", async viewModel =>
                {
                    await Task.Delay(10_000);
                })
                .Run();
        }
    }
}
