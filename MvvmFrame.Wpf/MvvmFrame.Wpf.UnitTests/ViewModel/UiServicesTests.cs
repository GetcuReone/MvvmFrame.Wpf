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
