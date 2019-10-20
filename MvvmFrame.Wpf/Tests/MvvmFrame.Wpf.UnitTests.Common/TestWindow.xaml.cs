using System.Windows;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.Common
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public Frame Frame => mainFrame;
        public TestWindow()
        {
            InitializeComponent();
        }
    }
}
