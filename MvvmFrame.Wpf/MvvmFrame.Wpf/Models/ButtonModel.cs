using System.Windows;
using System.Windows.Input;

namespace GetcuReone.MvvmFrame.Wpf.Models
{
    /// <summary>
    /// model button
    /// </summary>
    public class ButtonModel: ElementModelBase
    {
        /// <summary>
        /// Text button
        /// </summary>
        public string Text { get => _text; set => SetPropertyValue(ref _text, value); }
        private string _text;
        /// <summary>
        /// Button icon
        /// </summary>
        public string Icon { get => _icon; set => SetPropertyValue(ref _icon, value); }
        private string _icon;

        /// <summary>
        /// Command
        /// </summary>
        public ICommand Command { get => _command; set => SetPropertyValue(ref _command, value); }
        private ICommand _command;
    }

    /// <summary>
    /// model button with custom command
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public class ButtonModel<TCommand>: ElementModelBase
        where TCommand: ICommand
    {
        /// <summary>
        /// Text button
        /// </summary>
        public string Text { get => _text; set => SetPropertyValue(ref _text, value); }
        private string _text;
        /// <summary>
        /// Button icon
        /// </summary>
        public string Icon { get => _icon; set => SetPropertyValue(ref _icon, value); }
        private string _icon;

        /// <summary>
        /// Command
        /// </summary>
        public TCommand Command { get => _command; set => SetPropertyValue(ref _command, value); }
        private TCommand _command;
    }
}
