using MvvmFrame.Wpf.Entities;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.UiServices.Environment
{
    public sealed class UiService: UiServiceBase
    {
        public Frame GetFrame() => Frame;
    }
}
