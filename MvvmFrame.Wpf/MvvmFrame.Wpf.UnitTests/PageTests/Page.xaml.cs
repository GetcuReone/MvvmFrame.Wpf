using MvvmFrame.Interfaces;

namespace MvvmFrame.Wpf.UnitTests.PageTests
{
    /// <summary>
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class Page : System.Windows.Controls.Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
