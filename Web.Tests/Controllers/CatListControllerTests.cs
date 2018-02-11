using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using PetOwners.Core.Domain;
using Moq;

namespace MVC_Client.Controllers.Tests
{
    /// <summary>
    /// Test CatList Controller
    /// </summary>
    [TestClass()]
    public class CatListControllerTests
    {
        /// <summary>
        /// Mock PetOwner Repository for use in testing
        /// </summary>
        public IPetOwnerRepository _repository;

        public CatListControllerTests()
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
        private IEnumerable<Pet> GetMaryPets() => new List<Pet> { new Pet { Name = "Maccha", Type = "Cat" } };

        /// <summary>
        /// Test to return catlist when data exist
        /// </summary>
        [TestMethod()]
        public void ControllerReturnCatListViewTest()
        {
            var _controller = new CatListController(_repository);
            var _result = _controller.CatList() as ViewResult;

            Assert.AreEqual("CatList", _result.ViewName);
        }




    }
}