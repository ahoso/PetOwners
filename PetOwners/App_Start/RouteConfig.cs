using System.Web.Mvc;
using System.Web.Routing;

namespace PetOwners
{
    /// <summary>
    /// RouteConfig class to configure routes for MVC application
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Register routes for the application
        /// </summary>
        /// <param name="routes">Collection of registering routes</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CatList", action = "CatList", id = UrlParameter.Optional }
            );
        }
    }
}

