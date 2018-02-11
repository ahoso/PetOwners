using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetOwners.Core.Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestClass()]
    public class PetOwnerRepositoryTests
    {
        IPetOwnerRepository _repository;

        /// <summary>
        /// Initiallise Test
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _repository = new Mock<IPetOwnerRepository>();
        }

        [TestMethod()]
        public void PetOwnerRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOwnersTest()
        {
            // Act
            IEnumerable<Owner> items = _repository.GetOwners();

            // Assert
            Assert.IsTrue(items.Count() >= 0, "Get all owners, count will be 0 or more than 0.");
        }
    }
}