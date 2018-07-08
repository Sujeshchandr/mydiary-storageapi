using Ninject.Modules;

namespace Infrastructure.Ioc
{
    public partial class MyDiaryStorageCommonModule : NinjectModule
    {
        public override void Load()
        {
            LoadApplicatonBindings();
            LoadDataAccessBindings();
        }
    }
}
