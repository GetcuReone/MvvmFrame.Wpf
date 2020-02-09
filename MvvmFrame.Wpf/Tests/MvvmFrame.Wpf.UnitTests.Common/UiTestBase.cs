using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetcuReone.MvvmFrame.Interfaces;
using GetcuReone.MvvmFrame.Wpf.Entities;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Entities;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.Common
{
    [TestClass]
    public abstract class UiTestBase : FrameTestBase
    {
        protected async ValueTask<TPage> NavigateAndWaitLoadPageAsync<TPage, TViewModel>(TViewModel viewModel)
            where TPage : Page, IPage, new()
            where TViewModel : ViewModelBase
        {
            NavigateResult<ViewModelBase> nResult = ViewModelBase.Navigate<TPage>(viewModel);
            Assert.IsTrue(nResult.IsNavigate, "navigate method not worked");

            await Task.Delay(Timeuots.Second.One);

            TPage page = CheckTypeAndGetPage<TPage>();
            await page.WaitLoadAsync();
            Assert.AreEqual(viewModel, page.DataContext, "view-model must be DataContext");

            return page;
        }
    }

    [TestClass]
    public abstract class UiTestBase<TViewModel> : UiTestBase
        where TViewModel: ViewModelBase, new()
    {
        protected Given<Frame, TViewModel> GivenInitViewModel()
        {
            return Given("Init view-model", frame => ViewModelBase.CreateViewModel<TViewModel>(frame, ModelOptions.Default));
        }
    }

    public static class UiTestBaseHelper
    {
        public static void RunWindow<TIn, TOut>(this Then<TIn, TOut> then) 
            => then.Run<TestWindow>(window => window.mainFrame);

        public static void RunWindow<TIn, TOut>(this ThenAsync<TIn, TOut> then)
            => then.Run<TestWindow>(window => window.mainFrame);
    }
}
