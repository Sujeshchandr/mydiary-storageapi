using DataAccess.EntityFramework.Ebook;
using MongoDB.Driver;
using MyDiary.StorageApi.DataAccess.Ebook;
using MyDiary.StorageApi.DataAccess.Expenses;
using MyDiary.StorageApi.DataAccess.MongoDb.Expenses;
using Ninject.Modules;

namespace Infrastructure.Ioc
{
    public partial class MyDiaryStorageCommonModule : NinjectModule
    {
        public void LoadDataAccessBindings()
        {
            Bind<IExpensesDataAccess>().To<ExpensesDataAccess>()
                                       .InSingletonScope()
                                       .WithConstructorArgument("collectionName","Expenses")
                                       .WithConstructorArgument("dataBaseName", "MyDIARY");

            Bind<IEbookDataAccess>().To<EBookDataAccess>()
                                      .InSingletonScope();

            LoadMongoDbHelperBindings();
        }

        private void LoadMongoDbHelperBindings()
        {
            Bind<IMongoClient>().To<MongoClient>().InSingletonScope();
        }
    }
}
