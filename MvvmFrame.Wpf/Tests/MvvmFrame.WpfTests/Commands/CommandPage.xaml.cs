﻿using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.Tests.Commands
{
    /// <summary>
    /// Interaction logic for CommandPage.xaml
    /// </summary>
    public partial class CommandPage : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
