using System.Windows.Controls;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.Tests.BindModel.Env;
using MvvmFrame.Wpf.TestsCommon;

namespace MvvmFrame.Wpf.Tests.BindModel
{
    [TestClass]
    public class BindModelTests
    {
        public BindModelViewModel ViewModel { get; set; }

        public void Initialaze()
        {
            ViewModel = ViewModelBase.CreateViewModel<BindModelViewModel>(new Frame());
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.ViewModel)]
        [Description("Check method bind model for view-model.")]
        [Timeout(Timeouts.Second.One)]
        public void ViewModel_BindModelTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialaze();

                var model = new BindModelModel();

                ViewModel.BindModel(model);

                Assert.AreEqual(ViewModel, model.GetFactory(), "view-model must be a model factory");
                Assert.AreEqual(ViewModel.ModelOptions, model.ModelOptions, "model options must be mutch");
                Assert.AreEqual(ViewModel.UiServices, model.UiServices, "UiServices must be mutch");
            }, Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit), TestCategory(TC.Model)]
        [Description("Check method bind model for model.")]
        [Timeout(Timeouts.Second.One)]
        public void Model_BindModelTestCase()
        {
            ThreadHelper.RunActinInSTAThread(() =>
            {
                Initialaze();

                var firstModel = ViewModel.GetModel<BindModelModel>();
                var secondModel = new BindModelModel();

                firstModel.BindModel(secondModel);

                Assert.AreEqual(ViewModel, secondModel.GetFactory(), "view-model must be a model factory");
                Assert.AreEqual(ViewModel.ModelOptions, secondModel.ModelOptions, "model options must be mutch");
                Assert.AreEqual(ViewModel.UiServices, secondModel.UiServices, "UiServices must be mutch");
            }, Timeouts.Second.One);
        }
    }
}
