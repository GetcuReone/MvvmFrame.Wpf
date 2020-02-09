using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetcuReone.MvvmFrame.Wpf.UnitTests.Common;
using GetcuReone.MvvmFrame.Wpf.UnitTests.CreateObject.Environment;
using System;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.CreateObject
{
    [TestClass]
    public class CreateObjectTests
    {
        private readonly Frame _frame = new Frame();

        #region CreateViewModel

        [TestMethod]
        [Timeout(Timeuots.Second.One)]
        [Description("[view-model] create view-model")]
        public void ViewModel_CreateViewModelTestCase()
        {
            var viewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);

            viewModel.NotNull()
                .CheckCreateObject(2);
        }

        [TestMethod]
        [Description("[negative][view-model] create view-model view-model without frame")]
        [Timeout(Timeuots.Second.Two)]
        public void ViewModel_CreateViewModelWithoutFrameTestCase()
        {
            var expectedException = new ArgumentNullException("frame", "frame should not be null");

            var result = TestHelper.ExpectedException<ArgumentNullException>(() => ViewModelBase.CreateViewModel<CreateObjectViewModel>(null));

            Assert.AreEqual(expectedException.Message, result.Message, "Messages error must match");
        }

        #endregion

        #region GetViewModel

        [TestMethod]
        [Timeout(Timeuots.Second.One)]
        [Description("[view-model] get view-model")]
        public void ViewModel_GetViewModelTestCase()
        {
            var firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);
            var secondViewModel = firstViewModel.GetViewModel<TestViewModel>();

            firstViewModel.NotNull()
                .CheckCreateObject(3);

            Assert.IsNotNull(secondViewModel, "second view-model can not be null");
            TestHelper.CheckBindViewModel(firstViewModel, secondViewModel);
        }

        [TestMethod]
        [Timeout(Timeuots.Second.One)]
        [Description("[view-model] get view-model some type")]
        public void ViewModel_GetViewModelSomeTypeTestCase()
        {
            var firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);
            var secondViewModel = firstViewModel.GetViewModel<CreateObjectViewModel>();

            firstViewModel.NotNull()
                .CheckCreateObject(3);

            secondViewModel.NotNull()
                .CheckCreateObject(0);

            Assert.AreNotEqual(firstViewModel, secondViewModel, "must be different objects");
            TestHelper.CheckBindViewModel(firstViewModel, secondViewModel);
        }

        #endregion

        #region GetModel

        [TestMethod]
        [Timeout(Timeuots.Second.One)]
        [Description("[view-model] get model")]
        public void ViewModel_GetModelTestCase()
        {
            var firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);
            var model = firstViewModel.GetModel<CreateObjectModel>();

            firstViewModel.NotNull()
                .CheckCreateObject(3);

            Assert.IsNotNull(model, "model can not be null");
        }

        [TestMethod]
        [Timeout(Timeuots.Second.One)]
        [Description("[model] get model")]
        public void Model_GetModelTestCase()
        {
            var firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);
            var firstModel = firstViewModel.GetModel<CreateObjectModel>();
            var secondModel = firstModel.GetModel<TestModel>();


            firstViewModel.NotNull()
                .CheckCreateObject(4);

            Assert.IsNotNull(firstModel, "first model can not be null");
            Assert.IsNotNull(secondModel, "first model can not be null");
            Assert.AreEqual(1, firstModel.GetModelCallCounter, $"method '{nameof(ModelBase.GetModel)}' should be called 1 times");
        }

        [TestMethod]
        [Timeout(Timeuots.Second.One)]
        [Description("[model] get model some type")]
        public void Model_GetModelSameTypeTestCase()
        {
            var firstViewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);
            var firstModel = firstViewModel.GetModel<CreateObjectModel>();
            var secondModel = firstModel.GetModel<CreateObjectModel>();


            firstViewModel.NotNull()
                .CheckCreateObject(4);

            Assert.AreNotEqual(firstModel, secondModel, "must be different objects");
        }

        #endregion

        #region BindModel

        [TestMethod]
        [Description("[view-model] check method BindModel")]
        [Timeout(Timeuots.Second.Two)]
        public void ViewModel_BindModelTestCase()
        {
            var viewModel = ViewModelBase.CreateViewModel<CreateObjectViewModel>(_frame);
            var result = new CreateObjectModel();

            viewModel.BindModel(result);

            viewModel.NotNull()
                .CheckCreateObject(2);
            Assert.AreEqual(viewModel.ModelOptions, result.ModelOptions, "options must match");
        }

        #endregion
    }
}
