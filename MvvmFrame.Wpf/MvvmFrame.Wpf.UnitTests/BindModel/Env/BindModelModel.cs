using ComboPatterns.Interfaces;

namespace MvvmFrame.Wpf.UnitTests.BindModel.Env
{
    public sealed class BindModelModel: ModelBase
    {
        public IAbstractFactory GetFactory() => Factory;
    }
}
