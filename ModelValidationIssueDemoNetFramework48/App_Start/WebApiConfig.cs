using ModelValidationIssueDemo;

using Swashbuckle.Application;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ModelValidationIssueDemoNetFramework48
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ModelStateValidationAttribute());

            config
                .EnableSwagger(swaggerConfig =>
                {
                    swaggerConfig.SingleApiVersion("v1", "ModelValidationIssueDemoNetFramework48");
                })
                .EnableSwaggerUi(swaggerConfig =>
                {
                    swaggerConfig.DisableValidator();
                });
        }
    }
}