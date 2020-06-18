using GetcuReone.MvvmFrame.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter;
using MvvmFrame.Wpf.Tests.CreateObject.Env;
using MvvmFrame.Wpf.TestsCommon;
using System;

namespace MvvmFrame.Wpf.Tests.CreateObject
{
    [TestClass]
    public class CreateObjectTests : FrameTestBase
    {
        #region CreateViewModel

        [TestMethod]
        [Timeout(Timeouts.Second.Five)]
        [Description("[view-model] create view-model")]
        public void ViewModel_CreateViewModelTestCase()
        {
            GivenEmpty()
                .When("Create view-model", frame => ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .Then("Checking view-model", viewModel => viewModel.NotNull().CheckCreateObject(2))
                .RunWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [Description("[negative][view-model] create view-model view-model without frame")]
        [Timeout(Timeouts.Second.Two)]
        public void ViewModel_CreateViewModelWithoutFrameTestCase()
        {
            var expectedException = new ArgumentNullException("frame", "frame should not be null");

            var result = TestHelper.ExpectedException<ArgumentNullException>(() => ViewModelBase.CreateViewModel<CreateObjectViewModel>(null));

            Assert.AreEqual(expectedException.Message, result.Message, "Messages error must match");
        }

        #endregion

        #region GetViewModel

        [TestMethod]
        [Timeout(Timeouts.Second.Five)]
        [Description("[view-model] get view-model")]
        public void ViewModel_GetViewModelTestCase()
        {
            CreateObjectViewModel firstViewModel = null;

            Given("Create view-model", frame => ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .And("Cheking first view-model", viewModel => firstViewModel = viewModel.NotNull().CheckCreateObject(2))
                .When("Get seccond view-model", _ => firstViewModel.GetViewModel<TestViewModel>())
                .Then("Cheking view-models", secondViewModel =>
                {
                    firstViewModel.CheckCreateObject(3);
                    Assert.IsNotNull(secondViewModel, "second view-model can not be null");
                    TestHelper.CheckBindViewModel(firstViewModel, secondViewModel);
                })
                .RunWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [Timeout(Timeouts.Second.Five)]
        [Description("[view-model] get view-model some type")]
        public void ViewModel_GetViewModelSomeTypeTestCase()
        {
            CreateObjectViewModel firstViewModel = null;

            Given("Create view-model", frame => firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .When("Get seccond view-model", _ => firstViewModel.GetViewModel<CreateObjectViewModel>())
                .Then("Cheking view-models", secondViewModel =>
                {
                    firstViewModel.NotNull()
                        .CheckCreateObject(3);

                    secondViewModel.NotNull()
                        .CheckCreateObject(0);

                    Assert.AreNotEqual(firstViewModel, secondViewModel, "must be different objects");
                    TestHelper.CheckBindViewModel(firstViewModel, secondViewModel);
                })
                .RunWindow(Timeouts.Second.Five);
        }

        #endregion

        #region GetModel

        [TestMethod]
        [Timeout(Timeouts.Second.Five)]
        [Description("[view-model] get model")]
        public void ViewModel_GetModelTestCase()
        {
            CreateObjectViewModel firstViewModel = null;

            Given("Create view-model", frame => firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .When("Get model", _ => firstViewModel.GetModel<CreateObjectModel>())
                .Then("Cheking view-models", model =>
                {
                    firstViewModel.NotNull()
                        .CheckCreateObject(3);

                    Assert.IsNotNull(model, "model can not be null");
                })
                .RunWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [Timeout(Timeouts.Second.Five)]
        [Description("[model] get model")]
        public void Model_GetModelTestCase()
        {
            CreateObjectViewModel firstViewModel = null;
            CreateObjectModel firstModel = null;
            TestModel secondModel = null;

            Given("Create view-model", frame => firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .When("Get models", _ =>
                {
                    firstModel = firstViewModel.GetModel<CreateObjectModel>();
                    secondModel = firstModel.GetModel<TestModel>();
                })
                .Then("Cheking models", _ =>
                {
                    firstViewModel.NotNull().CheckCreateObject(4);

                    Assert.IsNotNull(firstModel, "first model can not be null");
                    Assert.IsNotNull(secondModel, "first model can not be null");
                    Assert.AreEqual(1, firstModel.GetModelCallCounter, $"method '{nameof(ModelBase.GetModel)}' should be called 1 times");
                })
                .RunWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [Timeout(Timeouts.Second.Five)]
        [Description("[model] get model some type")]
        public void Model_GetModelSameTypeTestCase()
        {
            CreateObjectViewModel firstViewModel = null;
            CreateObjectModel firstModel = null;
            CreateObjectModel secondModel = null;

            Given("Create view-model", frame => firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .When("Get models", _ =>
                {
                    firstModel = firstViewModel.GetModel<CreateObjectModel>();
                    secondModel = firstModel.GetModel<CreateObjectModel>();
                })
                .Then("Cheking models", _ =>
                {
                    firstViewModel.NotNull().CheckCreateObject(4);

                    Assert.AreNotEqual(firstModel, secondModel, "must be different objects");
                })
                .RunWindow(Timeouts.Second.Five);
        }

        #endregion

        #region BindModel

        [TestMethod]
        [Description("[view-model] check method BindModel")]
        [Timeout(Timeouts.Second.Five)]
        public void ViewModel_BindModelTestCase()
        {
            CreateObjectViewModel viewModel = null;
            CreateObjectModel result = new CreateObjectModel();

            Given("Create view-model", frame => viewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(frame))
                .When("Bind model", _ =>
                {
                    viewModel.BindModel(result);
                })
                .Then("Cheking models", _ =>
                {
                    viewModel.NotNull().CheckCreateObject(2);
                    Assert.AreEqual(viewModel.ModelOptions, result.ModelOptions, "options must match");
                })
                .RunWindow(Timeouts.Second.Five);
        }

        #endregion
    }
}
