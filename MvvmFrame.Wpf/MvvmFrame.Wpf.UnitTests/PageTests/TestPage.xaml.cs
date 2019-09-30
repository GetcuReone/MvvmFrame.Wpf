using MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.UnitTests.PageTests
{
    /// <summary>
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class TestPage : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
