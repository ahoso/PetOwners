using PetOwners.Const;
using System.Web.Mvc;

namespace PetOwners.Controllers
{
    /// <summary>
    /// Errror Contoller
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Controller to direct to error page
        /// </summary>
        /// <returns></returns>
        [HandleError]
        public ActionResult Index()
        {
            return View(viewName: ViewNamne.Error);
        }

    }
}