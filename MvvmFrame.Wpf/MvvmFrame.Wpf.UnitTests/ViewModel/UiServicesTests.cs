using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.UnitTests.Common;
using MvvmFrame.Wpf.UnitTests.Common.Asserts;
using MvvmFrame.Wpf.UnitTests.Common.Entities;
using System;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.ViewModel
{
    //[TestClass]
    //public sealed class UiServicesTests: ViewModelTestBase
    //{
    //    //[TestMethod]
    //    //[Description("[view-model][service] Get view-model")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_GetViewModelTestCase()
    //    //{
    //    //    var result = ViewModel.GetViewModel<ViewModelTest>();

    //    //    AssertViewModel.AssertCallMethods(ViewModel, getViewModelCallNumber: 1);
    //    //    AssertCallCreateObject(1);
    //    //    AssertViewModel.NullAndType<ViewModelTest>(result);
    //    //    Assert.AreEqual(ViewModel.UiServices, result.UiServices, "UiServices must be match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model][service] Create view-model")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_CreateViewModelTestCase()
    //    //{
    //    //    var result1 = ViewModelBase.CreateViewModel<ViewModelTest>(new Frame());
    //    //    var result2 = result1.GetViewModel<ViewModelTest>();

    //    //    AssertViewModel.NullAndType<ViewModelTest>(result1);
    //    //    AssertViewModel.NullAndType<ViewModelTest>(result2);
    //    //    Assert.AreNotEqual(result1, result2, "should not be match");
    //    //    Assert.AreEqual(result1.UiServices, result2.UiServices, "UiServices must be match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model][service] check method AddTransient")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_ContainsTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame);

    //    //    Assert.IsTrue(ViewModel.UiServices.Contains<UiServiceTest>(), "services must contains");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model][service] check method AddTransient")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddTransientTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame);
    //    //    var result = ViewModel.UiServices.GetUiService<UiServiceTest>();

    //    //    AssertUiService.NullAndType<UiServiceTest>(result);
    //    //    Assert.AreEqual(frame, result.GetFrame(), "frames must match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model][service] check method AddTransient tow services")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddTransientTowServicesTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame);
    //    //    var result1 = ViewModel.UiServices.GetUiService<UiServiceTest>();
    //    //    var result2 = ViewModel.UiServices.GetUiService<UiServiceTest>();

    //    //    AssertUiService.NullAndType<UiServiceTest>(result1);
    //    //    AssertUiService.NullAndType<UiServiceTest>(result2);
    //    //    Assert.AreNotEqual(result1, result2, "services must different");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][view-model][service] check method AddTransient. Add service already added previously")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddTransientNegativeTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame);

    //    //    TestHelper.ExpectedException<ArgumentException>(
    //    //        () => ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame),
    //    //        "service already added previously");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][view-model][service] check method GetUiService. Return service does not exist")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_GetUiServiceNegativeTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    TestHelper.ExpectedException<ArgumentException>(
    //    //        () => ViewModel.UiServices.GetUiService<UiServiceTest>(),
    //    //        "service does not exist");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model][service] check method AddSingleton")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddSingletonTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddSingleton<UiServiceTest, UiServiceTest>(frame);
    //    //    var result = ViewModel.UiServices.GetUiService<UiServiceTest>();

    //    //    AssertUiService.NullAndType<UiServiceTest>(result);
    //    //    Assert.AreEqual(frame, result.GetFrame(), "frames must match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[view-model][service] check method AddSingleton tow services")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddSingletonTowServicesTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddSingleton<UiServiceTest, UiServiceTest>(frame);
    //    //    var result1 = ViewModel.UiServices.GetUiService<UiServiceTest>();
    //    //    var result2 = ViewModel.UiServices.GetUiService<UiServiceTest>();

    //    //    AssertUiService.NullAndType<UiServiceTest>(result1);
    //    //    AssertUiService.NullAndType<UiServiceTest>(result2);
    //    //    Assert.AreEqual(result1, result2, "services must match");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][view-model][service] check method AddSingleton. Add service already added previously")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddSingletonNegativeTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddSingleton<UiServiceTest, UiServiceTest>(frame);

    //    //    TestHelper.ExpectedException<ArgumentException>(
    //    //        () => ViewModel.UiServices.AddSingleton<UiServiceTest, UiServiceTest>(frame),
    //    //        "service already added previously");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][view-model][service] check method AddTransient. Add service already added previously with AddSingleton")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddSingletonAndAddTransientNegativeTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddSingleton<UiServiceTest, UiServiceTest>(frame);

    //    //    TestHelper.ExpectedException<ArgumentException>(
    //    //        () => ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame),
    //    //        "service already added previously");
    //    //}

    //    //[TestMethod]
    //    //[Description("[negative][view-model][service] check method AddSingleton. Add service already added previously with AddTransient")]
    //    //[Timeout(Timeuots.Second.Two)]
    //    //public void UiServicesTests_AddTransientAndAddSingletonNegativeTestCase()
    //    //{
    //    //    var frame = new Frame();

    //    //    ViewModel.UiServices.AddTransient<UiServiceTest, UiServiceTest>(frame);

    //    //    TestHelper.ExpectedException<ArgumentException>(
    //    //        () => ViewModel.UiServices.AddSingleton<UiServiceTest, UiServiceTest>(frame),
    //    //        "service already added previously");
    //    //}
    //}
}
