using MvvmFrame.Entities;
using MvvmFrame.EventArgs;
using MvvmFrame.Wpf.EventArgs;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.SetProperty.Environment
{
    public sealed class SetPropertyViewModel: ViewModelBase
    {
        public ReadOnlyCollection<MvvmFrameErrorDetail> Details { get; private set; }
        public int OnVerificationCallCounter { get; set; } = 0;
        public int OnErrorsCallCounter { get; set; } = 0;
        public int OnPropertyChangedCallCounter { get; private set; } = 0;

        public SetPropertyModel Model { get; private set; }

        public string TextTest { get => _textTest; set => SetPropertyValue(ref _textTest, value); }
        private string _textTest;

        protected override void Initialize()
        {
            Model = GetModel<SetPropertyModel>();
        }

        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            return default;
        }

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            return default;
        }

        protected override ValueTask OnLoadPageAsync()
        {
            return default;
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

        public override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChangedCallCounter++;
            base.OnPropertyChanged(propertyName);
        }
    }
}
