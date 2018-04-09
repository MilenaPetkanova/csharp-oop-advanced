namespace UnitTestingBasics.Tests
{
    using NUnit.Framework;

    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private const int dummyHealth = 10;
        private const int dummyExperience = 5;
        private const int axeAttack = 10;
        private const int axeNotAttack = 0;
        private const int axeDurability = 10;
        private const int axeBroken = 0;
        private const int axeExpectedDurability = 9;

        [SetUp]
        public void AxeInit()
        {
            this.axe = new Axe(axeAttack, axeDurability);
        }

        [SetUp]
        public void DummyInit()
        {
            this.dummy = new Dummy(dummyHealth, dummyExperience);
        }

        [Test]
        public void AxeLosesDurabilyAfterAttack()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(axeExpectedDurability), 
                "Axe Durability doesn't change with 1 after attack.");
        }

        [Test]
        public void AttackingWithBrokenWeapon() 
        {
            // Arrange
            this.dummy = new Dummy(dummyHealth, dummyExperience);
            this.axe = new Axe(axeNotAttack, axeBroken);

            // Assert
            Assert.That(() => this.axe.Attack(this.dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
