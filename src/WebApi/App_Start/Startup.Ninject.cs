using Infrastructure.Ioc;
using Ninject;

namespace MyDiary.StorageApi.App_Start
{
    public partial class Startup
    {
        public class NinjectConfig
        {
            public static IKernel CreateKernel()
            {
                return new StandardKernel(new MyDiaryStorageCommonModule());
            }
        }
    }
}