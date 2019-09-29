using MvvmFrame.Interfaces;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.Helpers
{
    public static class TaskHelper
    {
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
