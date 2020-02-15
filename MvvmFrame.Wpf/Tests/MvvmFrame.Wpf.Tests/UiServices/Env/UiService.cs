using GetcuReone.MvvmFrame.Wpf.Entities;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Tests.UiServices.Env
{
    public sealed class UiService : UiServiceBase
    {
        public Frame GetFrame() => Frame;
    }
}
