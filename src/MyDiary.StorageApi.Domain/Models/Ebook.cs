using System;

namespace MyDiary.StorageApi.Domain.Models
{
    public class Ebook
    {
        public int Id { get; set; }

        public string EbookName { get; set; }

        public double Prize { get; set; }

        public DateTimeOffset? PublishedDate { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        public bool IsVisibleInPages { get; set; }
    }
}
