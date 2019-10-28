using ComboPatterns.Interfaces;
using MvvmFrame.Entities;
using MvvmFrame.EventArgs;
using MvvmFrame.EventHandlers;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.Entities;
using MvvmFrame.Wpf.EventArgs;
using MvvmFrame.Wpf.Helpers;
using MvvmFrame.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmFrame.Wpf
{
    /// <summary>
    /// Base class for view-models
    /// </summary>
    public abstract class ViewModelBase : IAbstractFactory, IViewModel, IDisposable
    {
        private NavigationViewModelManager _navigationManager;

        /// <summary>
        /// Navigation view-model manager
        /// </summary>
        public NavigationViewModelManager NavigationManager
        {
            get => _navigationManager;
            private set
            {
                _navigationManager?.LinkRemove(this);
                _navigationManager = value;
                _navigationManager?.LinkAdd(this);
            }
        }
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

        #region Inner methods

        internal ValueTask InnerOnLeavePageAsync(NavigatingEventArgs args) => OnLeavePageAsync(args);
        internal ValueTask InnerOnGoPageAsync(object navigateParam) => OnGoPageAsync(navigateParam);
        internal void InnerInitialaze() => Initialize();
        internal async void OnLoadPage(object sender, RoutedEventArgs args) => await OnLoadPageAsync();

        //internal virtual TFacade InnderGetFacade<TFacade>() where TFacade : FacadeBase, new() => GetFacade<TFacade>();

        #endregion

        #region Hendlers

        /// <summary>
        /// Сalled after asynchronous page loading
        /// </summary>
        /// <returns></returns>
        protected abstract ValueTask OnLoadPageAsync();

        /// <summary>
        /// Сalled after asynchronous page leaving
        /// </summary>
        /// <param name="args">navigating event args</param>
        /// <returns></returns>
        protected abstract ValueTask OnLeavePageAsync(NavigatingEventArgs args);

        /// <summary>
        /// Сalled after asynchronous page going
        /// </summary>
        /// <param name="navigateParam">navigation parametrs</param>
        /// <returns></returns>
        protected abstract ValueTask OnGoPageAsync(object navigateParam);

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

        /// <summary>
        /// Hendler errors
        /// </summary>
        /// <param name="getErrorMessageList"></param>
        public virtual void OnErrors(List<Func<string>> getErrorMessageList) { }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize view-model
        /// </summary>
        protected abstract void Initialize();

        /// <summary>
        /// Set property value
        /// </summary>
        /// <typeparam name="TProperty">type property</typeparam>
        /// <param name="property">property</param>
        /// <param name="value">new value</param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        protected virtual bool SetPropertyValue<TProperty>(ref TProperty property, TProperty value, [CallerMemberName]string propertyName = "")
            => MvvmElementHelper.SetPropertyValue(this, ref property, value, propertyName);

        /// <summary>
        /// Method creation model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public virtual TModel GetModel<TModel>() where TModel : IModel, new() => ModelBase.GetModelStatic<TModel>(this, ModelOptions);

        /// <summary>
        /// Method creation view-model
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        public virtual TViewModel GetViewModel<TViewModel>() where TViewModel : IViewModel, new()
            => GetViewModelStatic<TViewModel>(this, ModelOptions);

        /// <summary>
        /// Bind model to the same factory and options
        /// </summary>
        /// <typeparam name="TModel">model type</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void BindModel<TModel>(TModel model) where TModel : ModelBase
            => ModelBase.BindModelStatic(model, this, ModelOptions, UiServices);

        /// <summary>
        /// Method page navigation
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="navigateParam">navigation parametrs</param>
        /// <returns></returns>
        public virtual NavigateResult<TViewModel> Navigate<TPage, TViewModel>(object navigateParam = null)
            where TPage : Page, IPage, new()
            where TViewModel: ViewModelBase, new()
        {
            var viewModel = GetViewModel<TViewModel>();
            return NavigationManager.Navigate<TPage, TViewModel>(viewModel, navigateParam);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Func creation view-model 
        /// </summary>
        /// <typeparam name="TViewModel">type of model being created</typeparam>
        /// <param name="factory">type of factory that will spawn the model</param>
        /// <param name="options">model options</param>
        /// <returns></returns>
        public static TViewModel GetViewModelStatic<TViewModel>(IAbstractFactory factory, IModelOptions options = null)
            where TViewModel : IViewModel, new()
        {

            return factory.CreateObject<object, TViewModel>(
                (_) =>
                {
                    var model = new TViewModel();
                    model.ModelOptions = options;

                    if (model is ViewModelBase dest)
                    {
                        if (factory is ViewModelBase source)
                        {
                            dest.NavigationManager = source.NavigationManager;
                            dest.NavigationManager.LinkAdd(dest);
                            dest.UiServices = source.UiServices;
                        }
                    }

                    return model;
                }
                , null);
        }

        /// <summary>
        /// Method creation veiw-model
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="frame">frame to which pages will be linked and view-model</param>
        /// <param name="options"></param>
        /// <param name="uiServices"></param>
        /// <param name="navigationManager"></param>
        /// <returns></returns>
        public static TViewModel CreateViewModel<TViewModel>(
            Frame frame,
            IModelOptions options = null,
            IConfigUiServices uiServices = null,
            NavigationViewModelManager navigationManager = null)
            where TViewModel: ViewModelBase, new()
        {
            if (frame == null)
                throw new ArgumentNullException(nameof(frame), "frame should not be null");

            var viewModel = new TViewModel
            {
                ModelOptions = options,
            };

            viewModel.NavigationManager = navigationManager ?? viewModel.CreateObject(f => new NavigationViewModelManager(f.NavigationService), frame);
            viewModel.UiServices = uiServices ?? viewModel.CreateObject<object, IConfigUiServices>((_) => new ConfigUiServices(), null);
            return viewModel;
        }

        /// <summary>
        /// Method page navigation
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="viewModel">view-model for DataContext</param>
        /// <param name="navigateParam">navigation parametrs</param>
        /// <returns></returns>
        public static NavigateResult<ViewModelBase> Navigate<TPage>(ViewModelBase viewModel, object navigateParam = null)
            where TPage : Page, IPage, new()
        {
            return viewModel.NavigationManager.Navigate<TPage, ViewModelBase>(viewModel, navigateParam);
        }

        #endregion

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
            NavigationManager.LinkRemove(this);
            NavigationManager.Dispose();
        }

        /// <summary>
        /// Verification hendler
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnVerification(MvvmElementPropertyVerifyChangeEventArgs e) { }

        /// <summary>
        /// Hendler errors
        /// </summary>
        /// <param name="details"></param>
        public virtual void OnErrors(ReadOnlyCollection<MvvmFrameErrorDetail> details) { }

        /// <summary>
        /// Create object method
        /// </summary>
        /// <typeparam name="TParameters"></typeparam>
        /// <typeparam name="TObj"></typeparam>
        /// <param name="factoryFunc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            if (factoryFunc == null)
                throw new ArgumentNullException(nameof(factoryFunc), $"{nameof(factoryFunc)} should not be null");

            return factoryFunc(parameters);
        }
    }
}
