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
        public void PageTests_CheckNavigationTestCase()
        {
            Given("Initialize view-model", frame => ViewModelBase.CreateViewModel<TestPageViewModel>(frame))
                .WhenAsync("Navigating", async viewModel =>
                {
                    ViewModelBase.Navigate<TestPage>(viewModel);
                    await viewModel.NavigationManager.WaitNavigation(viewModel);
                })
                .Then("Check navigation", CheckTypeAndGetPage<TestPage>)
                .Run<TestWindow>(window => window.mainFrame);
        }

        //[TestMethod]
        //public void PageTests_TestMethod()
        //{
        //    TestWindow window = new TestWindow();

        //    window.Loaded += async (sender, e) =>
        //    {
        //        await System.Threading.Tasks.Task.Delay(200);
        //        window.Close();
        //    };

        //    window.ShowDialog();
        //}
    }
}
