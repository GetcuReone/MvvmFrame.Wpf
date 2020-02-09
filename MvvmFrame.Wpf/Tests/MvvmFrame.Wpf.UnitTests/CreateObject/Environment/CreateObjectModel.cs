using GetcuReone.MvvmFrame.Wpf;

namespace MvvmFrame.Wpf.UnitTests.CreateObject.Environment
{
    public sealed class CreateObjectModel: ModelBase
    {
        public int GetModelCallCounter { get; set; }

        public override TModel GetModel<TModel>()
        {
            GetModelCallCounter++;
            return base.GetModel<TModel>();
        }
    }
}
