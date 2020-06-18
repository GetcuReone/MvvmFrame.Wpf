using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.Tests.Navigation
{
    public static class NavigationTestsHelper
    {
        public static TViewModel HasSuccessAndGetViewModel<TViewModel>(this NavigateResult<TViewModel> navigateResult)
            where TViewModel : ViewModelBase
        {
            Assert.IsTrue(navigateResult.IsNavigate, "navigate method not worked");
            return navigateResult.ViewModel;
        }
    }
}
