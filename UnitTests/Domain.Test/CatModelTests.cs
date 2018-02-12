using NUnit.Framework;
using PetOwners.Core.Domain;

namespace Domain.Test
{

    /// <summary>
    /// Test properties of owner
    /// </summary>
    [TestFixture()]
    public class CatModelTests
    {
        /// <summary>
        /// Cat Instance for use in testing
        /// </summary>
        public Cat _cat = new Cat();

        /// <summary>
        /// Test cat's Owner's gender
        /// </summary>
        [TestCase]
        public void GetSetOWnerGendeTest()
        {
            _cat.OwnerGender = "Male";
            Assert.AreEqual(_cat.OwnerGender, "Male");
        }

        /// <summary>
        /// Test cat's name
        /// </summary>
        [TestCase]
        public void GetSetCatNameTest()
        {
            _cat.Name = "Tiger";
            Assert.AreEqual(_cat.Name, "Tiger");
        }

    }
}