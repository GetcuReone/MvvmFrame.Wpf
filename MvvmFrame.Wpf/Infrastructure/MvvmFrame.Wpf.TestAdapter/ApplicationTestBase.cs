using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace MvvmFrame.Wpf.TestAdapter
{
    [TestClass]
    public abstract class ApplicationTestBase<TApplication>
        where TApplication : Application , new()
    {
        protected TApplication Application { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            Application = new TApplication();
        }
    }
}
