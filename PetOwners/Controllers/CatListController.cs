using PetOwners.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Client.Controllers
{
    /// <summary>
    /// Controller for Cat List
    /// </summary>
    public class CatListController : Controller
    {
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
            IEnumerable<Cat> cats;
            try
            {
                // filter pet owners currently owns some pets
                var owners = _iPetOwnerRepository.GetOwners().Where(i => i.Pets != null);

                // create new list with required fields on the page
                cats = from owner in owners
                       from pet in owner.Pets
                       where pet.Type.ToLower() == "cat"
                       select new Cat
                       {
                           Name = pet.Name,
                           OwnerGender = owner.Gender
                       };
            }
            catch
            {
                cats = null;
            }

            // return View
            return (cats != null) ? View(viewName: "CatList", model: cats) : View("Error");
        }

    }
}
