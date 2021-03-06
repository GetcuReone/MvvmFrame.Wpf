﻿using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.Tests.UiServices.Env;
using MvvmFrame.Wpf.TestsCommon;
using System;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Tests.UiServices
{
    [TestClass]
    public sealed class UiServicesTests
    {
        private Frame _frame;
        private UiServicesViewModel ViewModel { get; set; }

        public void Initialize()
        {
            _frame = new Frame();

            ViewModel = ViewModelBase.CreateViewModel<UiServicesViewModel>(_frame)
                .CheckCreateObject(2);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Checking the transfer of services when use GetViewModel.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_GetViewModelTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                var result = ViewModel.GetViewModel<UiServicesViewModel>();

                Assert.AreEqual(ViewModel.UiServices, result.UiServices, "UiServices must be match");
            }, Timeouts.Second.Two);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddTransient.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_ContainsTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddTransient<UiService, UiService>(_frame);

                Assert.IsTrue(ViewModel.UiServices.Contains<UiService>(), "services must contains");
                Assert.AreEqual(_frame, ViewModel.UiServices.GetUiService<UiService>().GetFrame(), "frames must match");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddTransient tow services.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddTransientTowServicesTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddTransient<UiService, UiService>(_frame);
                var result1 = ViewModel.UiServices.GetUiService<UiService>();
                var result2 = ViewModel.UiServices.GetUiService<UiService>();

                Assert.IsNotNull(result1, "result1 cannot be null");
                Assert.IsNotNull(result2, "result2 cannot be null");
                Assert.AreNotEqual(result1, result2, "services must different");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddTransient. Add service already added previously.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddTransientNegativeTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddTransient<UiService, UiService>(_frame);

                TestHelper.ExpectedException<ArgumentException>(
                    () => ViewModel.UiServices.AddTransient<UiService, UiService>(_frame),
                    "Service already added previously.");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method GetUiService. Return service does not exist.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_GetUiServiceNegativeTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                TestHelper.ExpectedException<ArgumentException>(
                    () => ViewModel.UiServices.GetUiService<UiService>(),
                    "Service does not exist.");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddSingleton.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddSingletonTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddSingleton<UiService, UiService>(_frame);
                var result = ViewModel.UiServices.GetUiService<UiService>();

                Assert.IsNotNull(result, "result cannot be null");
                Assert.IsTrue(ViewModel.UiServices.Contains<UiService>(), "services must contains");
                Assert.AreEqual(_frame, result.GetFrame(), "frames must match");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddSingleton tow services.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddSingletonTowServicesTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddSingleton<UiService, UiService>(_frame);
                var result1 = ViewModel.UiServices.GetUiService<UiService>();
                var result2 = ViewModel.UiServices.GetUiService<UiService>();

                Assert.AreEqual(result1, result2, "services must match");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddSingleton. Add service already added previously.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddSingletonNegativeTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddSingleton<UiService, UiService>(_frame);

                TestHelper.ExpectedException<ArgumentException>(
                    () => ViewModel.UiServices.AddSingleton<UiService, UiService>(_frame),
                    "Service already added previously.");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddTransient. Add service already added previously with AddSingleton.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddSingletonAndAddTransientNegativeTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddSingleton<UiService, UiService>(_frame);

                TestHelper.ExpectedException<ArgumentException>(
                    () => ViewModel.UiServices.AddTransient<UiService, UiService>(_frame),
                    "Service already added previously.");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Check method AddSingleton. Add service already added previously with AddTransient.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_AddTransientAndAddSingletonNegativeTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                ViewModel.UiServices.AddTransient<UiService, UiService>(_frame);

                TestHelper.ExpectedException<ArgumentException>(
                    () => ViewModel.UiServices.AddSingleton<UiService, UiService>(_frame),
                    "Service already added previously.");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Remove service.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_RemoveServiceTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                var uiService = ViewModel.UiServices;
                uiService.AddTransient<UiService, UiService>(_frame);
                uiService.Remove<UiService>();

                Assert.IsFalse(ViewModel.UiServices.Contains<UiService>(), "Service exists.");
            }, Timeouts.Second.Two);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(GetcuReoneTC.Negative), TestCategory(TC.ViewModel), TestCategory(TC.UiService)]
        [Description("Remove non-added service.")]
        [Timeout(Timeouts.Second.Two)]
        public void UiServicesTests_RemoveNonAddedServiceTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialize();

                var uiService = ViewModel.UiServices;

                TestHelper.ExpectedException<ArgumentException>(
                    () => uiService.Remove<UiService>(),
                    $"Service {typeof(UiService).Name} does not exist.");

            }, Timeouts.Second.Two);
        }
    }
}
