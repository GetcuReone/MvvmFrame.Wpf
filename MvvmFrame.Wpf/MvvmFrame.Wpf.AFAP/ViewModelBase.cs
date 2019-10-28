using ComboPatterns.AFAP;
using ComboPatterns.Interfaces;

namespace MvvmFrame.Wpf.AFAP
{
    /// <summary>
    /// Base class for view-model implementing methods 'GetFacade' and 'GetAdapter'
    /// </summary>
    public abstract class ViewModelBase: Wpf.ViewModelBase
    {
        /// <summary>
        /// Сreate facade
        /// </summary>
        /// <typeparam name="TFacade"></typeparam>
        /// <returns></returns>
        public virtual TFacade GetFacade<TFacade>()
            where TFacade : IFacade, new()
        {
            return FacadeBase.GetFacadeStatic<TFacade>(this);
        }

        /// <summary>
        /// Сreate adapter
        /// </summary>
        /// <typeparam name="TAdapter"></typeparam>
        /// <returns></returns>
        public virtual TAdapter GetAdapter<TAdapter>()
            where TAdapter : IAdapter, new()
        {
            return AdapterBase.GetAdapterStatic<TAdapter>(this);
        }
    }
}
