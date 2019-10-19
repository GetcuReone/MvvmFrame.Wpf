using System.Collections.ObjectModel;
using MvvmFrame.Entities;
using MvvmFrame.EventArgs;

namespace MvvmFrame.Wpf.UnitTests.SetProperty.Environment
{
    public sealed class SetPropertyModel: ModelBase
    {
        public int OnVerificationCallCounter { get; set; } = 0;
        public int OnErrorsCallCounter { get; set; } = 0;

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
        }

        public override void OnErrors(ReadOnlyCollection<MvvmFrameErrorDetail> details)
        {
            OnErrorsCallCounter++;
        }
    }
}
