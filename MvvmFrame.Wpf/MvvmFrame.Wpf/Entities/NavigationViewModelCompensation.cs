using MvvmFrame.Interfaces;
using System;
using System.Collections.Generic;

namespace MvvmFrame.Wpf.Entities
{
    internal class NavigationViewModelCompensation : ICompensationOperations
    {
        private readonly Stack<Action> _compensationOperations = new Stack<Action>();

        public void AddCompensation(Action compansation) => _compensationOperations.Push(compansation);

        public void ClearCompensation() => _compensationOperations.Clear();

        public void Compensate()
        {
            int count = _compensationOperations.Count;

            for (int i = 0; i < count; i++)
                _compensationOperations.Pop().Invoke();
        }
    }
}
