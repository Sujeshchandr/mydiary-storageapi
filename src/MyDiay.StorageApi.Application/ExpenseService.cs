// Decompiled with JetBrains decompiler
// Type: MyDiay.StorageApi.Application.Services.ExpenseService
// Assembly: MyDiay.StorageApi.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 338F0588-F368-4475-9BC1-101848BA61CD
// Assembly location: C:\Users\a\Desktop\MyDiay.StorageApi.Application.dll

using MyDiary.StorageApi.DataAccess.Expenses;
using MyDiary.StorageApi.Domain.Models;
using MyDiary.StorageApi.Models;
using MyDiay.StorageApi.Application.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiay.StorageApi.Application.Services
{
    public class ExpenseService : IExpenseService
  {
    private readonly IExpensesDataAccess _expenseDataAccess;

    public ExpenseService(IExpensesDataAccess expenseDataAccess)
    {
      if (expenseDataAccess == null)
        throw new NotImplementedException(nameof (expenseDataAccess));
      this._expenseDataAccess = expenseDataAccess;
    }

    public Task<IList<Chart>> GetYearlyAmountSummaryAsync(int userId, int? noOfLatestYears)
    {
      throw new NotImplementedException();
    }

    public async Task<IList<Chart>> GetMonthlyAmountSummaryAsync(int userId, int year)
    {
      ////try
      ////{
      ////  EBookDataAccess ebookDataAccess = new EBookDataAccess();
      ////          Ebook ebook1 = new MyDiary.StorageApi.Domain.Models.Ebook();
      ////  ebook1.set_EbookName("ebook 1");
      ////  ebook1.set_ModifiedDate(new DateTimeOffset?(DateTimeOffset.UtcNow));
      ////  ebook1.set_PublishedDate(new DateTimeOffset?());
      ////  int ebook = ebookDataAccess.Add(ebook1);
      ////}
      ////catch (Exception ex)
      ////{
      ////  throw ex;
      ////}

      List<Chart> expenseCharts = new List<Chart>();
      foreach (object obj in Enum.GetValues(typeof (Month)))
      {
        object monthlyEnum = obj;
        IList<Expense> expenseList = await this._expenseDataAccess.GetExpensesByUserIdAndYearAndMonthNumberAsync(userId, year, (int) monthlyEnum).ConfigureAwait(false);
        IList<Expense> expenses = expenseList;
        expenseList = (IList<Expense>) null;
        double totalAmount = ((IEnumerable<Expense>) expenses).Select((Func<Expense, double>) (x => x.Amount)).Sum();
        List<Chart> chartList = expenseCharts;
        MonthlyChart monthlyChart = new MonthlyChart();
                monthlyChart.Amount = (Math.Round(totalAmount, 2));
                monthlyChart.SeqNumber = ((int) monthlyEnum);
        monthlyChart.Name = (monthlyEnum.ToString());
        chartList.Add(monthlyChart);
        expenses = null;
        monthlyEnum = null;
      }
      return (IList<Chart>) expenseCharts;
    }

    public Task<IList<Chart>> GetWeeklyAmountSummaryAsync(int userId, string month, int year)
    {
      throw new NotImplementedException();
    }

    public Task<IList<Chart>> GetDailyAmountSummaryAsync(int userId, string date)
    {
      throw new NotImplementedException();
    }
  }
}
