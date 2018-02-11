using PetOwners.Core.Domain;
using System.Collections.Generic;

namespace Repository
{
    /// <summary>
    /// PetOwnerRepository Class implements IPetOwnerRepository Interface
    /// </summary>
    public class PetOwnerRepository : IPetOwnerRepository
    {

        // DataAccessor Interface
        private readonly IDataAccessor _accessor;

        // Constructor to set data accessor
        public PetOwnerRepository(IDataAccessor accessor) => _accessor = accessor;

        // Get list of owners' information with their pet from Data accessor
        public IEnumerable<Owner> GetOwners() => _accessor.GetOwners();

    }
}
