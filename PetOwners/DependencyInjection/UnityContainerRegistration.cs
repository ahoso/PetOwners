using PetOwners.Core.Domain;
using System.Web.Mvc;
using Unity;
using Repository;
using Unity.AspNet.Mvc;
using DataAccess.WebApi;

namespace PetOwners
{
    /// <summary>
    ///  UnityContainerRegistration Class
    /// </summary>
    public class UnityContainerRegistration
    {
        /// <summary>
        /// Initialise Container
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer InitialiseContainer()
        {
            var container = new UnityContainer();

            // Register type's mappings
            container.RegisterType<IPetOwnerRepository, PetOwnerRepository>();
            container.RegisterType<IDataAccessor, AglPeopleWebApiAccessor>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}