using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows;

namespace MvvmFrame.Wpf.TestAdapter
{
    [TestClass]
    public abstract class ApplicationTestBase<TApplication>
        where TApplication : Application , new()
    {
        protected void RunActionInApp(Action<TApplication> actionTest)
        {
            var app = new TApplication();

            StartupEventHandler handler = (sender, e) => 
            {
                Thread t = new Thread(() => actionTest(app));
                t.SetApartmentState(ApartmentState.STA);

                t.Start();
                app.Shutdown();
            };

            app.Startup += handler;
            app.Run();
            app.Startup -= handler;
        }
    }
}
