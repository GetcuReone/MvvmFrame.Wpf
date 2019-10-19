using ComboPatterns.AFAP;
using MvvmFrame.Wpf;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MvvmFrame.Wpf.UnitTests.Common.Entities
{
    //public sealed class ModelTest: ModelBase
    //{
    //    internal int OnVerifyPropertyChangeCallNumber { get; private set; }
    //    internal int OnPropertyChangedCallNumber { get; private set; }
    //    internal int OnErrorsCallNumber { get; private set; }

    //    internal int GetModelCallNumber { get; private set; }
    //    internal int SetPropertyValueCallNumber { get; private set; }
    //    internal int VerificationCallNumber { get; private set; }
    //    internal int BindModelCallNumber { get; private set; }
    //    internal int GetFacadeCallNumber { get; private set; }

    //    public bool IsEnabled { get => _isEnabled; set => SetPropertyValue(ref _isEnabled, value); }
    //    private bool _isEnabled;
    //    public string Name { get => _name; set => SetPropertyValue(ref _name, value); }
    //    private string _name;

    //    #region Overide

    //    public override void OnPropertyChanged([CallerMemberName] string propertyName = "")
    //    {
    //        OnPropertyChangedCallNumber++;
    //        base.OnPropertyChanged(propertyName);
    //    }

    //    public override bool OnVerifyPropertyChange([CallerMemberName] string propertyName = "")
    //    {
    //        OnVerifyPropertyChangeCallNumber++;
    //        return base.OnVerifyPropertyChange(propertyName);
    //    }

    //    public override void OnErrors(List<Func<string>> getErrorMessageList)
    //    {
    //        OnErrorsCallNumber++;
    //        base.OnErrors(getErrorMessageList);
    //    }

    //    public override TModel GetModel<TModel>()
    //    {
    //        GetModelCallNumber++;
    //        return base.GetModel<TModel>();
    //    }

    //    protected override bool SetPropertyValue<TProperty>(ref TProperty property, TProperty value, [CallerMemberName] string propertyName = "")
    //    {
    //        SetPropertyValueCallNumber++;
    //        return base.SetPropertyValue(ref property, value, propertyName);
    //    }

    //    public override string Verification(string propertyName)
    //    {
    //        VerificationCallNumber++;

    //        switch (propertyName)
    //        {
    //            case nameof(Name):
    //                if (Name == ViewModelTest.VerificationInvalid)
    //                    return $"property '{propertyName}' not have value {ViewModelTest.VerificationInvalid}";
    //                break;
    //        }

    //        return base.Verification(propertyName);
    //    }

    //    public override void BindModel<TModel>(TModel model)
    //    {
    //        BindModelCallNumber++;
    //        base.BindModel(model);
    //    }

    //    public TFacade GetFacade2<TFacade>()
    //        where TFacade: FacadeBase, new()
    //    {
    //        GetFacadeCallNumber++;
    //        return GetFacade<TFacade>();
    //    }

    //    #endregion
    //}
}
