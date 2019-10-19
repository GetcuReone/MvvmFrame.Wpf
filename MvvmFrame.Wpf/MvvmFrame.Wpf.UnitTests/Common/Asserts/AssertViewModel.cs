using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.UnitTests.Common.Entities;

namespace MvvmFrame.Wpf.UnitTests.Common.Asserts
{
    //public static class AssertViewModel
    //{
    //    public static void NullAndType<TViewModel>(IViewModel viewModel)
    //        where TViewModel : IModel
    //    {
    //        Assert.IsNotNull(viewModel, "viewModel should not be null");
    //        Assert.IsTrue(viewModel is TViewModel, "viewModel must be other type");
    //    }

    //    public static void AssertCallHandlers(
    //        ViewModelTest viewModelTest,
    //        int? onVerifyPropertyChangeCallNumber = null,
    //        int? onPropertyChangedCallNumber = null,
    //        int? onErrorsCallNumber = null)
    //    {
    //        if (onVerifyPropertyChangeCallNumber.HasValue)
    //            TestHelper.AssertCounter(onVerifyPropertyChangeCallNumber.Value, viewModelTest.OnVerifyPropertyChangeCallNumber, nameof(ViewModelBase.OnVerifyPropertyChange));
    //        if (onPropertyChangedCallNumber.HasValue)
    //            TestHelper.AssertCounter(onPropertyChangedCallNumber.Value, viewModelTest.OnPropertyChangedCallNumber, nameof(ViewModelBase.OnPropertyChanged));
    //        if (onErrorsCallNumber.HasValue)
    //            TestHelper.AssertCounter(onErrorsCallNumber.Value, viewModelTest.OnErrorsCallNumber, nameof(ViewModelBase.OnErrors));
    //    }

    //    public static void AssertCallMethods(
    //        ViewModelTest viewModelTest,
    //        int? getModelCallNumber = null,
    //        int? getViewModelCallNumber = null,
    //        int? setPropertyValueCallNumber = null,
    //        int? createObjectCallNumber = null,
    //        int? verificationCallNumber = null,
    //        int? bindModelCallNumber = null)
    //    {
    //        if (getModelCallNumber.HasValue)
    //            TestHelper.AssertCounter(getModelCallNumber.Value, viewModelTest.GetModelCallNumber, nameof(ViewModelBase.GetModel));
    //        if (createObjectCallNumber.HasValue)
    //            TestHelper.AssertCounter(createObjectCallNumber.Value, viewModelTest.CreateObjectCallNumber, nameof(ViewModelBase.CreateObject));
    //        if (getViewModelCallNumber.HasValue)
    //            TestHelper.AssertCounter(getViewModelCallNumber.Value, viewModelTest.GetViewModelCallNumber, nameof(ViewModelBase.GetViewModel));
    //        if (setPropertyValueCallNumber.HasValue)
    //            TestHelper.AssertCounter(setPropertyValueCallNumber.Value, viewModelTest.SetPropertyValueCallNumber, "SetPropertyValue");
    //        if (verificationCallNumber.HasValue)
    //            TestHelper.AssertCounter(verificationCallNumber.Value, viewModelTest.VerificationCallNumber, nameof(ViewModelBase.Verification));
    //        if (bindModelCallNumber.HasValue)
    //            TestHelper.AssertCounter(bindModelCallNumber.Value, viewModelTest.BindModelCallNumber, "BindModel");
    //    }
    //}
}
