using Moq;
using PetOwners.Core.Domain;
using System.Collections.Generic;

namespace Mocks
{
    public class MockDataAccessor
    {
        public static Mock<IDataAccessor> SetUpMock()
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

            // Return set up mock repository
            return mockAglPeopleWebApiAccessor;
        }
        // private methods to set pets for Mock owners
        private static IEnumerable<Pet> GetJamesPets() => new List<Pet> { new Pet { Name = "Black", Type = "Sheep" } };
        private static IEnumerable<Pet> GetChrisPets() => new List<Pet> { new Pet { Name = "Coco", Type = "Cow" } };
        private static IEnumerable<Pet> GetMaryPets() => new List<Pet> { new Pet { Name = "Mocha", Type = "Cat" } };

    }
}
