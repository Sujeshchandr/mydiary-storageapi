using MyDiary.StorageApi.Domain.Models;
using System;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace MyDiary.StorageApi.Controllers
{
    [ODataRoutePrefix("incomes/")]
    public class IncomesController : System.Web.OData.ODataController
    {
        ////private readonly Income _incomeDomain;

        ////public IncomesController(IIncome incomeDomain)
        ////{
        ////    if (incomeDomain == null)
        ////    {
        ////        throw new ArgumentNullException(nameof(incomeDomain));
        ////    }

        ////    _incomeDomain = incomeDomain;
        ////}

        [HttpGet]
        [ODataRoute("get.chartData(userId={userId},type={type},typeData={typeData})")]
        [EnableQuery(AllowedQueryOptions =  AllowedQueryOptions.Skip | AllowedQueryOptions.Top)]
        public IHttpActionResult Get([FromODataUri]int userId, [FromODataUri]ChartType type, [FromODataUri]string typeData)
        {
            ////var expensesChartSummary = new ChartSummary
            ////{
            ////    ChartType = type,
            ////    Charts = _incomeDomain.GetMonthlyAmountSummary(userId, typeData)
            ////};

            ////return Ok(expensesChartSummary);

            throw new ArgumentNullException();

        }
    }
}
