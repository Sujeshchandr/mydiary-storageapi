using System;
using System.ComponentModel.DataAnnotations;

namespace MyDiary.StorageApi.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        public int UserId { get; set; }

        public double Amount { get; set; }

        public System.DateTimeOffset DateCreated { get; set; }

        public Uri EnterUrl { get; set; }

        public System.DateTime ExpenseDate { get; set; }

    }
}