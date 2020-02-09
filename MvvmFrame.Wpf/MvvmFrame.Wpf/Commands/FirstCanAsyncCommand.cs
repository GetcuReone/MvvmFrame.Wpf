using GetcuReone.MvvmFrame.Interfaces;
using System;
using System.Threading.Tasks;

namespace GetcuReone.MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// on first access, the command will allow execution
    /// </summary>
    public class FirstCanAsyncCommand: AsyncCommand
    {
        private bool isFirst = true;

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

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            if (isFirst)
            {
                isFirst = false;
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
        private bool isFirst = true;

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

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            if (isFirst)
            {
                isFirst = false;
                return true;
            }
            return base.CanExecute(parameter);
        }
    }
}
