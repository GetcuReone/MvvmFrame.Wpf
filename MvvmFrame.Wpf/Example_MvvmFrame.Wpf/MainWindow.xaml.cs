using Example_MvvmFrame.Wpf.Pages;
using Example_MvvmFrame.Wpf.ViewModels;
using MvvmFrame.Wpf;
using System.Windows;

namespace Example_MvvmFrame.Wpf
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
            HomeViewModel homeViewModel = ViewModelBase.CreateViewModel<HomeViewModel>(mainFrame);
            ViewModelBase.Navigate<HomePage>(homeViewModel);
        }
    }
}
