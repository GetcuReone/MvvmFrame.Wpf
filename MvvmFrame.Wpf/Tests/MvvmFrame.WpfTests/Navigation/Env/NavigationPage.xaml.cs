using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Tests.Navigation.Env
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
