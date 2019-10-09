using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.TestAdapter;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.UnitTests.Common;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.Navigation
{
    [TestClass]
    public sealed class NavigationTests : FrameTestBase
    {
        private async ValueTask<TViewModel> WaitLoadPageAndCheckViewModelAsync<TPage, TViewModel>(TViewModel viewModel)
            where TPage: Page, IPage
            where TViewModel: ViewModelBase
        {
            await Task.Delay(Timeuots.Second.One);
            var page = CheckTypeAndGetPage<TPage>();
            await page.WaitLoadAsync();
            Assert.AreEqual(viewModel, page.DataContext, "view-model must be DataContext");
            return viewModel;
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] check method ViewModelBase.Navigate")]
        [TestMethod]
        public void NavigationStaticTestCase()
        {
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .When("Navigate page", viewModel => ViewModelBase.Navigate<NavigationPage>(viewModel))
                .Then("Navigate method worked", result => result.HasSuccessAndGetViewModel())
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
                .Then("Navigate method worked", result => result.HasSuccessAndGetViewModel())
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

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] check method GoBack")]
        [TestMethod]
        public void GoBackTestCase()
        {
            NavigationViewModel navigationViewModel = null;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .And("Navigate NavigationPage", viewModel => 
                {
                    navigationViewModel = viewModel;
                    return ViewModelBase.Navigate<NavigationPage>(viewModel);
                })
                .And("Check success Navigate method for NavigationPage", nResult => nResult.HasSuccessAndGetViewModel())
                .AndAsync("Check load NavigationPage", async viewModel => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, ViewModelBase>(viewModel))
                .And("Navigate SecondPage", viewModel => viewModel.Navigate<SecondPage, SecondViewModel>())
                .And("Check success Navigate method for SecondPage", nResult => nResult.HasSuccessAndGetViewModel())
                .AndAsync("Check load SecondPage", async viewModel => await WaitLoadPageAndCheckViewModelAsync<SecondPage, SecondViewModel>(viewModel))
                .And("Check CanGoBack", viewModel =>
                {
                    Assert.IsTrue(viewModel.NavigationManager.CanGoBack, "CanGoBack must be true");
                    return viewModel;
                })
                .When("Execute GoBack", viewModel => viewModel.NavigationManager.GoBack())
                .ThenAsync("Check load NavigationPage", async () => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(navigationViewModel))
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] check method GoForward")]
        [TestMethod]
        public void GoForwardTestCase()
        {
            NavigationViewModel firstViewModel = null;
            SecondViewModel secondViewModel = null;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .And("Navigate NavigationPage", viewModel =>
                {
                    firstViewModel = viewModel;
                    return ViewModelBase.Navigate<NavigationPage>(viewModel);
                })
                .And("Check success Navigate method for NavigationPage", nResult => nResult.HasSuccessAndGetViewModel())
                .AndAsync("Check load NavigationPage", async viewModel => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, ViewModelBase>(viewModel))
                .And("Navigate SecondPage", viewModel => viewModel.Navigate<SecondPage, SecondViewModel>())
                .And("Check success Navigate method for SecondPage", nResult => nResult.HasSuccessAndGetViewModel())
                .AndAsync("Check load SecondPage", async viewModel => 
                {
                    await WaitLoadPageAndCheckViewModelAsync<SecondPage, SecondViewModel>(viewModel);
                    secondViewModel = viewModel;
                })
                .And("Check CanGoBack", () => Assert.IsTrue(secondViewModel.NavigationManager.CanGoBack, "CanGoBack must be true"))
                .And("Execute GoBack", () => secondViewModel.NavigationManager.GoBack())
                .AndAsync("Check load NavigationPage", async () => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(firstViewModel))
                .And("Check CanGoForward", () => Assert.IsTrue(firstViewModel.NavigationManager.CanGoForward, "CanGoForward must be true"))
                .When("Execute GoForward", () => secondViewModel.NavigationManager.GoForward())
                .ThenAsync("Check load NavigationPage", async () => await WaitLoadPageAndCheckViewModelAsync<SecondPage, SecondViewModel>(secondViewModel))
                .Run<TestWindow>(window => window.mainFrame);
        }
    }
}
