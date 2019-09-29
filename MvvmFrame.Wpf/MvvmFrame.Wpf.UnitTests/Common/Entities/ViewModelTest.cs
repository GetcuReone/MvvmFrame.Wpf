using MvvmFrame.Wpf;
using MvvmFrame.Wpf.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MvvmFrame.Wpf.UnitTests.Common.Entities
{
    public sealed class ViewModelTest: ViewModelBase
    {
        internal int OnVerifyPropertyChangeCallNumber { get; private set; }
        internal int OnPropertyChangedCallNumber { get; private set; }
        internal int OnErrorsCallNumber { get; private set; }

        internal int GetModelCallNumber { get; private set; }
        internal int GetViewModelCallNumber { get; private set; }
        internal int CreateObjectCallNumber { get; private set; }
        internal int SetPropertyValueCallNumber { get; private set; }
        internal int VerificationCallNumber { get; private set; }
        internal int BindModelCallNumber { get; private set; }

        public static string VerificationInvalid => nameof(VerificationInvalid);

        public string Name { get => _name; set => SetPropertyValue(ref _name, value); }
        private string _name;

        public ViewModelTest()
        {
            Options = new ModelOptions
            {
                UseOnlyOnPropertyChanged = false,
                UseVerification = true,
                UseVerifyPropertyChange = true,
            };
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChangedCallNumber++;
            base.OnPropertyChanged(propertyName);
        }

        public override bool OnVerifyPropertyChange([CallerMemberName] string propertyName = "")
        {
            OnVerifyPropertyChangeCallNumber++;
            return base.OnVerifyPropertyChange(propertyName);
        }

        public override TModel GetModel<TModel>()
        {
            GetModelCallNumber++;
            return base.GetModel<TModel>();
        }

        public override TViewModel GetViewModel<TViewModel>()
        {
            GetViewModelCallNumber++;
            return base.GetViewModel<TViewModel>();
        }

        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            CreateObjectCallNumber++;
            return base.CreateObject(factoryFunc, parameters);
        }

        protected override bool SetPropertyValue<TProperty>(ref TProperty property, TProperty value, [CallerMemberName] string propertyName = "")
        {
            SetPropertyValueCallNumber++;
            return base.SetPropertyValue(ref property, value, propertyName);
        }

        public override void OnErrors(List<Func<string>> getErrorMessageList)
        {
            OnErrorsCallNumber++;
            base.OnErrors(getErrorMessageList);
        }

        public override string Verification(string propertyName)
        {
            VerificationCallNumber++;

            switch (propertyName)
            {
                case nameof(Name):
                    if (Name == ViewModelTest.VerificationInvalid)
                        return $"property '{propertyName}' not have value {ViewModelTest.VerificationInvalid}";
                    break;
            }

            return base.Verification(propertyName);
        }

        public override void BindModel<TModel>(TModel model)
        {
            BindModelCallNumber++;
            base.BindModel(model);
        }
    }
}
