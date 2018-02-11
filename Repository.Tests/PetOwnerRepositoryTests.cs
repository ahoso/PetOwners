using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetOwners.Core.Domain;
using Moq;

namespace Repository.Tests
{
    /// <summary>
    /// Test PetOwnerRepository with Mock
    /// </summary>
    [TestClass()]
    public class PetOwnerRepositoryTests
    {
        /// <summary>
        /// Mock PetOwner Repository for use in testing
        /// </summary>
        public IPetOwnerRepository _repository;

        public PetOwnerRepositoryTests()
        {
            // create some mock pet owners to play with
            IEnumerable<Owner> owners = new List<Owner>
                {
                    new Owner { Name = "James", Age = 33, Gender = "Male", Pets = GetJamesPets()},
                    new Owner { Name = "Chris", Age = 34, Gender = "Male", Pets = GetChrisPets()},
                    new Owner { Name = "Mary", Age = 31, Gender = "Female", Pets = GetMaryPets()}
                };

            // Mock the PetOwner Repository 
            Mock<IPetOwnerRepository> mockProductRepository = new Mock<IPetOwnerRepository>();

            // Return all the pet owners
            mockProductRepository.Setup(mr => mr.GetOwners()).Returns(owners);

            // Complete the setup of Mock Repository
            _repository = mockProductRepository.Object;

        }

        // private methods to set pets for Mock owners
        private IEnumerable<Pet> GetJamesPets() => new List<Pet> { new Pet { Name = "Black", Type = "Sheep" } };
        private IEnumerable<Pet> GetChrisPets() => new List<Pet> { new Pet { Name = "Coco", Type = "Cow" } };
        private IEnumerable<Pet> GetMaryPets() => new List<Pet> { new Pet { Name = "Mocha", Type = "Cat" } };

        /// <summary>
        /// Test if all pet owners can be returned
        /// </summary>
        [TestMethod]
        public void CanGetOwnersTest()
        {
            // Try finding all products
            IEnumerable<Owner> testOwners = _repository.GetOwners();
            Assert.IsNotNull(testOwners); // Test if null
        }

        /// <summary>
        /// Test if all pet can be returned with Owners
        /// </summary>
        [TestMethod]
        public void CanGetPetsTest()
        {
            // Try finding all products
            IEnumerable<Owner> testOwners = _repository.GetOwners();
            Assert.IsNotNull(testOwners.Select(i=>i.Pets)); // Test if null
        }

    }
}