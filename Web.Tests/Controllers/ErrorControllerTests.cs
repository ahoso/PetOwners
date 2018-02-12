using System.Web.Mvc;
using NUnit.Framework;
using PetOwners.Const;
using PetOwners.Controllers;

namespace Unit.Web.Controllers.Tests
{
    /// <summary>
    /// Test Error Controller
    /// </summary>
    [TestFixture()]
    public class ErrorControllerTests
    {
        /// <summary>
        /// Test to return error
        /// </summary>
        [TestCase]
        public void ControllerReturnErrorViewTest()
        {
            var _controller = new ErrorController();
            var _result = _controller.Index() as ViewResult;

            Assert.AreEqual(ViewNamne.Error, _result.ViewName);
        }
    }
}