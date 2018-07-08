using MyDiary.StorageApi.Domain.Models;
using System;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace MyDiary.StorageApi.Controllers
{
    public class UsersController : System.Web.OData.ODataController
    {
        [HttpGet]
        [ODataRoute("users({userId})/filter.by(type={type})")]
        public IHttpActionResult FilterBy([FromODataUri]int userId, [FromODataUri]string type)
        {
            ////var expensesChartSummary = new ChartSummary
            ////{
            ////    ChartType = type,
            ////    Charts = _incomeDomain.GetMonthlyAmountSummary(userId, typeData)
            ////};

            return Ok(true);
        }
    }
}
