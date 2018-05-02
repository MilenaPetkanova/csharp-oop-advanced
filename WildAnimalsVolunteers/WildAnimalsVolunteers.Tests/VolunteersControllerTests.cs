namespace WildAnimalsVolunteers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WildAnimalsVolunteers.Core;
    using WildAnimalsVolunteers.Interfaces;

    [TestClass]
    public class VolunteersControllerTests
    {
        private IVolunteersController volunteersController;


        [TestInitialize]
        public void Setup()
        {
            this.volunteersController = new VolunteersController();
        }

        //[TestMethod]
        //public void AddVolunteerToCategory_IncreaseCategoriesInCategoriesController()
        //{

        //}
    }
}
