using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
            // Register areas
            AreaRegistration.RegisterAllAreas();

            // Register routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Initialise dependency container
            UnityContainerRegistration.InitialiseContainer();
        }
    }
}
