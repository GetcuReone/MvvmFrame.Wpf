using System;

namespace GetcuReone.MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// On first access, the command will allow execution.
    /// </summary>
    public class FirstCanCommand : Command
    {
        private bool _isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public FirstCanCommand(Action<CommandArgs> execute, Func<bool> canExecute = null)
            : base(execute, canExecute)
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
    /// On first access, the command will allow execution.
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class FirstCanCommand<TParameter> : Command<TParameter>
    {
        private bool _isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public FirstCanCommand(Action<CommandArgs<TParameter>> execute, Func<TParameter, bool> canExecute = null)
            : base(execute, canExecute)
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
