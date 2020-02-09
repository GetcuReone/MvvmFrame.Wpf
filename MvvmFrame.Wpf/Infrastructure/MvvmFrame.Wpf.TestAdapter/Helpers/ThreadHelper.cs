using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    public static class ThreadHelper
    {
        /// <summary>
        /// Run an action in a STA thread
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="maxWaitTime"></param>
        public static void RunActinInSTAThread(Action threadStart, int maxWaitTime)
        {
            var thread = new Thread(() =>
            {
                threadStart();
            });

            thread.SetApartmentState(ApartmentState.STA);

            thread.Start();
            thread.Join(maxWaitTime);
        }
    }
}
