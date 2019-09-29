using MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestWpf.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
