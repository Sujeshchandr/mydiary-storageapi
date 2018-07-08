using MyDiary.StorageApi.Models;
using MongoDB.Driver;
using MyDiary.StorageApi.DataAccess.Expenses;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyDiary.StorageApi.DataAccess.MongoDb.Expenses
{
    public class ExpensesDataAccess : MongoDbCollectionHelper<Expense> , IExpensesDataAccess
    {
        public ExpensesDataAccess(IMongoClient mongoClient, string collectionName, string dataBaseName) 
            : base(mongoClient, collectionName, dataBaseName)
        {
        }

        public async Task<IList<Expense>> GetExpensesByUserIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            return await Collection.Find(x => x.UserId == userId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<Expense>> GetExpensesByUserIdAndYearAsync(int userId, int year)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            if (year <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }

            var min = new DateTime(year, 01, 01, 00, 00, 00);
            var max = new DateTime(year+1, 01, 01, 00, 00, 00);

            return await Collection.Find(
                                    x => x.UserId == userId && 
                                   (x.ExpenseDate > min && x.ExpenseDate < max))
                                   .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<Expense>> GetExpensesByUserIdAndYearAndMonthNumberAsync(int userId, int year, int monthNumber)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            if (year <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }

            if (monthNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(monthNumber));
            }

            var min = new DateTime(year, monthNumber, 01, 00, 00, 00);

            if (monthNumber == 12)
            {
                year = year + 1;
                monthNumber = 1;
            }
            else
            {
                monthNumber = monthNumber + 1;

            }

            var max = new DateTime(year, monthNumber, 01, 00, 00, 00);

            return await Collection.Find(
                                    x => x.UserId == userId &&
                                   (x.ExpenseDate > min && x.ExpenseDate < max))
                                   .ToListAsync().ConfigureAwait(false);
        }
    }
}


