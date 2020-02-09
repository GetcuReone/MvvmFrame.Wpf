using GetcuReone.MvvmFrame.Interfaces;
using System;
using System.Threading.Tasks;

namespace GetcuReone.MvvmFrame.Wpf.Helpers
{
    /// <summary>
    /// Task helper
    /// </summary>
    public static class TaskHelper
    {
        /// <summary>
        /// Run async task
        /// </summary>
        /// <param name="valueTask"></param>
        /// <param name="handler"></param>
        public static async void FireAndForgetSafeAsync(this ValueTask valueTask, IErrorHandler handler = null)
        {
            try
            {
                await valueTask;
            }
            catch(Exception ex)
            {
                handler?.ErrorHandle(ex);
            }
        }
    }
}
