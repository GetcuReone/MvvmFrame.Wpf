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
    //[TestClass]
    //public sealed class ModelTests: ModelTestBase
    //{
    //    //[TestMethod]
    //    //[Description("[model] check method GetFacade")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void GetFacadeTestCase()
    //    //{
    //    //    var result = Model.GetFacade2<Entities.Facade>();

    //    //    AssertCallCreateObject(1);
    //    //    AssertModel.AssertCallMethods(Model, getFacadeCallNumber: 1);
    //    //    Assert.IsNotNull(result, "facade should not be null");
    //    //    Assert.IsTrue(result is Entities.Facade, "must type Facade");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][model] check method GetFacade")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void GetFacadeNegativeTestCase()
    //    //{
    //    //    string errorMessage = $"the model should be tied to factory type {nameof(ViewModelBase)}";
    //    //    var exception = TestHelper.ExpectedException<ArgumentException>(() => new ModelTest().GetFacade2<Entities.Facade>());

    //    //    Assert.AreEqual(errorMessage, exception.Message);
    //    //}
    //}
}
