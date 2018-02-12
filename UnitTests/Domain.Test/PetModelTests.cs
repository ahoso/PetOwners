using NUnit.Framework;
using PetOwners.Core.Domain;

namespace Repository.Tests
{

    /// <summary>
    /// Test properties of owner
    /// </summary>
    [TestFixture()]
    public class PetModelTests
    {
        /// <summary>
        /// Mock PetOwner Repository for use in testing
        /// </summary>
        public Pet _pet = new Pet();

        /// <summary>
        /// Test owner name
        /// </summary>
        [TestCase]
        public void GetSetPetNameTest()
        {
            _pet.Name = "Jet";
            Assert.AreEqual(_pet.Name, "Jet");
        }

        /// <summary>
        /// Test owner age
        /// </summary>
        [TestCase]
        public void GetSetPetTypeTest()
        {
            _pet.Type = "Snake";
            Assert.AreEqual(_pet.Type, "Snake");
        }

    }
}