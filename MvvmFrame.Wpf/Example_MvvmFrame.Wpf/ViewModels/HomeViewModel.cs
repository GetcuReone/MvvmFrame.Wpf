using GetcuReone.MvvmFrame.EventArgs;
using GetcuReone.MvvmFrame.Interfaces;
using GetcuReone.MvvmFrame.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Example_MvvmFrame.Wpf.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public string Title { get => _title; set => SetPropertyValue(ref _title, value); }
        private string _title = "Is Home page";

        public string Text { get => _text; set => SetPropertyValue(ref _text, value); }
        private string _text;

        public HomeViewModel()
        {
            VerifyPropertyChange += OnVerifyPropertyChange;
        }

        public override string Verification(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Text):
                    if (Text.Last() == '+')
                        return "Can not use '+' (Verification)";
                    break;
            }
            return base.Verification(propertyName);
        }

        public void OnVerifyPropertyChange(IModel model, MvvmElementPropertyVerifyChangeEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(Text):
                    if (Text.First() == '+')
                        args.AddError(() => "Can not use '+' (OnVerifyPropertyChange)");
                    break;
            }
        }

        public override void OnErrors(List<Func<string>> getErrorMessageList)
        {
            foreach (var getMessage in getErrorMessageList)
                MessageBox.Show(getMessage());
        }
    }
}
