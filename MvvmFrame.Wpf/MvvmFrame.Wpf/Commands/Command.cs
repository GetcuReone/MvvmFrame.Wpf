using System;
using System.Windows.Input;

namespace MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// Command
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<CommandArgs> execute;
        private readonly Func<bool> canExecute;
        private CommandArgs currentArgs;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action<CommandArgs> execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute), "Action execute not should be null");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter) => canExecute?.Invoke() ?? true;

        /// <summary>
        /// Defines the method to be called when the command is invoked
        /// </summary>
        /// <param name="parameter"></param>
        public virtual void Execute(object parameter)
        {
            currentArgs = new CommandArgs();

            execute(currentArgs);

            if (currentArgs.IsCancel)
                currentArgs.Compensate();

            currentArgs.FinishOperations();

            currentArgs = null;
        }

        /// <summary>
        /// Cancel command. Upon completion of the command, start compensation processes <see cref="CommandArgs.Compensate"/>
        /// </summary>
        public virtual void Cancel() => currentArgs?.Cancel();
    }

    /// <summary>
    /// Command
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class Command<TParameter> : ICommand
    {
        private readonly Action<CommandArgs<TParameter>> execute;
        private readonly Func<TParameter, bool> canExecute;
        private CommandArgs<TParameter> currentArgs;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action<CommandArgs<TParameter>> execute, Func<TParameter, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute), "Action execute not should be null");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter) => canExecute?.Invoke((TParameter)parameter) ?? true;

        /// <summary>
        /// Defines the method to be called when the command is invoked
        /// </summary>
        /// <param name="parameter"></param>
        public virtual void Execute(object parameter)
        {
            currentArgs = new CommandArgs<TParameter>((TParameter)parameter);

            execute(currentArgs);

            if (currentArgs.IsCancel)
                currentArgs.Compensate();

            currentArgs.FinishOperations();

            currentArgs = null;
        }

        /// <summary>
        /// Cancel command. Upon completion of the command, start compensation processes <see cref="CommandArgs.Compensate"/>
        /// </summary>
        public virtual void Cancel() => currentArgs?.Cancel();
    }
}
