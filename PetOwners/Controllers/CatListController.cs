using PetOwners.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;
using PetOwners.Const;

namespace MVC_Client.Controllers
{
    /// <summary>
    /// Controller for Cat List
    /// </summary>
    public class CatListController : Controller
    {
        TelemetryClient _telemetry = new TelemetryClient();
        // Repository interface
        IPetOwnerRepository _iPetOwnerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iPetOwnerRepository">Repository interface to be used</param>
        public CatListController(IPetOwnerRepository iPetOwnerRepository)
        {
            // set repository
            _iPetOwnerRepository = iPetOwnerRepository;
        }

        /// <summary>
        /// Return CatList View
        /// </summary>
        /// <returns></returns>
        public ActionResult CatList()
        {
            IEnumerable<Cat> _cats;
            try
            {
                // filter pet owners currently owns some pets
                var _owners = _iPetOwnerRepository.GetOwners().Where(i => i.Pets != null);

                // create new list with required fields on the page
                _cats = from owner in _owners
                       from pet in owner.Pets
                       where pet.Type.ToLower() == "cat"
                       select new Cat
                       {
                           Name = pet.Name,
                           OwnerGender = owner.Gender
                       };
            }
            catch(Exception ex)
            {

                // Log exception in to application insights
                Dictionary<string, string> _properties = new Dictionary<string, string>
                    {
                        { Logging.Location, "CatListController - CatList" },
                        { Logging.Message, ex.Message },
                        { Logging.StackTrace, ex.StackTrace }
                    };
                _telemetry.TrackException(ex, _properties);

                _cats = null;

            }

            // return View
            return (_cats != null) ? View(viewName: ViewNamne.CatList, model: _cats) : View(ViewNamne.Error);
        }

    }
}
