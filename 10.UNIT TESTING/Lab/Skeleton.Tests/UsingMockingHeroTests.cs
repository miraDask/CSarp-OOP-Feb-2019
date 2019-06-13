namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class UsingMockingHeroTests
    {
        [Test]
        public void Hero_GainsXP_WhenTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(x => x.Health).Returns(0);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(20);
            fakeTarget.Setup(x => x.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero("Pesho", fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(20, hero.Experience);
        }
    }
}
