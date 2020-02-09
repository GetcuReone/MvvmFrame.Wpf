using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MvvmFrame.Entities;
using MvvmFrame.EventArgs;

namespace MvvmFrame.Wpf.UnitTests.SetProperty.Environment
{
    public sealed class SetPropertyModel: ModelBase
    {
        public ReadOnlyCollection<MvvmFrameErrorDetail> Details { get; private set; }
        public int OnVerificationCallCounter { get; private set; } = 0;
        public int OnErrorsCallCounter { get; private set; } = 0;
        public int OnPropertyChangedCallCounter { get; private set; } = 0;

        public string TextTest 
        { 
            get => _textTest; 
            set
            {
                SetPropertyValue(ref _textTest, value);
            }
        }
        private string _textTest;

        public override void OnVerification(MvvmElementPropertyVerifyChangeEventArgs e)
        {
            OnVerificationCallCounter++;

            switch (e.PropertyName)
            {
                case nameof(TextTest):
                    if (TextTest == "error")
                        e.AddError(new MvvmFrameErrorDetail 
                        {
                            Code = "InvalidData",
                            Message = $"Property '{nameof(TextTest)}' dont have value '{TextTest}'",
                        });
                    break;
            }
        }

        public override void OnErrors(ReadOnlyCollection<MvvmFrameErrorDetail> details)
        {
            OnErrorsCallCounter++;
            Details = details;
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChangedCallCounter++;
            base.OnPropertyChanged(propertyName);
        }
    }
}
