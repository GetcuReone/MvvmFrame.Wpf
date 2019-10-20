using ComboPatterns.Interfaces;
using MvvmFrame.Entities;
using MvvmFrame.EventArgs;
using MvvmFrame.EventHandlers;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.Helpers;
using MvvmFrame.Wpf.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmFrame.Wpf
{
    /// <summary>
    /// Base class for models
    /// </summary>
    public abstract class ModelBase : IModel
    {
        /// <summary>
        /// Factory about which the model was created
        /// </summary>
        protected IAbstractFactory Factory { get; private set; }

        /// <summary>
        /// UI services
        /// </summary>
        public IConfigUiServices UiServices { get; private set; }
        /// <summary>
        /// Model options
        /// </summary>
        public IModelOptions ModelOptions { get; set; }

        /// <summary>
        /// Event virification <see cref="IModel"/>
        /// </summary>
        public event MvvmElementPropertyVerifyChangeEventHandler VerifyPropertyChange;
        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Henders

        /// <summary>
        /// Hendler <see cref="INotifyPropertyChanged.PropertyChanged"/>
        /// </summary>
        /// <param name="propertyName">property name</param>
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => MvvmElementHelper.OnPropertyChanged(this, (args) => PropertyChanged?.Invoke(this, args), propertyName);

        /// <summary>
        /// Hendler <see cref="VerifyPropertyChange"/>
        /// </summary>
        /// <param name="propertyName">property name</param>
        public virtual bool OnVerifyPropertyChange([CallerMemberName] string propertyName = "")
            => MvvmElementHelper.OnVerifyPropertyChange(this, (args) => VerifyPropertyChange?.Invoke(this, args), propertyName);

        #endregion

        #region Methods

        /// <summary>
        /// Set property value
        /// </summary>
        /// <typeparam name="TProperty">type property</typeparam>
        /// <param name="property">property</param>
        /// <param name="value">new value</param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        protected virtual bool SetPropertyValue<TProperty>(ref TProperty property, TProperty value, [CallerMemberName]string propertyName = "")
        {
            return MvvmElementHelper.SetPropertyValue(this, ref property, value, propertyName);
        }

        /// <summary>
        /// Method creation model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public virtual TModel GetModel<TModel>() where TModel : IModel, new() => GetModelStatic<TModel>(Factory, ModelOptions);

        /// <summary>
        /// Bind model to the same factory and options
        /// </summary>
        /// <typeparam name="TModel">model type</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void BindModel<TModel>(TModel model) where TModel : ModelBase
            => BindModelStatic(model, Factory, ModelOptions, UiServices);

        /// <summary>
        /// Initialize model
        /// </summary>
        public virtual void Initialize() { }

        #endregion

        internal static void BindModelStatic<TModel>(TModel model, IAbstractFactory factory, IModelOptions options, IConfigUiServices uiServices)
            where TModel: ModelBase
        {
            model.Factory = factory;
            model.ModelOptions = options;
            model.UiServices = uiServices;
        }

        /// <summary>
        /// Func creation model 
        /// </summary>
        /// <typeparam name="TModel">type of model being created</typeparam>
        /// <param name="factory">type of factory that will spawn the model</param>
        /// <param name="options">model options</param>
        /// <returns></returns>
        public static TModel GetModelStatic<TModel>(IAbstractFactory factory, IModelOptions options = null)
            where TModel : IModel, new()
        {

            return factory.CreateObject<object, TModel>(
                (_) =>
                {
                    var model = new TModel();

                    if (model is ModelBase dest)
                    {
                        dest.ModelOptions = options;
                        dest.Factory = factory;
                        if (factory is ViewModelBase source)
                        {
                            dest.UiServices = source.UiServices;
                        }

                        dest.Initialize();
                    }

                    return model;
                }
                , null);
        }

        /// <summary>
        /// Verification hendler
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnVerification(MvvmElementPropertyVerifyChangeEventArgs e) { }

        /// <summary>
        /// Error hendler
        /// </summary>
        /// <param name="details"></param>
        public virtual void OnErrors(ReadOnlyCollection<MvvmFrameErrorDetail> details) { }
    }
}
