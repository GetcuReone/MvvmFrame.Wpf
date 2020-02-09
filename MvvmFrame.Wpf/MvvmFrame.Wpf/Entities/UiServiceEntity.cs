using System;
using System.Windows.Controls;

namespace GetcuReone.MvvmFrame.Wpf.Entities
{
    internal sealed class UiServiceEntity<TUiService>
    {
        private readonly ConfigUiServices _configUiServices;
        private TUiService _uiService;
        private Func<Frame, TUiService> _getServiceFunc;

        internal Frame Frame { get; set; }
        internal bool IsSingleton { get; set; }

        internal UiServiceEntity(ConfigUiServices configUiServices) => _configUiServices = configUiServices;

        internal TUiService GetService()
        {
            if (IsSingleton)
            {
                if (_uiService != null)
                    return _uiService;
                else
                    return (_uiService = _configUiServices.CreateObject(_getServiceFunc, Frame));
            }
            else
                return _configUiServices.CreateObject(_getServiceFunc, Frame);
        }

        internal void SetupFuncGetService(Func<Frame, TUiService> getServiceFunc) => _getServiceFunc = getServiceFunc;
    }
}
