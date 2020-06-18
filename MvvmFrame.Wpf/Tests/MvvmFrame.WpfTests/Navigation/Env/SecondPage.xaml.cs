using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Tests.Navigation.Env
{
    /// <summary>
    /// Interaction logic for SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
