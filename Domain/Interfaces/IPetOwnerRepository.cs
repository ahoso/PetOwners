using System.Collections.Generic;

namespace PetOwners.Core.Domain
{
    /// <summary>
    /// IPetOwnerRepository Interface
    /// </summary>
    public interface IPetOwnerRepository
    {
        /// <summary>
        /// Returns list of all owners' information with their pet
        /// </summary>
        /// <returns></returns>
        IEnumerable<Owner> GetOwners();

    }
}