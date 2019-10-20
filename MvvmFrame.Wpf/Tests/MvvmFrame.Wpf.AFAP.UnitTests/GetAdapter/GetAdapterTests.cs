using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.AFAP.UnitTests.GetAdapter.Env;
using MvvmFrame.Wpf.AFAP.UnitTests.GetFacade.Env;
using MvvmFrame.Wpf.UnitTests.Common;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.AFAP.UnitTests.GetAdapter
{
    [TestClass]
    public class GetAdapterTests
    {
        private readonly Frame _frame = new Frame();
        private GetAdapterViewModel ViewModel { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ViewModel = Wpf.ViewModelBase.CreateViewModel<GetAdapterViewModel>(_frame)
                .CheckCreateObject(2);
        }

        [TestMethod]
        [Description("[view-model] check method 'GetAdapter' for view-model")]
        [Timeout(Timeuots.Second.One)]
        public void ViewModel_GetAdapterTestCase()
        {
            var adapter = ViewModel.GetAdapter<Adapter>();

            ViewModel.CheckCreateObject(3);
            TestHelper.AssertCounter(1, ViewModel.GetAdapterCallCounter, nameof(GetFacadeViewModel.GetAdapter));
            Assert.IsNotNull(adapter, "facade cannot be null");
        }

        [TestMethod]
        [Description("[model] check method 'GetAdapter' for model")]
        [Timeout(Timeuots.Second.One)]
        public void Model_GetFacadeTestCase()
        {
            var model = ViewModel.GetModel<GetAdapterModel>();
            var adapter = model.GetAdapter<Adapter>();

            ViewModel.CheckCreateObject(4);
            TestHelper.AssertCounter(0, ViewModel.GetAdapterCallCounter, nameof(GetFacadeViewModel.GetAdapter));
            TestHelper.AssertCounter(1, model.GetAdapterCallCounter, nameof(GetFacadeModel.GetAdapter));
            Assert.IsNotNull(adapter, "facade cannot be null");
        }
    }
}
