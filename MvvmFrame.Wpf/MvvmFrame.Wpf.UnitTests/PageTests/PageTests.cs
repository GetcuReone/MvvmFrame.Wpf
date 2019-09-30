using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter;
using MvvmFrame.Wpf.TestAdapter.Attributes;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.UnitTests.Common;

namespace MvvmFrame.Wpf.UnitTests.PageTests
{
    [TestClass]
    public class PageTests: FrameTestBase
    {
        [CustomTestMethod]
        [Description("[UI] Check navigation")]
        [Timeout(Timeuot.Second.Ten)]
        public void PageTests_CheckNavigationTestCase()
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

        [TestMethod]
        public void TestMethod()
        {
            TestWindow window = new TestWindow();

            window.Loaded += async (sender, e) =>
            {
                await System.Threading.Tasks.Task.Delay(200);
                window.Close();
            };

            window.ShowDialog();
        }
    }
}
