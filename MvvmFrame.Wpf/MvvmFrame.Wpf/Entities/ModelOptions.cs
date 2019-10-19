using MvvmFrame.Interfaces;

namespace MvvmFrame.Wpf.Entities
{
    /// <summary>
    /// options for model
    /// </summary>
    public class ModelOptions : IModelOptions
    {
        /// <summary>
        /// use only <see cref="IModel.OnPropertyChanged(string)"/>
        /// </summary>
        public bool UseOnlyOnPropertyChanged { get; set; }
        /// <summary>
        /// use <see cref="IModel.OnVerification(MvvmFrame.EventArgs.MvvmElementPropertyVerifyChangeEventArgs)"/>
        /// </summary>
        public bool UseOnVerification { get; set; }
        /// <summary>
        /// use <see cref="IModel.VerifyPropertyChange"/>
        /// </summary>
        public bool UseVerifyPropertyChange { get; set; }

        /// <summary>
        /// Default options for model
        /// </summary>
        public static readonly ModelOptions Default = new ModelOptions
        {
            UseOnlyOnPropertyChanged = false,
            UseOnVerification = true,
            UseVerifyPropertyChange = true,
        };
    }
}
