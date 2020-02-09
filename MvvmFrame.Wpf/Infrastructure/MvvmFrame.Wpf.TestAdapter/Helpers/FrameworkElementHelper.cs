using System.Threading.Tasks;
using System.Windows;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// FrameworkElement helper
    /// </summary>
    public static class FrameworkElementHelper
    {
        /// <summary>
        /// Asynchronously waiting for an item to load
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static async ValueTask WaitLoadAsync(this FrameworkElement element)
        {
            if (element.IsLoaded)
                return;

            while (!element.IsLoaded)
                await Task.Delay(100);
        }
    }
}
