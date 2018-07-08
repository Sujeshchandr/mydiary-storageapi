using MyDiay.StorageApi.Application.Services;
using MyDiay.StorageApi.Application.Services.Contracts;
using Ninject.Modules;

namespace Infrastructure.Ioc
{
    public partial class MyDiaryStorageCommonModule : NinjectModule
    {
        public void LoadApplicatonBindings()
        {
            Bind<IExpenseService>().To<ExpenseService>().InSingletonScope();
            Bind<IIncomeService>().To<IncomeService>().InSingletonScope();
        }
    }
}
