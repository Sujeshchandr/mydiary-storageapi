// Decompiled with JetBrains decompiler
// Type: MyDiay.StorageApi.Application.Services.Contracts.IExpenseService
// Assembly: MyDiay.StorageApi.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 338F0588-F368-4475-9BC1-101848BA61CD
// Assembly location: C:\Users\a\Desktop\MyDiay.StorageApi.Application.dll

using MyDiary.StorageApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiay.StorageApi.Application.Services.Contracts
{
  public interface IExpenseService
  {
    Task<IList<Chart>> GetYearlyAmountSummaryAsync(int userId, int? noOfLatestYears);

    Task<IList<Chart>> GetMonthlyAmountSummaryAsync(int userId, int year);

    Task<IList<Chart>> GetWeeklyAmountSummaryAsync(int userId, string month, int year);

    Task<IList<Chart>> GetDailyAmountSummaryAsync(int userId, string date);
  }
}
