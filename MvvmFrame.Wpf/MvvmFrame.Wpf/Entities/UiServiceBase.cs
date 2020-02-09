using ComboPatterns.AFAP;
using GetcuReone.MvvmFrame.Wpf.Interfaces;
using System.Windows.Controls;

namespace GetcuReone.MvvmFrame.Wpf.Entities
{
    /// <summary>
    /// Base class for UI services
    /// </summary>
    public abstract class UiServiceBase: FactoryBase
    {
        /// <summary>
        /// <see cref="Frame"/> for service
        /// </summary>
        protected Frame Frame { get; private set; }
        /// <summary>
        /// service manager the service is associated with
        /// </summary>
        protected IConfigUiServices UiServices { get; private set; }

        internal void Setup(Frame frame, IConfigUiServices configUiServices)
        {
            Frame = frame;
            UiServices = configUiServices;
        }
    }
}
