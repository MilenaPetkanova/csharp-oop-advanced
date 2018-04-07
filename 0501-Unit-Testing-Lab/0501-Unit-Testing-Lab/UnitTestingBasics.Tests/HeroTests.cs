namespace UnitTestingBasics.Tests
{
    using NUnit.Framework;
    using Moq;

    public class HeroTests
    {
        private const int AxeAttackPoints = 10;
        private const int DurabilityPoints = 5;
        private const int DummyHealth = 10;
        private const int DummyExperience = 5;
        private const int ExpectedDummyExperience = 5;

        [Test]
        public void HeroGainsExperienceWhenTargetDies()
        {
            IWeapon axe = new Axe(AxeAttackPoints, DurabilityPoints);
            ITarget dummy = new Dummy(DummyHealth, DummyExperience);
            Hero hero = new Hero("SomeName", axe);

            hero.Attack(dummy);

            Assert.That(hero.Experience.Equals(ExpectedDummyExperience));
        }

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies_Mocking()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero("SomeName", fakeWeapon.Object);
            
            hero.Attack(fakeTarget.Object);
            fakeWeapon.Verify(w => w.Attack(fakeTarget.Object));

            Assert.That(hero.Experience, Is.EqualTo(20));
        }

    }
}