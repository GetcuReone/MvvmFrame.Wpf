using MvvmFrame.Wpf.TestWpf.Pages;
using MvvmFrame.Wpf.TestWpf.ViewModels;
using System.Windows;

namespace MvvmFrame.Wpf.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelBase.Navigate<HomePage>(
                ViewModelBase.CreateViewModel<HomeViewModel>(_mainFrame));
        }
    }
}
