namespace UnitTestingBasics.Tests
{
    using NUnit.Framework;

    public class DummyTest
    {
        private Dummy dummy;
        private const int health = 10;
        private const int experience = 5;
        private const int dummyTakesAttack = 1;
        private const int expectedHealth = 9;
        private const int dummyDeadlyAttacked = 10;
        private const int expectedExperience = 5;

        [SetUp]
        public void DummyInit()
        {
            // Arrange
            this.dummy = new Dummy(health, experience);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            // Act
            this.dummy.TakeAttack(dummyTakesAttack);

            // Assert
            Assert.That(this.dummy.Health.Equals(expectedHealth));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            this.dummy.TakeAttack(dummyDeadlyAttacked);

            Assert.That(() => this.dummy.TakeAttack(dummyDeadlyAttacked), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveEX()
        {
            this.dummy.TakeAttack(dummyDeadlyAttacked);

            Assert.That(this.dummy.GiveExperience() == expectedExperience);
        }
    }
}
