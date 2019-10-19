using MvvmFrame.Entities;
using MvvmFrame.EventArgs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.SetProperty.Environment
{
    public sealed class SetPropertyViewModel: ViewModelBase
    {
        public int OnVerificationCallCounter { get; set; } = 0;
        public int OnErrorsCallCounter { get; set; } = 0;
        public int CreateObjectCallCounter { get; set; } = 0;

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
        }

        public override void OnErrors(ReadOnlyCollection<MvvmFrameErrorDetail> details)
        {
            OnErrorsCallCounter++;
        }

        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            CreateObjectCallCounter++;
            return base.CreateObject(factoryFunc, parameters);
        }
    }
}
