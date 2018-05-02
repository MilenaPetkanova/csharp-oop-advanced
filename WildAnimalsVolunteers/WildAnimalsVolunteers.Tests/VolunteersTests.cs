using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WildAnimalsVolunteers.Models.Volunteers;
using WildAnimalsVolunteers.Models.Volunteers.Transporters;

namespace WildAnimalsVolunteers.Tests
{
    [TestClass]
    public class VolunteersTests
    {
        private const string TestName = "SomeName";
        private const string TestPhone = "SomePhoneNumber";

        private const string TestStatus = "SomeStatus";
        private const string TestFacebook = "SomeFacebook";
        private const string TestArea = "SomeArea";
        private const string TestTransportType = "SomeTransportType";
        private const string TestTimeDisposal = "SomeTimeDisposal";
        private const string TestAdditionalInfo = "SomeAdditionalInfo";
        private const string TestAnotherSkills = "SomeAnotherSkills";

        private const string TestQualification = "SomeQualification";
        private const string TestDescription = "SomeDescription";

        private const string TestProposedHelp = "SomeProposedHelp";
        private const string TestNotes = "SomeNotes";

        private IList<string> sofiaTransporterData;
        private IList<string> lawyerData;
        private IList<string> notTransporterData;

        [TestInitialize]
        public void InitializeTestData()
        {
            this.sofiaTransporterData = new List<string>()
            {
                TestName, TestPhone, TestStatus, TestFacebook, TestArea,
                TestTransportType, TestTimeDisposal, TestAdditionalInfo, TestAnotherSkills
            };
            this.lawyerData = new List<string>()
            {
                TestName, TestPhone, TestQualification, TestDescription
            };
            this.notTransporterData = new List<string>()
            {
                TestName, TestPhone, TestFacebook, TestProposedHelp, TestArea, TestNotes
            };
        }

        [TestMethod]
        public void CreateSofiaTransporter()
        {
            var sofiaTransporter = new SofiaTransporter(this.sofiaTransporterData);

            var expectedNeighborhood = TestArea;
            Assert.AreEqual(expectedNeighborhood, sofiaTransporter.NeighborhoodToReactAt);
        }

        [TestMethod]
        public void CreateNotSofiaTransporter()
        {
            var sofiaTransporter = new NonSofiaTransporter(this.sofiaTransporterData);

            var expectedNeighborhood = TestArea;
            Assert.AreEqual(expectedNeighborhood, sofiaTransporter.TownToReactAt);
        }

        [TestMethod]
        public void CreateLawyer()
        {
            var lawyer = new Lawyer(this.lawyerData);

            var expectedDescription = TestDescription;
            Assert.AreEqual(expectedDescription, lawyer.Description);
        }

        [TestMethod]
        public void CreateNotTransporter()
        {
            var sofiaTransporter = new NonTransporter(this.notTransporterData);

            var expectedNotes = TestNotes;
            Assert.AreEqual(expectedNotes, sofiaTransporter.Notes);
        }
    }
}
