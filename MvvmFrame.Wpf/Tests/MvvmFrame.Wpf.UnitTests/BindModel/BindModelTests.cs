using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetcuReone.MvvmFrame.Wpf.UnitTests.BindModel.Env;
using GetcuReone.MvvmFrame.Wpf.UnitTests.Common;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.BindModel
{
    [TestClass]
    public class BindModelTests
    {
        public BindModelViewModel ViewModel { get; set; }

        [TestInitialize]
        public void Initialaze()
        {
            ViewModel = ViewModelBase.CreateViewModel<BindModelViewModel>(new Frame());
        }

        [TestMethod]
        [Description("[view-model] Check method bind model for view-model")]
        [Timeout(Timeuots.Second.One)]
        public void ViewModel_BindModelTestCase()
        {
            var model = new BindModelModel();

            ViewModel.BindModel(model);

            Assert.AreEqual(ViewModel, model.GetFactory(), "view-model must be a model factory");
            Assert.AreEqual(ViewModel.ModelOptions, model.ModelOptions, "model options must be mutch");
            Assert.AreEqual(ViewModel.UiServices, model.UiServices, "UiServices must be mutch");
        }

        [TestMethod]
        [Description("[model] Check method bind model for model")]
        [Timeout(Timeuots.Second.One)]
        public void Model_BindModelTestCase()
        {
            var firstModel = ViewModel.GetModel<BindModelModel>();
            var secondModel = new BindModelModel();

            firstModel.BindModel(secondModel);

            Assert.AreEqual(ViewModel, secondModel.GetFactory(), "view-model must be a model factory");
            Assert.AreEqual(ViewModel.ModelOptions, secondModel.ModelOptions, "model options must be mutch");
            Assert.AreEqual(ViewModel.UiServices, secondModel.UiServices, "UiServices must be mutch");
        }
    }
}
