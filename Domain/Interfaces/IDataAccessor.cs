using System.Collections.Generic;

namespace PetOwners.Core.Domain
{
    /// <summary>
    /// IDataAccessor Interface
    /// </summary>
    public interface IDataAccessor
    {
        /// <summary>
        /// Returns list of all owners' information with their pet
        /// </summary>
        /// <returns></returns>
        IEnumerable<Owner> GetOwners();

    }
}