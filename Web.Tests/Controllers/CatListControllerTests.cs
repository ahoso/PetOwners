using System.Web.Mvc;
using PetOwners.Core.Domain;
using NUnit.Framework;
using Mocks;
using MVC_Client.Controllers;
using PetOwners.Const;

namespace Unit.Web.Controllers.Tests
{
    /// <summary>
    /// Test CatList Controller
    /// </summary>
    [TestFixture()]
    public class CatListControllerTests
    {
        /// <summary>
        /// Mock PetOwner Repository for use in testing
        /// </summary>
        public IPetOwnerRepository _repository;

        [SetUp]
        public void SetUp()
        {
            // set up mock oject
            _repository = MockPetOwnerRepository.SetUpMock().Object;

        }
        /// <summary>
        /// Test to return catlist 
        /// </summary>
        [TestCase]
        public void ControllerReturnCatListViewTest()
        {
            var _controller = new CatListController(_repository);
            var _result = _controller.CatList() as ViewResult;

            Assert.AreEqual(ViewNamne.CatList, _result.ViewName);
        }




    }
}