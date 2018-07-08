namespace MyDiary.StorageApi.DataAccess.Ebook
{
    public interface IEbookDataAccess
    {
        int Add(Domain.Models.Ebook eBook);

        void Update(Domain.Models.Ebook eBook);

        void Delete(int eBookId);
    }
}
