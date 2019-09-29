using MvvmFrame.EventHandlers;
using MvvmFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmFrame.Wpf.UnitTests.ViewModel.Entities
{
    public sealed class ViewModel : IViewModel
    {
        public IModelOptions Options { get; set; }

        public event MvvmElementPropertyVerifyChangeEventHandler VerifyPropertyChange;
        public event PropertyChangedEventHandler PropertyChanged;

        public TModel GetModel<TModel>() where TModel : IModel, new()
        {
            throw new NotImplementedException();
        }

        public TViewModel GetViewModel<TViewModel>() where TViewModel : IViewModel, new()
        {
            throw new NotImplementedException();
        }

        public void OnErrors(List<Func<string>> getErrorMessageList)
        {
            throw new NotImplementedException();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            throw new NotImplementedException();
        }

        public bool OnVerifyPropertyChange([CallerMemberName] string propertyName = "")
        {
            throw new NotImplementedException();
        }

        public void OnWarnings(List<Func<string>> getWarningMessageList)
        {
            throw new NotImplementedException();
        }

        public string Verification(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
