using System.Collections.Generic;
using System.Linq;
using PetOwners.Core.Domain;
using NUnit.Framework;
using Mocks;
namespace Repository.Tests
{
    /// <summary>
    /// Test PetOwnerRepository with Mock
    /// </summary>
    [TestFixture()]
    public class PetOwnerRepositoryTests
    {
        /// <summary>
        /// Mock PetOwner Repository for use in testing
        /// </summary>
        public IPetOwnerRepository _repository;

        [SetUp]
        public void Setup()
        {
            // set up mock oject
            _repository = MockPetOwnerRepository.SetUpMock().Object;
        }
        /// <summary>
        /// Test if all pet owners can be returned from Mock
        /// </summary>
        [TestCase]
        public void GetOwnersTest()
        {
            // Try finding all products
            IEnumerable<Owner> testOwners = _repository.GetOwners();
            Assert.IsNotNull(testOwners); // Test if null
        }

        /// <summary>
        /// Test if all pet can be returned with Owners from Mock
        /// </summary>
        [TestCase]
        public void GetPetsTest()
        {
            // Try finding all products
            IEnumerable<Owner> testOwners = _repository.GetOwners();
            Assert.IsNotNull(testOwners.Select(i => i.Pets)); // Test if null
        }

    }
}