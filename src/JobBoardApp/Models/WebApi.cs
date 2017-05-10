using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;


namespace JobBoardApp.Models
{
    public static class WebApi
    {
        //public static class WebApiConfig
        //{
        //    public static void Register(HttpConfiguration config)
        //    {
        //        // Web API configuration and services
        //        // Configure Web API to use only bearer token authentication.
        //        config.SuppressDefaultHostAuthentication();
        //        config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

        //        // Web API routes
        //        config.MapHttpAttributeRoutes();

        //        var cors = new EnableCorsAttribute("*", "*", "*");
        //        config.EnableCors(cors);

        //        config.Routes.MapHttpRoute(
        //            name: "DefaultApi",
        //            routeTemplate: "api/{controller}/{id}",
        //            defaults: new { id = RouteParameter.Optional }
        //        );

        //        config.Formatters.Remove(config.Formatters.XmlFormatter);
        //        config.Formatters.Add(config.Formatters.JsonFormatter);

        //    }
        //}
    }
}
