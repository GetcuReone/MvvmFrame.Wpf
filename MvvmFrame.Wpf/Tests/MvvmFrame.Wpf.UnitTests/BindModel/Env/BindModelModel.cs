using GetcuReone.ComboPatterns.Interfaces;
using GetcuReone.MvvmFrame.Wpf;

namespace MvvmFrame.Wpf.UnitTests.BindModel.Env
{
    public sealed class BindModelModel : ModelBase
    {
        public IAbstractFactory GetFactory() => Factory;
    }
}
