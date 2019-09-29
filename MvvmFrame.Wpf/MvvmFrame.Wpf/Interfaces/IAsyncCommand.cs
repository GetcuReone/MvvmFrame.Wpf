using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmFrame.Wpf.Interfaces
{
    /// <summary>
    /// Interface async command
    /// </summary>
    public interface IAsyncCommand: ICommand
    {
        /// <summary>
        /// Async execute
        /// </summary>
        /// <returns></returns>
        ValueTask ExecuteAsync();
    }

    /// <summary>
    /// Interface async command
    /// </summary>
    /// <typeparam name="TParametr"></typeparam>
    public interface IAsyncCommand<TParametr>: ICommand
    {
        /// <summary>
        /// Async execute
        /// </summary>
        /// <param name="parametr"></param>
        /// <returns></returns>
        ValueTask ExecuteAsync(TParametr parametr);
    }
}
