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
        /// use <see cref="IModel.Verification(string)"/>
        /// </summary>
        public bool UseVerification { get; set; }
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
            UseVerification = true,
            UseVerifyPropertyChange = true,
        };
    }
}
