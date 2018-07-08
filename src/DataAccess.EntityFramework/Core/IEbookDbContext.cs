using System.Data.Entity;

namespace DataAccess.EntityFramework.Core
{
    public interface IEbookDbContext
    {
        DbSet<MyDiary.StorageApi.Domain.Models.Ebook> EBooks { get; set; }
    }
}
