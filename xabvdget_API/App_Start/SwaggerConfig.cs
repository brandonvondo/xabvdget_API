using System.Web.Http;
using WebActivatorEx;
using xabvdget_API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace xabvdget_API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c => c.SingleApiVersion("v1","xaBudget Help Api"))
                .EnableSwaggerUi();
        }
    }
}