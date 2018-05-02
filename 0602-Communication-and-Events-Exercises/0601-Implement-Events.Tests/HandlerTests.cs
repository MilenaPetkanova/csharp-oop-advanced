namespace _0601_Implement_Events.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class HandlerTests
    {
        private IWriter writer;

        [SetUp]
        public void InitUI()
        {
            this.writer = new ConsoleWriter();
        }

        [Test]
        public void ChangeNameWhenDispatcherChangesName()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            var engine = new Engine();

            //var eventChangeName = new NameChangeEventArgs("TestName");
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            engine.Run();
            dispatcher.Name.Equals("TestName");
            string expected = "Dispatcher's name changed to TestName.";

            Assert.Equals(engine.ToString(), expected);
        }
    }
}
