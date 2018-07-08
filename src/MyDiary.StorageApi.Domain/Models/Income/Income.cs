using System.ComponentModel.DataAnnotations;

namespace MyDiary.StorageApi.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public long Amount { get; set; }

    }
}