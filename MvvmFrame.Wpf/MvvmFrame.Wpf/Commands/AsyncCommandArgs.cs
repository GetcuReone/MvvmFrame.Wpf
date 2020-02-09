using GetcuReone.MvvmFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.MvvmFrame.Wpf.Commands
{
    /// <summary>
    /// Async command args
    /// </summary>
    public class AsyncCommandArgs : ICancellation, IAsyncCompensationOperations, IFinalOperations
    {
        private readonly Stack<Func<ValueTask>> _compensationOperations = new Stack<Func<ValueTask>>();
        private readonly Queue<Action> _finishActions = new Queue<Action>();

        /// <summary>
        /// True - command canceled, False - command not canceled
        /// </summary>
        public bool IsCancel { get; private set; } = false;

        /// <summary>
        /// Add compensation
        /// </summary>
        /// <param name="compansation"></param>
        public void AddCompensation(Func<ValueTask> compansation) => _compensationOperations.Push(compansation);

        /// <summary>
        /// Add final operation
        /// </summary>
        /// <param name="operation">operation</param>
        public void AddFinalOperation(Action operation) => _finishActions.Enqueue(operation);

        /// <summary>
        /// Cancel. Upon completion of the command, start compensation processes <see cref="Compensate"/>
        /// </summary>
        public void Cancel() => IsCancel = true;

        /// <summary>
        /// Clear compensation
        /// </summary>
        public void ClearCompensation() => _compensationOperations.Clear();

        /// <summary>
        /// Run compensation operations
        /// </summary>
        public async ValueTask Compensate()
        {
            int count = _compensationOperations.Count;

            for (int i = 0; i < count; i++)
                await _compensationOperations.Pop().Invoke();
        }

        /// <summary>
        /// Run final operations
        /// </summary>
        public void FinishOperations()
        {
            int count = _finishActions.Count;
            for (int i = 0; i < count; i++)
                _finishActions.Dequeue().Invoke();
        }
    }

    /// <summary>
    /// Command args
    /// </summary>
    public sealed class AsyncCommandArgs<TParameter> : AsyncCommandArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commandParam"></param>
        public AsyncCommandArgs(TParameter commandParam)
        {
            CommandParam = commandParam;
        }

        /// <summary>
        /// Command parameter
        /// </summary>
        public TParameter CommandParam { get; }
    }
}
