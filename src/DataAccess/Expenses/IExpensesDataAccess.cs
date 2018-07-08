using MyDiary.StorageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiary.StorageApi.DataAccess.Expenses
{
    public interface IExpensesDataAccess
    {
        Task<IList<Expense>> GetExpensesByUserIdAsync(int userId);

        Task<IList<Expense>> GetExpensesByUserIdAndYearAsync(int userId, int year);

        Task<IList<Expense>> GetExpensesByUserIdAndYearAndMonthNumberAsync(int userId, int year, int monthNumber);
    }
}
