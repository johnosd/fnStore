using FN.Store.Api.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FN.Store.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var formatters = config.Formatters;

            //desativar o xml
            formatters.Remove(formatters.XmlFormatter);

            //Modifica a serialização p/ não dar erro de referencia circular
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            

            config.Routes.MapHttpRoute(
                name: "HelloWorldApi",
                routeTemplate: "api/helloworld/{id}",
                defaults: new { controller = "HelloWorld", id = RouteParameter.Optional },
                constraints: null,
                handler: new AuthenticationMessageHandler(GlobalConfiguration.Configuration)
            );

            config.Routes.MapHttpRoute(
                name: "OData",
                routeTemplate: "odata/clientes",
                defaults: new { controller = "OData" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
