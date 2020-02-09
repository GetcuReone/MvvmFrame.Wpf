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
            bool finished = false;

            var thread = new Thread(() =>
            {
                threadStart();
                finished = true;
            });

            thread.SetApartmentState(ApartmentState.STA);

            var stopwatch = new Stopwatch();
            maxWaitTime += 100;
            stopwatch.Start();
            thread.Start();

            while (true)
            {
                if (finished)
                    break;
                else if (maxWaitTime <= stopwatch.ElapsedMilliseconds)
                {
                    stopwatch.Stop();
                    Assert.Fail("Thread timed out");
                    break;
                }
                Thread.Sleep(100);
            }

            thread.Abort();
        }
    }
}
