using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.Helpers;
using MvvmFrame.Wpf.Interfaces;
using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// Async Command
    /// </summary>
    /// <remarks>
    /// Thanks https://johnthiriet.com/mvvm-going-async-with-async-command/#
    /// </remarks>
    public class AsyncCommand : IAsyncCommand
    {
        private readonly Func<AsyncCommandArgs, ValueTask> execute;
        private readonly Func<bool> canExecute;
        private readonly IErrorHandler errorHandler;
        private AsyncCommandArgs currentArgs;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <param name="errorHandler"></param>
        public AsyncCommand(Func<AsyncCommandArgs, ValueTask> execute, Func<bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute), "Action execute not should be null");
            this.canExecute = canExecute;
            this.errorHandler = errorHandler;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter) => canExecute?.Invoke() ?? true;

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            ExecuteAsync().FireAndForgetSafeAsync(errorHandler);
        }

        /// <summary>
        /// Async execute
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask ExecuteAsync()
        {
            if (CanExecute(null))
            {
                try
                {
                    currentArgs = new AsyncCommandArgs();
                    await execute(currentArgs);
                    if (currentArgs.IsCancel)
                        await currentArgs.Compensate();
                    else
                        currentArgs.FinishOperations();
                }
                finally
                {
                }
            }

            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// A raise can execute a modified
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
    }

    /// <summary>
    /// Async Command
    /// </summary>
    /// <typeparam name="TParametr"></typeparam>
    public class AsyncCommand<TParametr>: IAsyncCommand<TParametr>
    {
        private readonly Func<AsyncCommandArgs<TParametr>, ValueTask> execute;
        private readonly Func<TParametr, bool> canExecute;
        private readonly IErrorHandler errorHandler;
        private AsyncCommandArgs<TParametr> currentArgs;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <param name="errorHandler"></param>
        public AsyncCommand(Func<AsyncCommandArgs<TParametr>, ValueTask> execute, Func<TParametr, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute), "Action execute not should be null");
            this.canExecute = canExecute;
            this.errorHandler = errorHandler;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter) => canExecute?.Invoke((TParametr)parameter) ?? true;

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            ExecuteAsync((TParametr)parameter).FireAndForgetSafeAsync(errorHandler);
        }

        /// <summary>
        /// Async execute
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask ExecuteAsync(TParametr parametr)
        {
            if (CanExecute(null))
            {
                try
                {
                    currentArgs = new AsyncCommandArgs<TParametr>(parametr);
                    await execute(currentArgs);
                    if (currentArgs.IsCancel)
                        await currentArgs.Compensate();
                    else
                        currentArgs.FinishOperations();
                }
                finally
                {
                }
            }

            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// A raise can execute a modified
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
    }
}
