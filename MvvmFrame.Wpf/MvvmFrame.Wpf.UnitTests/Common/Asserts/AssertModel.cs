using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.UnitTests.Common.Entities;

namespace MvvmFrame.Wpf.UnitTests.Common.Asserts
{
    //public static class AssertModel
    //{
    //    public static void NullAndType<TModel>(IModel model)
    //        where TModel : IModel
    //    {
    //        Assert.IsNotNull(model, "model should not be null");
    //        Assert.IsTrue(model is TModel, "model must be other type");
    //    }

    //    public static void AssertCallHandlers(
    //        ModelTest model,
    //        int? onVerifyPropertyChangeCallNumber = null,
    //        int? onPropertyChangedCallNumber = null,
    //        int? onErrorsCallNumber = null)
    //    {
    //        if (onVerifyPropertyChangeCallNumber.HasValue)
    //            TestHelper.AssertCounter(onVerifyPropertyChangeCallNumber.Value, model.OnVerifyPropertyChangeCallNumber, nameof(ModelBase.OnVerifyPropertyChange));
    //        if (onPropertyChangedCallNumber.HasValue)
    //            TestHelper.AssertCounter(onPropertyChangedCallNumber.Value, model.OnPropertyChangedCallNumber, nameof(ModelBase.OnPropertyChanged));
    //        if (onErrorsCallNumber.HasValue)
    //            TestHelper.AssertCounter(onErrorsCallNumber.Value, model.OnErrorsCallNumber, nameof(ModelBase.OnErrors));
    //    }

    //    public static void AssertCallMethods(
    //        ModelTest model,
    //        int? getMethodCallNumber = null,
    //        int? setPropertyValueCallNumber = null,
    //        int? verificationCallNumber = null,
    //        int? bindModelCallNumber = null,
    //        int? getFacadeCallNumber = null)
    //    {
    //        if (getMethodCallNumber.HasValue)
    //            TestHelper.AssertCounter(getMethodCallNumber.Value, model.GetModelCallNumber, nameof(ModelBase.GetModel));
    //        if (setPropertyValueCallNumber.HasValue)
    //            TestHelper.AssertCounter(setPropertyValueCallNumber.Value, model.SetPropertyValueCallNumber, "SetPropertyValue");
    //        if (verificationCallNumber.HasValue)
    //            TestHelper.AssertCounter(verificationCallNumber.Value, model.VerificationCallNumber, nameof(ModelBase.Verification));
    //        if (bindModelCallNumber.HasValue)
    //            TestHelper.AssertCounter(bindModelCallNumber.Value, model.BindModelCallNumber, "BindModel");
    //        if (getFacadeCallNumber.HasValue)
    //            TestHelper.AssertCounter(getFacadeCallNumber.Value, model.GetFacadeCallNumber, "GetFacade");
    //    }
    //}
}
