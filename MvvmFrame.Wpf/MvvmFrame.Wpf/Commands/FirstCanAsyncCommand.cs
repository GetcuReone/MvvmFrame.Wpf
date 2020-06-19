using GetcuReone.MvvmFrame.Interfaces;
using System;
using System.Threading.Tasks;

namespace GetcuReone.MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// On first access, the command will allow execution.
    /// </summary>
    public class FirstCanAsyncCommand: AsyncCommand
    {
        private bool _isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <param name="errorHandler"></param>
        public FirstCanAsyncCommand(Func<AsyncCommandArgs, ValueTask> execute, Func<bool> canExecute = null, IErrorHandler errorHandler = null) 
            : base(execute, canExecute, errorHandler)
        {
        }

        /// <inheritdoc/>
        public override bool CanExecute(object parameter)
        {
            if (_isFirst)
            {
                _isFirst = false;
                return true;
            }
            return base.CanExecute(parameter);
        }
    }

    /// <summary>
    /// on first access, the command will allow execution
    /// </summary>
    public class FirstCanAsyncCommand<TParametr> : AsyncCommand<TParametr>
    {
        private bool _isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <param name="errorHandler"></param>
        public FirstCanAsyncCommand(Func<AsyncCommandArgs<TParametr>, ValueTask> execute, Func<TParametr, bool> canExecute = null, IErrorHandler errorHandler = null)
            : base(execute, canExecute, errorHandler)
        {
        }

        /// <inheritdoc/>
        public override bool CanExecute(object parameter)
        {
            if (_isFirst)
            {
                _isFirst = false;
                return true;
            }
            return base.CanExecute(parameter);
        }
    }
}
