using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Tests.SetProperty.Env
{
    /// <summary>
    /// Interaction logic for SetPropertyPage.xaml
    /// </summary>
    public partial class SetPropertyPage : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
