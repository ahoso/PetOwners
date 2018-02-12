using Moq;
using NUnit.Framework;
using PetOwners.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocks
{
    public class MockPetOwnerRepository
    {
        public static Mock<IPetOwnerRepository> SetUpMock()
        {
            // create some mock pet owners to play with
            IEnumerable<Owner> owners = new List<Owner>
                {
                    new Owner { Name = "James", Age = 33, Gender = "Male", Pets = GetJamesPets()},
                    new Owner { Name = "Chris", Age = 34, Gender = "Male", Pets = GetChrisPets()},
                    new Owner { Name = "Mary", Age = 31, Gender = "Female", Pets = GetMaryPets()}
                };

            // Mock the Web API data access 
            Mock<IPetOwnerRepository> mockAglPeopleWebApiAccessor = new Mock<IPetOwnerRepository>();

            // Return all the pet owners
            mockAglPeopleWebApiAccessor.Setup(mr => mr.GetOwners()).Returns(owners);

            // return seup web api accessor
            return mockAglPeopleWebApiAccessor;
        }
        // private methods to set pets for Mock owners
        private static IEnumerable<Pet> GetJamesPets() => new List<Pet> { new Pet { Name = "Black", Type = "Sheep" } };
        private static IEnumerable<Pet> GetChrisPets() => new List<Pet> { new Pet { Name = "Coco", Type = "Cow" } };
        private static IEnumerable<Pet> GetMaryPets() => new List<Pet> { new Pet { Name = "Mocha", Type = "Turtle" } };

    }
}
