using GetcuReone.MvvmFrame.Wpf;

namespace MvvmFrame.Wpf.Tests.CreateObject.Env
{
    public sealed class CreateObjectModel : ModelBase
    {
        public int GetModelCallCounter { get; set; }

        public override TModel GetModel<TModel>()
        {
            GetModelCallCounter++;
            return base.GetModel<TModel>();
        }
    }
}
