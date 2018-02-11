using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.ApplicationInsights.Extensibility;

namespace PetOwners
{
    /// <summary>
    /// MVCApplication Class
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Application Start method 
        /// </summary>
        protected void Application_Start()
        {
            // set Application Insights key for server side analysis
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["TelemetryKey"].ToString();

            // Register areas
            AreaRegistration.RegisterAllAreas();

            // Register routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Initialise dependency container
            UnityContainerRegistration.InitialiseContainer();
        }
    }
}
