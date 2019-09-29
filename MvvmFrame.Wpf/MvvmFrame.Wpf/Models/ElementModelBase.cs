using System.Windows;

namespace MvvmFrame.Wpf.Models
{
    /// <summary>
    /// Base class for element model
    /// </summary>
    public abstract class ElementModelBase: ModelBase
    {
        /// <summary>
        /// Visibility element. Default value <see cref="Visibility.Visible"/>
        /// </summary>
        public Visibility Visibility { get => _visibility; set => SetPropertyValue(ref _visibility, value); }
        private Visibility _visibility = Visibility.Visible;

        /// <summary>
        /// True - enabled (default value), False - disabled
        /// </summary>
        public bool IsEnabled { get => _isEnabled; set => SetPropertyValue(ref _isEnabled, value); }
        private bool _isEnabled = true;
    }
}
