using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.Entities;
using MvvmFrame.Wpf.UnitTests.Common.Asserts;
using MvvmFrame.Wpf.UnitTests.Common.Entities;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.Common
{
    //[TestClass]
    //public abstract class ViewModelTestBase
    //{
    //    protected ViewModelTest ViewModel { get; private set; }
    //    protected Frame Frame { get; private set; }

    //    [TestInitialize]
    //    public virtual void Initialize()
    //    {
    //        Frame = new Frame();
    //        ViewModel = ViewModelBase.CreateViewModel<ViewModelTest>(Frame, new ModelOptions
    //        {
    //            UseOnlyOnPropertyChanged = false,
    //            UseVerification = true,
    //            UseVerifyPropertyChange= true,
    //        });
    //        AssertViewModel.AssertCallMethods(ViewModel, createObjectCallNumber: 2);
    //    }

    //    protected virtual void AssertCallCreateObject(int number) => AssertViewModel.AssertCallMethods(ViewModel, createObjectCallNumber: 2 + number);
    //}
}
