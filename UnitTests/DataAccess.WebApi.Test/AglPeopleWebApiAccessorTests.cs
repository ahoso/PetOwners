
using PetOwners.Core.Domain;
using NUnit.Framework;
using Mocks;

namespace DataAccess.WebApi.Test
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
            // set up mock oject
            _accessor = MockDataAccessor.SetUpMock().Object;
        }

        /// <summary>
        /// Test Mock Accessor can return Pet Owners
        /// </summary>
        [TestCase]
        public void GetOwnerListTest()
        {
            var list = _accessor.GetOwners();
            Assert.IsNotNull(list); // Test if null

        }
    }
}