using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter;
using MvvmFrame.Wpf.UnitTests.Common;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.Navigation
{
    [TestClass]
    public sealed class NavigationTests : FrameTestBase
    {
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] check method ViewModelBase.Navigate")]
        [TestMethod]
        public void NavigationStaticTestCase()
        {
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .When("Navigate page", viewModel => ViewModelBase.Navigate<NavigationPage>(viewModel))
                .Then("Navigate method worked", result =>
                {
                    Assert.IsTrue(result.IsNavigate, "navigate method not worked");
                    return result.ViewModel;
                })
                .AndAsync("Wait one secode", async viewModel =>
                {
                    await Task.Delay(Timeuots.Second.One);
                    return viewModel;
                })
                .And("Chekc page and view-model", viewModel =>
                {
                    var page = CheckTypeAndGetPage<NavigationPage>();
                    Assert.AreEqual(viewModel, page.DataContext, "view-model must be DataContext");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] check method ViewModelBase.Navigate")]
        [TestMethod]
        public void NavigationTestCase()
        {
            NavigationViewModel firstViewModel = null;
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .When("Navigate page", viewModel => 
                {
                    firstViewModel = viewModel;
                    return viewModel.Navigate<NavigationPage, NavigationViewModel>();
                })
                .Then("Navigate method worked", result =>
                {
                    Assert.IsTrue(result.IsNavigate, "navigate method not worked");
                    return result.ViewModel;
                })
                .AndAsync("Wait one secode", async viewModel =>
                {
                    await Task.Delay(Timeuots.Second.One);
                    return viewModel;
                })
                .And("Chekc page and view-model", viewModel =>
                {
                    var page = CheckTypeAndGetPage<NavigationPage>();
                    Assert.AreEqual(viewModel, page.DataContext, "view-model must be DataContext");
                    Assert.AreNotEqual(firstViewModel, viewModel, "view-models must differ");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }
    }
}
