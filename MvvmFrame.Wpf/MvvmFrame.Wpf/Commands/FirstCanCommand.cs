using System;

namespace GetcuReone.MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// on first access, the command will allow execution
    /// </summary>
    public class FirstCanCommand : Command
    {
        private bool isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public FirstCanCommand(Action<CommandArgs> execute, Func<bool> canExecute = null)
            : base(execute, canExecute)
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
    /// <typeparam name="TParameter"></typeparam>
    public class FirstCanCommand<TParameter> : Command<TParameter>
    {
        private bool isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public FirstCanCommand(Action<CommandArgs<TParameter>> execute, Func<TParameter, bool> canExecute = null)
            : base(execute, canExecute)
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
