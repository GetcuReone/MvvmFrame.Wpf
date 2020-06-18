using System;
using System.Windows.Input;

namespace GetcuReone.MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// Command.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<CommandArgs> execute;
        private readonly Func<bool> canExecute;
        private CommandArgs currentArgs;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action<CommandArgs> execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute), "Action execute not should be null");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Handler <see cref="CanExecuteChanged"/>.
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new System.EventArgs());
        }

        /// <inheritdoc/>
        public virtual bool CanExecute(object parameter) => canExecute?.Invoke() ?? true;

        /// <inheritdoc/>
        public virtual void Execute(object parameter)
        {
            currentArgs = new CommandArgs();

            try
            {
                execute(currentArgs);
            }
            catch (Exception)
            {
                if (currentArgs.IsCancel)
                    currentArgs.Compensate();

                currentArgs.FinishOperations();
                throw;
            }

            if (currentArgs.IsCancel)
                currentArgs.Compensate();

            currentArgs.FinishOperations();

            currentArgs = null;
            OnCanExecuteChanged();
        }

        /// <summary>
        /// Cancel command. Upon completion of the command, start compensation processes <see cref="CommandArgs.Compensate"/>.
        /// </summary>
        public virtual void Cancel() => currentArgs?.Cancel();
    }

    /// <summary>
    /// Command.
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class Command<TParameter> : ICommand
    {
        private readonly Action<CommandArgs<TParameter>> execute;
        private readonly Func<TParameter, bool> canExecute;
        private CommandArgs<TParameter> currentArgs;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action<CommandArgs<TParameter>> execute, Func<TParameter, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute), "Action execute not should be null");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Handler <see cref="CanExecuteChanged"/>.
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new System.EventArgs());
        }

        /// <inheritdoc/>
        public virtual bool CanExecute(object parameter) => canExecute?.Invoke((TParameter)parameter) ?? true;

        /// <inheritdoc/>
        public virtual void Execute(object parameter)
        {
            currentArgs = new CommandArgs<TParameter>((TParameter)parameter);

            try
            {
                execute(currentArgs);
            }
            catch (Exception)
            {
                if (currentArgs.IsCancel)
                    currentArgs.Compensate();

                currentArgs.FinishOperations();
                throw;
            }

            if (currentArgs.IsCancel)
                currentArgs.Compensate();

            currentArgs.FinishOperations();

            currentArgs = null;
            OnCanExecuteChanged();
        }

        /// <summary>
        /// Cancel command. Upon completion of the command, start compensation processes <see cref="CommandArgs.Compensate"/>.
        /// </summary>
        public virtual void Cancel() => currentArgs?.Cancel();
    }
}
