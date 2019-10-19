using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.EventArgs;
using MvvmFrame.EventHandlers;
using MvvmFrame.Wpf.Entities;
using MvvmFrame.Wpf.UnitTests.Common;
using MvvmFrame.Wpf.UnitTests.Common.Asserts;
using MvvmFrame.Wpf.UnitTests.Common.Entities;
using System;
using System.Linq;
using PropertyChangedEventHandler = System.ComponentModel.PropertyChangedEventHandler;

namespace MvvmFrame.Wpf.UnitTests.ViewModel
{
    //[TestClass]
    //public sealed class ViewModelFroModelTests: ViewModelTestBase
    //{
    //    //[TestMethod]
    //    //[Description("[view-model] Check call method OnVerifyPropertyChange")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void OnVerifyPropertyChangeTestCase()
    //    //{
    //    //    ViewModel.OnVerifyPropertyChange();

    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onVerifyPropertyChangeCallNumber: 1);
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] Check call method OnPropertyChanged")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void OnPropertyChangedTestCase()
    //    //{
    //    //    ViewModel.OnPropertyChanged();

    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onPropertyChangedCallNumber: 1);
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] Check method GetModel")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void GetModelTestCase()
    //    //{
    //    //    var result = ViewModel.GetModel<ModelTest>();

    //    //    AssertViewModel.AssertCallMethods(ViewModel, getModelCallNumber: 1);
    //    //    AssertCallCreateObject(1);
    //    //    AssertModel.NullAndType<ModelTest>(result);
    //    //    Assert.AreEqual(ViewModel.Options, result.Options, "options must be match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] Check method GetViewModel")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void GetViewModelTestCase()
    //    //{
    //    //    Entities.ViewModel result = ViewModel.GetViewModel<Entities.ViewModel>();

    //    //    AssertViewModel.AssertCallMethods(ViewModel, getViewModelCallNumber: 1);
    //    //    AssertCallCreateObject(1);
    //    //    AssertViewModel.NullAndType<Entities.ViewModel>(result);
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] Get view-model same type")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void GetViewModelSameTypeTestCase()
    //    //{
    //    //    var result = ViewModel.GetViewModel<ViewModelTest>();

    //    //    AssertViewModel.AssertCallMethods(ViewModel, getViewModelCallNumber: 1);
    //    //    AssertCallCreateObject(1);
    //    //    AssertViewModel.NullAndType<ViewModelTest>(result);
    //    //    Assert.AreEqual(ViewModel.Options, result.Options, "options must be match");
    //    //    Assert.AreEqual(ViewModel.NavigationManager, result.NavigationManager, "NavigationManager must be match");
    //    //    Assert.AreNotEqual(ViewModel, result, "view-models not must match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][view-model] get exception when return view-model")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void ViewModelFroModelTests_GetViewModelNegative()
    //    //{
    //    //    var expectedException = new ArgumentNullException("frame", "frame should not be null");

    //    //    var result = TestHelper.ExpectedException<ArgumentNullException>(() => ViewModelBase.CreateViewModel<ViewModelTest>(null));

    //    //    Assert.AreEqual(expectedException.Message, result.Message, "Messages error must match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] set property value")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void SetPropertyValueTestCase()
    //    //{
    //    //    string prop = "Stone";

    //    //    ViewModel.Name = prop;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1);
    //    //    Assert.AreEqual(prop, ViewModel.Name, $"Name must nave value is {prop}");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] check call method verification when changing a property")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void CheckCallVerificationTestCase()
    //    //{
    //    //    string prop = "Stone";

    //    //    ViewModel.Name = prop;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1, verificationCallNumber: 1);
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] check call method PropertyChanged when changing a property")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void CheckCallOnPropertyChangedTestCase()
    //    //{
    //    //    string prop = "Stone";
    //    //    bool usedPropertyChanged = false;
    //    //    PropertyChangedEventHandler handler = (sender, e) => usedPropertyChanged = true;
    //    //    ViewModel.PropertyChanged += handler;

    //    //    ViewModel.Name = prop;

    //    //    ViewModel.PropertyChanged -= handler;
    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onPropertyChangedCallNumber: 1);
    //    //    Assert.IsTrue(usedPropertyChanged, "handler must executed");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] check call method OnVerifyPropertyChange when changing a property")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void CheckCallOnVerifyPropertyChangeTestCase()
    //    //{
    //    //    string prop = "Stone";
    //    //    bool usedVerifyPropertyChange = false;
    //    //    MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
    //    //    ViewModel.VerifyPropertyChange += handler;

    //    //    ViewModel.Name = prop;

    //    //    ViewModel.VerifyPropertyChange -= handler;
    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onVerifyPropertyChangeCallNumber: 1);
    //    //    Assert.IsTrue(usedVerifyPropertyChange, "handler must executed");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] set property invalid value for verificatio method")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void SetPropertyValueVerificationInvalidTestCase()
    //    //{
    //    //    ViewModel.Name = ViewModelTest.VerificationInvalid;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1, verificationCallNumber: 1);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onErrorsCallNumber: 1);
    //    //    Assert.IsNull(ViewModel.Name, "property not have value is null");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] set property invalid value for event")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void SetPropertyValueInvalidTestCase()
    //    //{
    //    //    string prop = "Stone";
    //    //    Func<string> func = () => string.Empty;
    //    //    MvvmElementPropertyVerifyChangeEventArgs args = null;
    //    //    MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) =>
    //    //    {
    //    //        e.AddError(func);
    //    //        args = e;
    //    //    };
    //    //    ViewModel.VerifyPropertyChange += handler;

    //    //    ViewModel.Name = prop;
    //    //    ViewModel.VerifyPropertyChange -= handler;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onErrorsCallNumber: 1, onVerifyPropertyChangeCallNumber: 1);
    //    //    Assert.IsNotNull(args, "arguments event should be null");
    //    //    Assert.IsFalse(args.IsValid, "event should invalid");
    //    //    Assert.IsTrue(args._errorFuncs.Count == 1, "must one message");
    //    //    Assert.AreEqual(func, args._errorFuncs.Single(), "messages must match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] set property without VerifyPropertyChange")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void SetPropertyValueUseVerifyPropertyChangeTestCase()
    //    //{
    //    //    string prop = "Stone";
    //    //    bool usedVerifyPropertyChange = false;
    //    //    MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
    //    //    ViewModel.VerifyPropertyChange += handler;
    //    //    ((ModelOptions)ViewModel.Options).UseVerifyPropertyChange = false;

    //    //    ViewModel.Name = prop;
    //    //    ViewModel.VerifyPropertyChange -= handler;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1, verificationCallNumber: 1);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onVerifyPropertyChangeCallNumber: 0);
    //    //    Assert.IsFalse(usedVerifyPropertyChange, "handler should not executed");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] set property without Verification")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void SetPropertyValueUseVerificationTestCase()
    //    //{
    //    //    string prop = "Stone";
    //    //    bool usedVerifyPropertyChange = false;
    //    //    MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
    //    //    ViewModel.VerifyPropertyChange += handler;
    //    //    ((ModelOptions)ViewModel.Options).UseVerification = false;

    //    //    ViewModel.Name = prop;
    //    //    ViewModel.VerifyPropertyChange -= handler;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1, verificationCallNumber: 0);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onVerifyPropertyChangeCallNumber: 1);
    //    //    Assert.IsTrue(usedVerifyPropertyChange, "handler must executed");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] set property use only OnPropertyChanged")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void SetPropertyValueUseOnlyOnPropertyChangedTestCase()
    //    //{
    //    //    string prop = "Stone";
    //    //    bool usedVerifyPropertyChange = false;
    //    //    MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
    //    //    ViewModel.VerifyPropertyChange += handler;
    //    //    ((ModelOptions)ViewModel.Options).UseOnlyOnPropertyChanged = true;

    //    //    ViewModel.Name = prop;
    //    //    ViewModel.VerifyPropertyChange -= handler;

    //    //    AssertViewModel.AssertCallMethods(ViewModel, setPropertyValueCallNumber: 1, verificationCallNumber: 0);
    //    //    AssertViewModel.AssertCallHandlers(ViewModel, onVerifyPropertyChangeCallNumber: 0, onPropertyChangedCallNumber: 1);
    //    //    Assert.IsFalse(usedVerifyPropertyChange, "handler should not executed");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model] check method BindModel")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void BindModelTestCase()
    //    //{
    //    //    var result = new ModelTest();

    //    //    ViewModel.BindModel(result);

    //    //    AssertModel.NullAndType<ModelTest>(result);
    //    //    Assert.AreEqual(ViewModel.Options, result.Options, "options must match");
    //    //    AssertViewModel.AssertCallMethods(ViewModel, getModelCallNumber: 0, bindModelCallNumber: 1);
    //    //}
    //}
}
