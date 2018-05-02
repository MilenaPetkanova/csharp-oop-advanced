namespace WildAnimalsVolunteers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using WildAnimalsVolunteers.Commands;
    using WildAnimalsVolunteers.Core;
    using WildAnimalsVolunteers.Interfaces;
    using WildAnimalsVolunteers.Interfaces.Volunteers;
    using WildAnimalsVolunteers.Models.Volunteers.Factory;

    [TestClass]
    public class CommandsTests
    {
        private const string TestCategory = "SofiaTransporters";

        private const string TestName = "SomeName";
        private const string TestPhone = "SomePhoneNumber";
        private const string TestStatus = "SomeStatus";
        private const string TestFacebook = "SomeFacebook";
        private const string TestArea = "SomeArea";
        private const string TestTransportType = "SomeTransportType";
        private const string TestTimeDisposal = "SomeTimeDisposal";
        private const string TestAdditionalInfo = "SomeAdditionalInfo";
        private const string TestAnotherSkills = "SomeAnotherSkills";

        private IVolunteersController volunteersController;
        private ICategoriesController categoriesController;
        private IVolunteerFactory volunteerFactory;
        private IList<string> testVolunteersData;

        [TestInitialize]
        public void SetUp()
        {
            this.volunteersController = new VolunteersController();
            this.categoriesController = new CategoriesController();
            this.volunteerFactory = new VolunteerFactory();
            this.testVolunteersData = new List<string>()
                    {
                        TestName, TestPhone, TestStatus, TestFacebook, TestArea,
                        TestTransportType, TestTimeDisposal, TestAdditionalInfo, TestAnotherSkills
                    };
        }

        [TestMethod]
        public void InvalidCommand_GetException()
        {
            var engine = new Engine();
            var processCommandMethod = typeof(Engine)
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).First();

            Assert.ThrowsException<ArgumentException>(() => processCommandMethod.Invoke(engine, new object[] { this.testVolunteersData }));
        }

        [TestMethod]
        public void AddVolunteerCommand_ReturnsExpectedMessage()
        {
            this.testVolunteersData.Insert(0, TestCategory);
            IExecutable command = new AddVolunteerCommand(this.testVolunteersData, this.volunteersController);

            var actualMessage = command.Execute();

            var expectedMessage = $"{TestName} is successfully added to {TestCategory}.";
            Assert.AreEqual(expectedMessage, actualMessage);
        }


        //[TestMethod]
        //public void AddVolunteerToCategory_IncreaseCategoriesInCategoriesController()
        //{
        //    this.testVolunteersData.Insert(0, TestCategory);
        //    IExecutable command = new AddVolunteerCommand(this.testVolunteersData, this.volunteersController);
        //    var category = this.categoriesController.Categories.First(c => c.GetType().Name == TestCategory);

        //    var result = command.Execute();

        //    var expectedVolunteersCount = 1;
        //    Assert.AreEqual(expectedVolunteersCount, category.Volunteers.Count);
        //}

        //        [TestMethod]
        //        public void DeleteVolunteerCommand_RemovesVolunteerByItsName()
        //        {
        //            IExecutable addCmnd = new AddVolunteerCommand(this.volunteersController, TestCategory, this.testVolunteersData);
        //            IExecutable DeleteCmnd = new DeleteVolunteerCommand(this.volunteersController, TestCategory, this.testVolunteersData);

        //            FieldInfo[] fields = typeof(VolunteersController).GetFields(
        //                         BindingFlags.NonPublic |
        //                         BindingFlags.Instance);

        //            var field = typeof(VolunteersController).GetField(
        //                "volunteersByCategories", BindingFlags.Instance | BindingFlags.NonPublic);


        //            Assert.That(fields.First().Va);
        //        }

        //        [TestMethod]
        //        public void DeleteVolunteerCommand_ReturnsExpectedMessage()
        //        {
        //            IExecutable command = new DeleteVolunteerCommand(this.volunteersController, TestCategory, this.testVolunteersData);

        //            var actualMessage = command.Execute();
        //            var expectedMessage = $"{TestName} is successfully deleted.";

        //            Assert.AreEqual(expectedMessage, actualMessage);
        //        }
    }
}
