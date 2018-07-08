using Swashbuckle.Application;
using System.Web.Http;
using Swashbuckle;

using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using System.Web.Http.Cors;
using System.Web.OData.Batch;

namespace MyDiary.StorageApi.App_Start
{
    public partial class Startup
    {
        public class WebApi     
        {
            public static HttpConfiguration GetConfig()
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();

                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);

                config.EnableSwagger(x => x.SingleApiVersion("v1", "MyDiaryStorageApi"))
                      .EnableSwaggerUi();

                ////var pathHandler = new DefaultODataPathHandler();
                ////var routingConventions = ODataRoutingConventions.CreateDefault();
                ////var batchHandler = new DefaultODataBatchHandler(new HttpServer(config));

                config.MapODataServiceRoute(
                       routeName: "MyDiaryStorage",
                       routePrefix: "v1",
                       model: OData.GetEdmModel());

                
                config.EnsureInitialized();

                return config;
            }
        }
    }
}