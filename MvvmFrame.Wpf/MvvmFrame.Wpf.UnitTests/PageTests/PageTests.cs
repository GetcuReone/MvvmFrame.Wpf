using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.UnitTests.Common;

namespace MvvmFrame.Wpf.UnitTests.PageTests
{
    [TestClass]
    public class PageTests: FrameTestBase
    {
        [TestMethod]
        [Description("[UI] Check navigation")]
        [Timeout(Timeuot.Second.Ten)]
        public void CheckNavigationTestCase()
        {
            Given("Initialize view-model", frame => ViewModelBase.CreateViewModel<PageViewModel>(frame))
                .WhenAsync("Navigating", async viewModel =>
                {
                    ViewModelBase.Navigate<Page>(viewModel);
                    await viewModel.NavigationManager.WaitNavigation(viewModel);
                    return viewModel.NavigationManager;
                })
                .Then("Check navigation", nManager => Assert.IsTrue(nManager.HasCurrentPageType<Page>(), "type does not match"))
                .Run();
        }
    }
}
