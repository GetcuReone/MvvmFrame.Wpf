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

namespace MvvmFrame.Wpf.UnitTests.Model
{
    [TestClass]
    public sealed class ModelTests: ModelTestBase
    {
        [TestMethod]
        [Description("[model] Check call method OnVerifyPropertyChange")]
        [Timeout(Timeuots.Second.Two)]
        public void OnVerifyPropertyChangeTestCase()
        {
            Model.OnVerifyPropertyChange();

            AssertModel.AssertCallHandlers(Model, onVerifyPropertyChangeCallNumber: 1);
        }

        [TestMethod]
        [Description("[model] Check call method OnPropertyChanged")]
        [Timeout(Timeuots.Second.Two)]
        public void OnPropertyChangedTestCase()
        {
            Model.OnPropertyChanged();

            AssertModel.AssertCallHandlers(Model, onPropertyChangedCallNumber: 1);
        }

        [TestMethod]
        [Description("[model] Check method GetModel")]
        [Timeout(Timeuots.Second.Two)]
        public void GetModelTestCase()
        {
            var result = Model.GetModel<Entities.Model>();

            AssertModel.AssertCallMethods(Model, getMethodCallNumber: 1);
            AssertCallCreateObject(1);

            AssertModel.NullAndType<Entities.Model>(result);
        }

        [TestMethod]
        [Description("[model] Get model same type")]
        [Timeout(Timeuots.Second.Two)]
        public void GetModelSameTypeTestCase()
        {
            var result = Model.GetModel<ModelTest>();

            AssertModel.AssertCallMethods(Model, getMethodCallNumber: 1);
            AssertCallCreateObject(1);

            AssertModel.NullAndType<ModelTest>(result);
            Assert.AreNotEqual(Model, result, "models not must be match");
            Assert.AreEqual(Model.Options, result.Options, "options must be match");
            Assert.AreEqual(Model.UiServices, result.UiServices, "UiServices must be match");
        }

        [TestMethod]
        [Description("[model] set property value")]
        [Timeout(Timeuots.Second.Two)]
        public void SetPropertyValueTestCase()
        {
            string prop = "Stone";

            Model.Name = prop;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1);
            Assert.AreEqual(prop, Model.Name, $"Name must nave value is {prop}");
        }

