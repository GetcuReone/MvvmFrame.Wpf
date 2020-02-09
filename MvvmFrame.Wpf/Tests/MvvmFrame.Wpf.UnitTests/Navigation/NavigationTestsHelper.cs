using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetcuReone.MvvmFrame.Wpf.Entities;

namespace MvvmFrame.Wpf.UnitTests.Navigation
{
    public static class NavigationTestsHelper
    {
        public static TViewModel HasSuccessAndGetViewModel<TViewModel>(this NavigateResult<TViewModel> navigateResult)
            where TViewModel: ViewModelBase
        {
            Assert.IsTrue(navigateResult.IsNavigate, "navigate method not worked");
            return navigateResult.ViewModel;
        }
    }
}
