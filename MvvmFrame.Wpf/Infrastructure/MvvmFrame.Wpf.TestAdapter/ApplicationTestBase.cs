using JwtTestAdapter;
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
                actionTest(app);
                app.Shutdown();
            };

            app.Startup += handler;
            app.Run();
            app.Startup -= handler;
        }

        protected void RunActinInSTAThread(Action threadStart)
        {
            bool finished = false;

            var thread = new Thread(() => 
            {
                threadStart();
                finished = true;
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            while (!finished)
                Thread.Sleep(Timeouts.MilliSecond.Hundred);
        }
    }
}
