using System;
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
            Exception exception = null;
            var thread = new Thread(() => 
            {
                try
                {
                    threadStart();
                }
                catch(Exception ex)
                {
                    exception = ex;
                }
            });

            thread.SetApartmentState(ApartmentState.STA);

            thread.Start();
            thread.Join(maxWaitTime);

            switch (thread.ThreadState)
            {
                case ThreadState.Running:
                    thread.Abort();
                    break;
            }

            if (exception != null)
                throw exception;
        }
    }
}
