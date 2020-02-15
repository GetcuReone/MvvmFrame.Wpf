using System.Windows;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestsCommon
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
