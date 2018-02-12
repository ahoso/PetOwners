using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PetOwners.Core.Domain;

namespace Repository.Tests
{

    /// <summary>
    /// Test properties of owner
    /// </summary>
    [TestFixture()]
    public class OwnerModelTests
    {
        /// <summary>
        /// Owner instance
        /// </summary>
        private Owner _owner = new Owner();
        private IList<Pet> _pets = new List<Pet>();


        // default constructor
        public Owner Owner { get => _owner; set => _owner = value; }
        public IList<Pet> Pets { get => _pets; set => _pets = value; }

        /// <summary>
        /// Test owner name
        /// </summary>
        [TestCase]
        public void GetSetOwnerNameTest()
        {
            Owner.Name = "Anne";
            Assert.AreEqual(Owner.Name, "Anne");
        }

        /// <summary>
        /// Test owner age
        /// </summary>
        [TestCase]
        public void GetSetOwnerAgeTest()
        {
            Owner.Age = 19;
            Assert.AreEqual(Owner.Age, 19);
        }

        /// <summary>
        /// Test owner gender
        /// </summary>
        [TestCase]
        public void GetSetOwnerGenderTest()
        {
            Owner.Gender = "Female";
            Assert.AreEqual(Owner.Gender, "Female");
        }

    }
}