        [TestMethod]
        [Description("[model] check call method verification when changing a property")]
        [Timeout(Timeuots.Second.Two)]
        public void CheckCallVerificationTestCase()
        {
            string prop = "Stone";

            Model.Name = prop;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1, verificationCallNumber: 1);
        }

        [TestMethod]
        [Description("[model] check call method PropertyChanged when changing a property")]
        [Timeout(Timeuots.Second.Two)]
        public void CheckCallOnPropertyChangedTestCase()
        {
            string prop = "Stone";
            bool usedPropertyChanged = false;
            PropertyChangedEventHandler handler = (sender, e) => usedPropertyChanged = true;
            Model.PropertyChanged += handler;

            Model.Name = prop;

            Model.PropertyChanged -= handler;
            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1);
            AssertModel.AssertCallHandlers(Model, onPropertyChangedCallNumber: 1);
            Assert.IsTrue(usedPropertyChanged, "handler must executed");
        }

        [TestMethod]
        [Description("[model] check call method OnVerifyPropertyChange when changing a property")]
        [Timeout(Timeuots.Second.Two)]
        public void CheckCallOnVerifyPropertyChangeTestCase()
        {
            string prop = "Stone";
            bool usedVerifyPropertyChange = false;
            MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
            Model.VerifyPropertyChange += handler;

            Model.Name = prop;

            Model.VerifyPropertyChange -= handler;
            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1);
            AssertModel.AssertCallHandlers(Model, onVerifyPropertyChangeCallNumber: 1);
            Assert.IsTrue(usedVerifyPropertyChange, "handler must executed");
        }

        [TestMethod]
        [Description("[model] set property invalid value for verificatio method")]
        [Timeout(Timeuots.Second.Two)]
        public void SetPropertyValueVerificationInvalidTestCase()
        {
            Model.Name = ViewModelTest.VerificationInvalid;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1, verificationCallNumber:1);
            AssertModel.AssertCallHandlers(Model, onErrorsCallNumber: 1);
            Assert.IsNull(Model.Name, "property not have value is null");
        }

        [TestMethod]
        [Description("[model] set property invalid value for event")]
        [Timeout(Timeuots.Second.Two)]
        public void SetPropertyValueInvalidTestCase()
        {
            string prop = "Stone";
            Func<string> func = () => string.Empty;
            MvvmElementPropertyVerifyChangeEventArgs args = null;
            MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) =>
            {
                e.AddError(func);
                args = e;
            };
            Model.VerifyPropertyChange += handler;

            Model.Name = prop;
            Model.VerifyPropertyChange -= handler;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1);
            AssertModel.AssertCallHandlers(Model, onErrorsCallNumber: 1, onVerifyPropertyChangeCallNumber: 1);
            Assert.IsNotNull(args, "arguments event should be null");
            Assert.IsFalse(args.IsValid, "event should invalid");
            Assert.IsTrue(args._errorFuncs.Count == 1, "must one message");
            Assert.AreEqual(func, args._errorFuncs.Single(), "messages must match");
        }

        [TestMethod]
        [Description("[model] set property without VerifyPropertyChange")]
        [Timeout(Timeuots.Second.Two)]
        public void SetPropertyValueUseVerifyPropertyChangeTestCase()
        {
            string prop = "Stone";
            bool usedVerifyPropertyChange = false;
            MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
            Model.VerifyPropertyChange += handler;
            ((ModelOptions)Model.Options).UseVerifyPropertyChange = false;

            Model.Name = prop;
            Model.VerifyPropertyChange -= handler;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1, verificationCallNumber:1);
            AssertModel.AssertCallHandlers(Model, onVerifyPropertyChangeCallNumber: 0);
            Assert.IsFalse(usedVerifyPropertyChange, "handler should not executed");
        }

        [TestMethod]
        [Description("[model] set property without Verification")]
        [Timeout(Timeuots.Second.Two)]
        public void SetPropertyValueUseVerificationTestCase()
        {
            string prop = "Stone";
            bool usedVerifyPropertyChange = false;
            MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
            Model.VerifyPropertyChange += handler;
            ((ModelOptions)Model.Options).UseVerification = false;

            Model.Name = prop;
            Model.VerifyPropertyChange -= handler;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1, verificationCallNumber: 0);
            AssertModel.AssertCallHandlers(Model, onVerifyPropertyChangeCallNumber: 1);
            Assert.IsTrue(usedVerifyPropertyChange, "handler must executed");
        }

        [TestMethod]
        [Description("[model] set property use only OnPropertyChanged")]
        [Timeout(Timeuots.Second.Two)]
        public void SetPropertyValueUseOnlyOnPropertyChangedTestCase()
        {
            string prop = "Stone";
            bool usedVerifyPropertyChange = false;
            MvvmElementPropertyVerifyChangeEventHandler handler = (sender, e) => usedVerifyPropertyChange = true;
            Model.VerifyPropertyChange += handler;
            ((ModelOptions)Model.Options).UseOnlyOnPropertyChanged = true;

            Model.Name = prop;
            Model.VerifyPropertyChange -= handler;

            AssertModel.AssertCallMethods(Model, setPropertyValueCallNumber: 1, verificationCallNumber: 0);
            AssertModel.AssertCallHandlers(Model, onVerifyPropertyChangeCallNumber: 0, onPropertyChangedCallNumber:1);
            Assert.IsFalse(usedVerifyPropertyChange, "handler should not executed");
        }

        [TestMethod]
        [Description("[model] check method BindModel")]
        [Timeout(Timeuots.Second.Two)]
        public void BindModelTestCase()
        {
            var result = new ModelTest();

            Model.BindModel(result);
            result.GetModel<Entities.Model>();

            AssertModel.NullAndType<ModelTest>(result);
            Assert.AreNotEqual(Model, result, "models should not be different");
            Assert.AreEqual(Model.Options, result.Options, "options must match");
            AssertModel.AssertCallMethods(Model, getMethodCallNumber: 0, bindModelCallNumber: 1);
            AssertModel.AssertCallMethods(result, getMethodCallNumber: 1, bindModelCallNumber: 0);
            AssertCallCreateObject(1);
        }

        [TestMethod]
        [Description("[model] check method GetFacade")]
        [Timeout(Timeuots.Second.Two)]
        public void GetFacadeTestCase()
        {
            var result = Model.GetFacade2<Entities.Facade>();

            AssertCallCreateObject(1);
            AssertModel.AssertCallMethods(Model, getFacadeCallNumber: 1);
            Assert.IsNotNull(result, "facade should not be null");
            Assert.IsTrue(result is Entities.Facade, "must type Facade");
        }

        [TestMethod]
        [Description("[negative][model] check method GetFacade")]
        [Timeout(Timeuots.Second.Two)]
        public void GetFacadeNegativeTestCase()
        {
            string errorMessage = $"the model should be tied to factory type {nameof(ViewModelBase)}";
            var exception = TestHelper.ExpectedException<ArgumentException>(() => new ModelTest().GetFacade2<Entities.Facade>());

            Assert.AreEqual(errorMessage, exception.Message);
        }
    }
}
