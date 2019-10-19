using MvvmFrame.Entities;
using MvvmFrame.EventArgs;
using System.Collections.ObjectModel;

namespace MvvmFrame.Wpf.UnitTests.SetProperty.Environment
{
    public sealed class SetPropertyViewModel: ViewModelBase
    {
        public ReadOnlyCollection<MvvmFrameErrorDetail> Details { get; private set; }
        public int OnVerificationCallCounter { get; set; } = 0;
        public int OnErrorsCallCounter { get; set; } = 0;

        public SetPropertyModel Model { get; private set; }

        public string TextTest { get => _textTest; set => SetPropertyValue(ref _textTest, value); }
        private string _textTest;

        protected override void Initialize()
        {
            base.Initialize();

            Model = GetModel<SetPropertyModel>();
        }

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
    }
}
