using MyDiary.StorageApi.Domain.Models;
using MyDiay.StorageApi.Application.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace MyDiary.StorageApi.Controllers
{
    [ODataRoutePrefix("expenses/")]
    public class ExpensesController : ODataController
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            if (expenseService == null)
            {
                throw new ArgumentNullException(nameof(expenseService));
            }

            _expenseService = expenseService;
        }

        // GET ~/expenses/get.yearlySummary(userId={userId}, noOfLatestYears={noOfLatestYears})
        [HttpGet]
        [ODataRoute("get.yearlySummary(userId={userId}, noOfLatestYears={noOfLatestYears})")]
        [EnableQuery]
        public async Task<IHttpActionResult> GetYearlySummary([FromODataUri]int userId, [FromODataUri]int? noOfLatestYears)
        {

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId)); 
            }

            var yearlyExpenseSummary = await _expenseService.GetYearlyAmountSummaryAsync(userId, noOfLatestYears).ConfigureAwait(false);

            return Ok(yearlyExpenseSummary);
        }

        // GET ~/expenses/get.monthlySummary(userId={userId}, year={year})
        [HttpGet]
        [ODataRoute("get.monthlySummary(userId={userId},year={year})")]
        public async Task<IHttpActionResult> GetMonthlySummary([FromODataUri]int userId, [FromODataUri]int year)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            if (year <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }

            var monthlyExpenseSummary = await _expenseService.GetMonthlyAmountSummaryAsync(userId, year).ConfigureAwait(false);

            var chartSummary = new ChartSummary()
            {
                Charts = monthlyExpenseSummary ,
                ChartType = ChartType.MonthlySummary
            };

            return Ok(chartSummary);
        }

        // GET ~/expenses/get.weeklySummary(userId={userId}, year={year}, month={month})
        [HttpGet]
        [ODataRoute("get.weeklySummary(userId={userId}, year={year}, month={month})")]
        public async Task<IHttpActionResult> GetWeeklySummary([FromODataUri]int userId, [FromODataUri]int year, [FromODataUri]string month)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            if (year <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }

            if (month == null)
            {
                throw new ArgumentNullException(nameof(month));
            }

            var yearlyExpenseSummary = await _expenseService.GetWeeklyAmountSummaryAsync(userId, month, year).ConfigureAwait(false);

            return Ok(yearlyExpenseSummary);
        }
    }
}
