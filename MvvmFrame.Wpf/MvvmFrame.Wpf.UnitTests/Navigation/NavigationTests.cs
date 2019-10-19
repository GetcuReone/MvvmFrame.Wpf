using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.Entities;
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

        private ValueTask<TViewModel> WaitLoadPageAndCheckViewModelAsync<TPage, TViewModel>(NavigateResult<ViewModelBase> navigateResult)
            where TPage : Page, IPage
            where TViewModel : ViewModelBase
        {
            return WaitLoadPageAndCheckViewModelAsync<TPage, TViewModel>((TViewModel)navigateResult.HasSuccessAndGetViewModel());
        }

        [Timeout(Timeuots.Second.Ten)]
        [Description("[ui][navigation] check method ViewModelBase.Navigate")]
        [TestMethod]
        public void NavigationStaticTestCase()
        {
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .And("Check navigation properties before navigate", viewModel => 
                {
                    Assert.IsFalse(viewModel.IsNavigated, "IsNavigated must be false");
                    Assert.IsFalse(viewModel.IsLoaded, "IsNavigated must be false");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");
                    Assert.AreEqual(0, viewModel.MethodCallLog.Count, "call log must be is empty");
                    return viewModel;
                })
                .When("Navigate page", viewModel => ViewModelBase.Navigate<NavigationPage>(viewModel))
                .Then("Navigate method worked", result => result.HasSuccessAndGetViewModel())
                .AndAsync("Wait one secode", async viewModel => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>((NavigationViewModel)viewModel))
                .And("Check navigation properties after navigate", viewModel => 
                {
                    Assert.IsTrue(viewModel.IsNavigated, "IsNavigated must be true");
                    Assert.IsTrue(viewModel.IsLoaded, "IsNavigated must be true");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");

                    Assert.AreEqual(2, viewModel.MethodCallLog.Count, "long call log should be 2");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
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
                .And("Check navigation properties before navigate", viewModel =>
                {
                    Assert.IsFalse(viewModel.IsNavigated, "IsNavigated must be false");
                    Assert.IsFalse(viewModel.IsLoaded, "IsNavigated must be false");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");
                    Assert.AreEqual(0, viewModel.MethodCallLog.Count, "call log must be is empty");
                    return viewModel;
                })
                .When("Navigate page", viewModel => 
                {
                    firstViewModel = viewModel;
                    return viewModel.Navigate<NavigationPage, NavigationViewModel>();
                })
                .Then("Navigate method worked", result => result.HasSuccessAndGetViewModel())
                .AndAsync("Wait one secode", async viewModel => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>((NavigationViewModel)viewModel))
                .And("Check navigation properties after navigate", viewModel =>
                {
                    Assert.IsTrue(viewModel.IsNavigated, "IsNavigated must be true");
                    Assert.IsTrue(viewModel.IsLoaded, "IsNavigated must be true");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");

                    Assert.AreEqual(2, viewModel.MethodCallLog.Count, "long call log should be 2");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] navigate next page")]
        [TestMethod]
        public void LeaveTestCase()
        {
            NavigationViewModel firstViewModel = null;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .And("First navigate", viewModel =>
                {
                    firstViewModel = viewModel;
                    return ViewModelBase.Navigate<NavigationPage>(viewModel);
                })
                .AndAsync("Wait load page", async nResult => await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(nResult))
                .And("Init second view-model and check properties", viewModel => 
                {
                    var secondViewModel = viewModel.GetViewModel<NavigationViewModel>();

                    // check first properties
                    Assert.IsTrue(viewModel.IsNavigated, "IsNavigated must be true");
                    Assert.IsTrue(viewModel.IsLoaded, "IsNavigated must be true");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");
                    Assert.AreEqual(2, viewModel.MethodCallLog.Count, "long call log should be 2");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");

                    // check second properties
                    Assert.IsFalse(secondViewModel.IsNavigated, "second IsNavigated must be false");
                    Assert.IsFalse(secondViewModel.IsLoaded, "second IsNavigated must be false");
                    Assert.IsFalse(secondViewModel.IsLeaved, "second IsNavigated must be false");
                    Assert.AreEqual(0, secondViewModel.MethodCallLog.Count, "second call log must be is empty");
                    return secondViewModel;
                })
                .WhenAsync("Second navigate and wait load page", async viewModel => 
                {
                    NavigateResult<ViewModelBase> nResult = ViewModelBase.Navigate<NavigationPage>(viewModel);
                    return await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(nResult);
                })
                .Then("Check properties after second navigate", viewModel => 
                {
                    // check first properties
                    Assert.IsFalse(firstViewModel.IsNavigated, "IsNavigated must be false");
                    Assert.IsFalse(firstViewModel.IsLoaded, "IsNavigated must be false");
                    Assert.IsTrue(firstViewModel.IsLeaved, "IsNavigated must be true");
                    Assert.AreEqual(3, firstViewModel.MethodCallLog.Count, "long call log should be 3");
                    Assert.AreEqual("OnGoPageAsync", firstViewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", firstViewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                    Assert.AreEqual("OnLeavePageAsync", firstViewModel.MethodCallLog[2], "3st must be called OnLeavePageAsync");

                    // check second properties
                    Assert.IsTrue(viewModel.IsNavigated, "IsNavigated must be true");
                    Assert.IsTrue(viewModel.IsLoaded, "IsNavigated must be true");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");
                    Assert.AreEqual(2, viewModel.MethodCallLog.Count, "long call log should be 2");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Ten)]
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
                .And("Check properties", viewModel => 
                {
                    Assert.IsTrue(viewModel.IsNavigated, "IsNavigated must be true");
                    Assert.IsTrue(viewModel.IsLoaded, "IsNavigated must be true");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");
                    Assert.AreEqual(5, viewModel.MethodCallLog.Count, "long call log should be 5");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                    Assert.AreEqual("OnLeavePageAsync", viewModel.MethodCallLog[2], "3st must be called OnLeavePageAsync");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[3], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[4], "2st must be called OnLoadPageAsync");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Ten)]
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
                .And("Check properties", () => 
                {
                    Assert.IsFalse(firstViewModel.IsNavigated, "IsNavigated must be false");
                    Assert.IsFalse(firstViewModel.IsLoaded, "IsNavigated must be false");
                    Assert.IsTrue(firstViewModel.IsLeaved, "IsNavigated must be true");
                    Assert.AreEqual(6, firstViewModel.MethodCallLog.Count, "long call log should be 5");
                    Assert.AreEqual("OnGoPageAsync", firstViewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", firstViewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                    Assert.AreEqual("OnLeavePageAsync", firstViewModel.MethodCallLog[2], "3st must be called OnLeavePageAsync");
                    Assert.AreEqual("OnGoPageAsync", firstViewModel.MethodCallLog[3], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", firstViewModel.MethodCallLog[4], "2st must be called OnLoadPageAsync");
                    Assert.AreEqual("OnLeavePageAsync", firstViewModel.MethodCallLog[5], "3st must be called OnLeavePageAsync");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Ten)]
        [Description("[ui][navigation] check method Refresh")]
        [TestMethod]
        public void RefreshTestCase()
        {
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .AndAsync("Navigate", async viewModel =>
                {
                    var nResult = ViewModelBase.Navigate<NavigationPage>(viewModel);
                    return await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(nResult);
                })
                .WhenAsync("Execute refresh", async viewModel =>
                {
                    viewModel.NavigationManager.Refresh();
                    return await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(viewModel);
                })
                .Then("Check properties", viewModel =>
                {
                    Assert.IsTrue(viewModel.IsNavigated, "IsNavigated must be true");
                    Assert.IsTrue(viewModel.IsLoaded, "IsNavigated must be true");
                    Assert.IsFalse(viewModel.IsLeaved, "IsNavigated must be false");
                    Assert.AreEqual(4, viewModel.MethodCallLog.Count, "long call log should be 4");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                    Assert.AreEqual("OnGoPageAsync", viewModel.MethodCallLog[2], "3st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", viewModel.MethodCallLog[3], "4st must be called OnLoadPageAsync");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation] check method WaitNavigation")]
        [TestMethod]
        public void WaitNavigationAsyncTestCase()
        {
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .And("Navigate", viewModel => ViewModelBase.Navigate<NavigationPage>(viewModel).HasSuccessAndGetViewModel())
                .WhenAsync("Wait navigation", async viewModel => await viewModel.NavigationManager.WaitNavigationAsync(viewModel))
                .Then("Check navigate", waitResult =>
                {
                    Assert.IsTrue(waitResult, "did not wait for navigation");
                    CheckTypeAndGetPage<NavigationPage>();
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeuots.Second.Ten)]
        [Description("[ui][navigation] check method WaitNavigation")]
        [TestMethod]
        public void WaitLeaveViewModelAsyncTestCase()
        {
            NavigationViewModel navigationViewModel = null;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .AndAsync("Navigate NavigationPage", async viewModel =>
                {
                    navigationViewModel = viewModel;
                    var nResult = ViewModelBase.Navigate<NavigationPage>(viewModel);
                    return await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(nResult);
                })
                .WhenAsync("Wait leave", async viewModel =>
                {
                    ValueTask<bool> task = viewModel.NavigationManager.WaitLeaveViewModelAsync(viewModel);

                    var nResult = viewModel.Navigate<SecondPage, SecondViewModel>();
                    nResult.HasSuccessAndGetViewModel();

                    return await task;
                })
                .Then("Check properties", waitResult =>
                {
                    Assert.IsTrue(waitResult, "did not wait for leaving");

                    Assert.IsFalse(navigationViewModel.IsNavigated, "IsNavigated must be false");
                    Assert.IsFalse(navigationViewModel.IsLoaded, "IsNavigated must be false");
                    Assert.IsTrue(navigationViewModel.IsLeaved, "IsNavigated must be true");
                    Assert.AreEqual(3, navigationViewModel.MethodCallLog.Count, "long call log should be 3");
                    Assert.AreEqual("OnGoPageAsync", navigationViewModel.MethodCallLog[0], "1st must be called OnGoPageAsync");
                    Assert.AreEqual("OnLoadPageAsync", navigationViewModel.MethodCallLog[1], "2st must be called OnLoadPageAsync");
                    Assert.AreEqual("OnLeavePageAsync", navigationViewModel.MethodCallLog[2], "3st must be called OnLeavePageAsync");
                })
                .Run<TestWindow>(window => window.mainFrame);
        }

        #region Initialize

        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][navigation][view-model] check method Initialize")]
        [TestMethod]
        public void ViewModel_InitializeTestCase()
        {
            Given("Init view-model", frame => ViewModelBase.CreateViewModel<NavigationViewModel>(frame))
                .And("Check init method before navigate", viewModel =>
                {
                    Assert.AreEqual(0, viewModel.InitializeCallCounter, "method must be not called");
                    return viewModel;
                })
                .WhenAsync("Navigate NavigationPage", async viewModel =>
                {
                    var nResult = ViewModelBase.Navigate<NavigationPage>(viewModel);
                    return await WaitLoadPageAndCheckViewModelAsync<NavigationPage, NavigationViewModel>(nResult);
                })
                .Then("Check init method after navigate", viewModel => Assert.AreEqual(1, viewModel.InitializeCallCounter, "method must be called"))
                .Run<TestWindow>(window => window.mainFrame);
        }

        #endregion
    }
}
