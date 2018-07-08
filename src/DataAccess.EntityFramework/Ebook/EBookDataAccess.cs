using System;
using MyDiary.StorageApi.DataAccess.Ebook;

namespace DataAccess.EntityFramework.Ebook
{
    public class EBookDataAccess : IEbookDataAccess
    {
        private readonly EbookDbContext _eBookDbContext;

        public EBookDataAccess()
        {
            _eBookDbContext = new EbookDbContext();
        }

        public int Add(MyDiary.StorageApi.Domain.Models.Ebook eBook)
        {
            var result = _eBookDbContext.EBooks.Add(eBook);

            _eBookDbContext.SaveChanges();

            return result.Id;
        }

        public void Delete(int eBookId)
        {
            throw new NotImplementedException();
        }

        public void Update(MyDiary.StorageApi.Domain.Models.Ebook eBook)
        {
            throw new NotImplementedException();
        }
    }
}
