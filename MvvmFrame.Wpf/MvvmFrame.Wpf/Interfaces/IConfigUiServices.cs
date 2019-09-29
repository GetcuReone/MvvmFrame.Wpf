using MvvmFrame.Wpf.Entities;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Interfaces
{
    /// <summary>
    /// UI services manager
    /// </summary>
    public interface IConfigUiServices
    {
        /// <summary>
        /// Get UI service
        /// </summary>
        /// <typeparam name="TUiService"></typeparam>
        /// <returns></returns>
        TUiService GetUiService<TUiService>();

        /// <summary>
        /// Is the service contains
        /// </summary>
        /// <typeparam name="TUiService"></typeparam>
        /// <returns></returns>
        bool Contains<TUiService>();

        /// <summary>
        /// Add a service that will be created every time you request
        /// </summary>
        /// <typeparam name="TUiService">interfaces services</typeparam>
        /// <typeparam name="TUiServiceImplementation">implement services/typeparam>
        /// <param name="frame"></param>
        void AddTransient<TUiService, TUiServiceImplementation>(Frame frame) where TUiServiceImplementation : UiServiceBase, TUiService, new();

        /// <summary>
        /// Add a service that will be created one time you request
        /// </summary>
        /// <typeparam name="TUiService">interfaces services</typeparam>
        /// <typeparam name="TUiServiceImplementation">implement services</typeparam>
        /// <param name="frame"></param>
        void AddSingleton<TUiService, TUiServiceImplementation>(Frame frame) where TUiServiceImplementation : UiServiceBase, TUiService, new();
    }
}
