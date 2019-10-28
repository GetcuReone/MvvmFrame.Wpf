using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.AFAP.UnitTests.GetFacade.Env;
using MvvmFrame.Wpf.UnitTests.Common;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.AFAP.UnitTests.GetFacade
{
    [TestClass]
    public class GetFacadeTests
    {
        private readonly Frame _frame = new Frame();
        private GetFacadeViewModel ViewModel { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ViewModel = Wpf.ViewModelBase.CreateViewModel<GetFacadeViewModel>(_frame)
                .CheckCreateObject(2);
        }

        [TestMethod]
        [Description("[view-model] check method 'GetFacade' for view-model")]
        [Timeout(Timeuots.Second.One)]
        public void ViewModel_GetFacadeTestCase()
        {
            var facade = ViewModel.GetFacade<Facade>();

            ViewModel.CheckCreateObject(3);
            TestHelper.AssertCounter(1, ViewModel.GetFacadeCallCounter, nameof(GetFacadeViewModel.GetFacade));
            Assert.IsNotNull(facade, "facade cannot be null");
        }

        [TestMethod]
        [Description("[model] check method 'GetFacade' for model")]
        [Timeout(Timeuots.Second.One)]
        public void Model_GetFacadeTestCase()
        {
            var model = ViewModel.GetModel<GetFacadeModel>();
            var facade = model.GetFacade<Facade>();

            ViewModel.CheckCreateObject(4);
            TestHelper.AssertCounter(0, ViewModel.GetFacadeCallCounter, nameof(GetFacadeViewModel.GetFacade));
            TestHelper.AssertCounter(1, model.GetFacadeCallCounter, nameof(GetFacadeModel.GetFacade));
            Assert.IsNotNull(facade, "facade cannot be null");
        }

        [TestMethod]
        [Description("check re calling 'GetFacade' for model")]
        [Timeout(Timeuots.Second.One)]
        public void ReGetFacadeTestCase()
        {
            var firstFacade = ViewModel.GetFacade<Facade>();
            var secondFacade = firstFacade.GetFacade<Facade>();

            ViewModel.CheckCreateObject(4);
            Assert.IsNotNull(firstFacade, "firstFacade cannot be null");
            Assert.IsNotNull(secondFacade, "secondFacade cannot be null");
            Assert.AreNotEqual(firstFacade, secondFacade, "adapters must different");
        }
    }
}
