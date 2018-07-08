using DataAccess.EntityFramework.Core;
using MyDiary.StorageApi.Domain.Models;
using System.Data.Entity;

namespace DataAccess.EntityFramework
{
    public class EbookDbContext : DbContext , IEbookDbContext
    {
        public EbookDbContext() : base("name=EbookDbConnection") { }

        public DbSet<MyDiary.StorageApi.Domain.Models.Ebook> EBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<EbookDbContext>(CreateDatabaseIfNotExists<EbookDbContext>);

            //Configure schema
            modelBuilder.HasDefaultSchema("ebook");
            
            //// ebookEntity
            var bookEntity = modelBuilder.Entity<MyDiary.StorageApi.Domain.Models.Ebook>()
                                         .ToTable("EbookDetails");
            bookEntity.HasKey(b => b.Id);
            bookEntity.Ignore(x => x.IsVisibleInPages);
            bookEntity.Property(b => b.EbookName).HasColumnName("Name").IsRequired();
            bookEntity.Property(b => b.Prize).HasColumnName("Prize").IsRequired();
            bookEntity.Property(b => b.PublishedDate).HasColumnName("PublishedDate").IsOptional();
            bookEntity.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            bookEntity.Property(b => b.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();

        }
    }
}