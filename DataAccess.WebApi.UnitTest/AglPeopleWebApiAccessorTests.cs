using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PetOwners.Core.Domain;
using NUnit.Framework;

namespace DataAccess.WebApi.Unit.Test
{
    /// <summary>
    /// Test AglPeopleWebApiAccessor with Mock
    /// </summary>
    [TestFixture()]
    public class AglPeopleWebApiAccessorTests
    {
        public IDataAccessor _accessor;

        /// <summary>
        /// Constructor to setup Mock
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // create some mock pet owners to play with
            IEnumerable<Owner> owners = new List<Owner>
                {
                    new Owner { Name = "James", Age = 33, Gender = "Male", Pets = GetJamesPets()},
                    new Owner { Name = "Chris", Age = 34, Gender = "Male", Pets = GetChrisPets()},
                    new Owner { Name = "Mary", Age = 31, Gender = "Female", Pets = GetMaryPets()}
                };

            // Mock the Web API data access 
            Mock<IDataAccessor> mockAglPeopleWebApiAccessor = new Mock<IDataAccessor>();

            // Return all the pet owners
            mockAglPeopleWebApiAccessor.Setup(mr => mr.GetOwners()).Returns(owners);

            // Complete the setup of Mock Repository
            _accessor = mockAglPeopleWebApiAccessor.Object;
        }
        public AglPeopleWebApiAccessorTests()
        {
        }
        // private methods to set pets for Mock owners
        private IEnumerable<Pet> GetJamesPets() => new List<Pet> { new Pet { Name = "Black", Type = "Sheep" } };
        private IEnumerable<Pet> GetChrisPets() => new List<Pet> { new Pet { Name = "Coco", Type = "Cow" } };
        private IEnumerable<Pet> GetMaryPets() => new List<Pet> { new Pet { Name = "Mocha", Type = "Turtle" } };

        /// <summary>
        /// Test Accessor can return Pet Owners
        /// </summary>
        [TestMethod]
        public void CanGetOwnerListTest()
        {

            var list = _accessor.GetOwners();
            Assert.IsNotNull(list); // Test if null

        }
    }
}